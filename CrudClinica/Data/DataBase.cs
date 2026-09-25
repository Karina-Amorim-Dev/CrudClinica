using MySql.Data.MySqlClient;

namespace CrudClinica.Data
{
    public class DataBase
    {
        // String de conexão obtida do User Secrets
        private readonly string conexao;

        // Construtor recebe as configurações da aplicação
        public DataBase(IConfiguration configuration)
        {
            conexao = configuration.GetConnectionString("CrudClinica")
                ?? throw new InvalidOperationException(
                    "A string de conexão 'CrudClinica' não foi encontrada.");
        }

        // Cria e retorna uma nova conexão com o banco
        public MySqlConnection Conectar()
        {
            return new MySqlConnection(conexao);
        }
    }
}