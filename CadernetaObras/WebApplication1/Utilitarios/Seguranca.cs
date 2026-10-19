using System;
using System.Security.Cryptography;

namespace WebApplication1.Utilitarios
{
    // Senha nunca é guardada pura: gravamos um "hash" com salt (PBKDF2).
    // Formato gravado no banco:  iterações.salt.hash   (salt e hash em Base64)
    public static class Seguranca
    {
        private const int Iteracoes = 100000;

        public static string GerarHash(string senha)
        {
            byte[] salt = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            byte[] hash = Calcular(senha, salt, Iteracoes);
            return Iteracoes + "." + Convert.ToBase64String(salt) + "." + Convert.ToBase64String(hash);
        }

        public static bool Verificar(string senha, string hashGravado)
        {
            if (string.IsNullOrEmpty(hashGravado)) return false;
            string[] partes = hashGravado.Split('.');
            if (partes.Length != 3) return false;

            int iteracoes = int.Parse(partes[0]);
            byte[] salt = Convert.FromBase64String(partes[1]);
            byte[] esperado = Convert.FromBase64String(partes[2]);
            byte[] calculado = Calcular(senha, salt, iteracoes);

            // comparação sem parar no primeiro byte diferente
            int diferenca = esperado.Length ^ calculado.Length;
            for (int i = 0; i < esperado.Length && i < calculado.Length; i++)
                diferenca |= esperado[i] ^ calculado[i];
            return diferenca == 0;
        }

        // Impressão digital (SHA-256, 64 caracteres) de um texto - usada nas assinaturas digitais
        public static string Sha256Hex(string texto)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(texto ?? ""));
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (byte b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        private static byte[] Calcular(string senha, byte[] salt, int iteracoes)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(senha, salt, iteracoes, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(32);
            }
        }
    }
}
