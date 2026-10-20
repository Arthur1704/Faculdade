using System.Data;

namespace WebApplication1.Dados
{
    public static class DashboardDAO
    {
        public static DataRow Totais()
        {
            string sql = @"
                SELECT
                    (SELECT COUNT(*) FROM Obras) AS TotalObras,
                    (SELECT COUNT(*) FROM Obras WHERE Status = 'Em andamento') AS ObrasAndamento,
                    (SELECT COUNT(*) FROM Proprietarios) AS TotalProprietarios,
                    (SELECT COUNT(*) FROM Proprietarios WHERE Status = 'Ativo') AS ProprietariosAtivos,
                    (SELECT COUNT(*) FROM Profissionais) AS TotalProfissionais,
                    (SELECT COUNT(*) FROM Profissionais WHERE Status = 'Ativo') AS ProfissionaisAtivos,
                    (SELECT COUNT(*) FROM Recibos) AS TotalRecibos,
                    (SELECT COUNT(*) FROM Recibos WHERE Status = 'Aguardando') AS RecibosAguardando";
            return Banco.Consultar(sql).Rows[0];
        }
    }
}
