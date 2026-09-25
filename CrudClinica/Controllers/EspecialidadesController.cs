using CrudClinica.Data;
using CrudClinica.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CrudClinica.Controllers
{
    public class EspecialidadesController : Controller
    {
        private readonly DataBase _dataBase;

        public EspecialidadesController(DataBase dataBase)
        {
            _dataBase = dataBase;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Especialidade> especialidades = new List<Especialidade>();

            using (MySqlConnection conexao = _dataBase.Conectar())
            {
                conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(
                    "sp_especialidade_listar", conexao))
                {
                    comando.CommandType =
                        System.Data.CommandType.StoredProcedure;

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            especialidades.Add(new Especialidade
                            {
                                idEspecialidade = Convert.ToInt32(
                                    reader["idEspecialidade"]),

                                nome = reader["nome"].ToString()!
                            });
                        }
                    }
                }
            }

            return View(especialidades);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Especialidade especialidade)
        {
            if (!ModelState.IsValid)
            {
                return View(especialidade);
            }

            using (MySqlConnection conexao = _dataBase.Conectar())
            {
                conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(
                    "sp_especialidade_criar", conexao))
                {
                    comando.CommandType =
                        System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue(
                        "p_nome",
                        especialidade.nome);

                    comando.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Especialidade? especialidade = null;

            using (MySqlConnection conexao = _dataBase.Conectar())
            {
                conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(
                    "sp_especialidade_obter", conexao))
                {
                    comando.CommandType =
                        System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue(
                        "p_idEspecialidade",
                        id);

                    using (MySqlDataReader reader =
                        comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            especialidade = new Especialidade
                            {
                                idEspecialidade = Convert.ToInt32(
                                    reader["idEspecialidade"]),

                                nome = reader["nome"].ToString()!
                            };
                        }
                    }
                }
            }

            if (especialidade == null)
            {
                return NotFound();
            }

            return View(especialidade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Especialidade especialidade)
        {
            if (!ModelState.IsValid)
            {
                return View(especialidade);
            }

            using (MySqlConnection conexao = _dataBase.Conectar())
            {
                conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(
                    "sp_especialidade_editar", conexao))
                {
                    comando.CommandType =
                        System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue(
                        "p_idEspecialidade",
                        especialidade.idEspecialidade);

                    comando.Parameters.AddWithValue(
                        "p_nome",
                        especialidade.nome);

                    comando.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(int id)
        {
            try
            {
                using (MySqlConnection conexao = _dataBase.Conectar())
                {
                    conexao.Open();

                    using (MySqlCommand comando = new MySqlCommand(
                        "sp_especialidade_excluir", conexao))
                    {
                        comando.CommandType =
                            System.Data.CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue(
                            "p_idEspecialidade",
                            id);

                        comando.ExecuteNonQuery();
                    }
                }

                TempData["Sucesso"] =
                    "Especialidade excluída com sucesso.";
            }
            catch (MySqlException ex)
            {
                TempData["Erro"] = ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}