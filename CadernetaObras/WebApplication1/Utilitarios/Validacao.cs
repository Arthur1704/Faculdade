using System;
using System.Net.Mail;

namespace WebApplication1.Utilitarios
{
    public static class Validacao
    {
        public static bool Email(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                // precisa ter ponto no domínio (a@b.com), senão "a@b" passaria
                return m.Address == email.Trim() && m.Host.Contains(".") && !m.Host.EndsWith(".");
            }
            catch (FormatException)
            {
                return false;
            }
        }

        // Telefone com DDD: 10 ou 11 números (só confere se foi preenchido)
        public static bool Telefone(string digitos)
        {
            return digitos.Length == 10 || digitos.Length == 11;
        }

        public static bool Cep(string digitos)
        {
            return digitos.Length == 8;
        }

        public static bool CpfOuCnpj(string digitos)
        {
            if (digitos.Length == 11) return Cpf(digitos);
            if (digitos.Length == 14) return Cnpj(digitos);
            return false;
        }

        public static bool Cpf(string cpf)
        {
            if (cpf.Length != 11 || TodosIguais(cpf)) return false;
            return DigitoCpf(cpf, 9) == cpf[9] - '0' && DigitoCpf(cpf, 10) == cpf[10] - '0';
        }

        private static int DigitoCpf(string cpf, int quantidade)
        {
            int soma = 0;
            for (int i = 0; i < quantidade; i++)
                soma += (cpf[i] - '0') * (quantidade + 1 - i);
            int resto = (soma * 10) % 11;
            return resto == 10 ? 0 : resto;
        }

        public static bool Cnpj(string cnpj)
        {
            if (cnpj.Length != 14 || TodosIguais(cnpj)) return false;
            int[] pesos1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] pesos2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            return DigitoCnpj(cnpj, pesos1) == cnpj[12] - '0' && DigitoCnpj(cnpj, pesos2) == cnpj[13] - '0';
        }

        private static int DigitoCnpj(string cnpj, int[] pesos)
        {
            int soma = 0;
            for (int i = 0; i < pesos.Length; i++)
                soma += (cnpj[i] - '0') * pesos[i];
            int resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }

        private static bool TodosIguais(string s)
        {
            for (int i = 1; i < s.Length; i++)
                if (s[i] != s[0]) return false;
            return true;
        }
    }
}
