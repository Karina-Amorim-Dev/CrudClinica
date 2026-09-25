using CrudClinica.Data;
using CrudClinica.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CrudClinica.Controllers
{
    public class PacientesController : Controller
    {
        private readonly DataBase _dataBase;

        public PacientesController(DataBase dataBase)
        {
            _dataBase = dataBase;
        }
        public IActionResult Index()
        {
            List<Paciente> pacientes = new List<Paciente>();

            using (MySqlConnection conexao = _dataBase.Conectar())
            {
                conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(
                    "sp_paciente_listar", conexao))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pacientes.Add(new Paciente
                            {
                                idPaciente = Convert.ToInt32(reader["idPaciente"]),
                                nome = reader["nome"].ToString()!,
                                cpf = reader["cpf"].ToString()!,
                                telefone = reader["telefone"] == DBNull.Value
                                    ? null
                                    : reader["telefone"].ToString(),
                                dataNasc = reader["dataNasc"] == DBNull.Value
                                    ? null
                                    : Convert.ToDateTime(reader["dataNasc"])
                            });
                        }
                    }
                }
            }

            return View(pacientes);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return View(paciente);
            }

            using (MySqlConnection conexao = _dataBase.Conectar())
            {
                conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(
                    "sp_paciente_criar", conexao))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue(
                        "p_nome", paciente.nome);

                    comando.Parameters.AddWithValue(
                        "p_cpf", paciente.cpf);

                    comando.Parameters.AddWithValue(
                        "p_telefone", paciente.telefone ?? (object)DBNull.Value);

                    comando.Parameters.AddWithValue(
                        "p_dataNasc", paciente.dataNasc ?? (object)DBNull.Value);

                    comando.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Paciente? paciente = null;

            using (MySqlConnection conexao = _dataBase.Conectar())
            {
                conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(
                    "sp_paciente_obter", conexao))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue(
                        "p_idPaciente", id);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            paciente = new Paciente
                            {
                                idPaciente = Convert.ToInt32(
                                    reader["idPaciente"]),

                                nome = reader["nome"].ToString()!,

                                cpf = reader["cpf"].ToString()!,

                                telefone = reader["telefone"] == DBNull.Value
                                    ? null
                                    : reader["telefone"].ToString(),

                                dataNasc = reader["dataNasc"] == DBNull.Value
                                    ? null
                                    : Convert.ToDateTime(reader["dataNasc"])
                            };
                        }
                    }
                }
            }

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return View(paciente);
            }

            using (MySqlConnection conexao = _dataBase.Conectar())
            {
                conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(
                    "sp_paciente_editar", conexao))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue(
                        "p_idPaciente", paciente.idPaciente);

                    comando.Parameters.AddWithValue(
                        "p_nome", paciente.nome);

                    comando.Parameters.AddWithValue(
                        "p_cpf", paciente.cpf);

                    comando.Parameters.AddWithValue(
                        "p_telefone",
                        paciente.telefone ?? (object)DBNull.Value);

                    comando.Parameters.AddWithValue(
                        "p_dataNasc",
                        paciente.dataNasc ?? (object)DBNull.Value);

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
                        "sp_paciente_excluir", conexao))
                    {
                        comando.CommandType = System.Data.CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue(
                            "p_idPaciente", id);

                        comando.ExecuteNonQuery();
                    }
                }

                TempData["Sucesso"] = "Paciente excluído com sucesso.";
            }
            catch (MySqlException ex)
            {
                TempData["Erro"] = ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}