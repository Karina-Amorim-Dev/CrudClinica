using CrudClinica.Data;
using CrudClinica.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CrudClinica.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly DataBase _dataBase;

        public ConsultasController(DataBase dataBase)
        {
            _dataBase = dataBase;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Consulta> consultas = new List<Consulta>();

            using (MySqlConnection conexao = _dataBase.Conectar())
            {
                conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(
                    "sp_consulta_listar", conexao))
                {
                    comando.CommandType =
                        System.Data.CommandType.StoredProcedure;

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            consultas.Add(new Consulta
                            {
                                idConsulta = Convert.ToInt32(
                                    reader["idConsulta"]),

                                idMedico = Convert.ToInt32(
                                    reader["idMedico"]),

                                medico = reader["medico"].ToString(),

                                idPaciente = Convert.ToInt32(
                                    reader["idPaciente"]),

                                paciente = reader["paciente"].ToString(),

                                dataHora = Convert.ToDateTime(
                                    reader["dataHora"])
                            });
                        }
                    }
                }
            }

            return View(consultas);
        }
        private List<Medico> CarregarMedicos()
        {
            List<Medico> medicos = new List<Medico>();

            using (MySqlConnection conexao = _dataBase.Conectar())
            {
                conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(
                    "sp_medico_listar", conexao))
                {
                    comando.CommandType =
                        System.Data.CommandType.StoredProcedure;

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            medicos.Add(new Medico
                            {
                                idMedico = Convert.ToInt32(
                                    reader["idMedico"]),

                                nome = reader["nome"].ToString()!
                            });
                        }
                    }
                }
            }

            return medicos;
        }
        private List<Paciente> CarregarPacientes()
        {
            List<Paciente> pacientes = new List<Paciente>();

            using (MySqlConnection conexao = _dataBase.Conectar())
            {
                conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(
                    "sp_paciente_listar", conexao))
                {
                    comando.CommandType =
                        System.Data.CommandType.StoredProcedure;

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pacientes.Add(new Paciente
                            {
                                idPaciente = Convert.ToInt32(
                                    reader["idPaciente"]),

                                nome = reader["nome"].ToString()!
                            });
                        }
                    }
                }
            }

            return pacientes;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Medicos = CarregarMedicos();
            ViewBag.Pacientes = CarregarPacientes();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Consulta consulta)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Medicos = CarregarMedicos();
                ViewBag.Pacientes = CarregarPacientes();

                return View(consulta);
            }

            using (MySqlConnection conexao = _dataBase.Conectar())
            {
                conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(
                    "sp_consulta_criar", conexao))
                {
                    comando.CommandType =
                        System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue(
                        "p_idMedico",
                        consulta.idMedico);

                    comando.Parameters.AddWithValue(
                        "p_idPaciente",
                        consulta.idPaciente);

                    comando.Parameters.AddWithValue(
                        "p_dataHora",
                        consulta.dataHora);

                    comando.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Consulta? consulta = null;

            using (MySqlConnection conexao = _dataBase.Conectar())
            {
                conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(
                    "sp_consulta_obter", conexao))
                {
                    comando.CommandType =
                        System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue(
                        "p_idConsulta",
                        id);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            consulta = new Consulta
                            {
                                idConsulta = Convert.ToInt32(
                                    reader["idConsulta"]),

                                idMedico = Convert.ToInt32(
                                    reader["idMedico"]),

                                medico = reader["medico"].ToString(),

                                idPaciente = Convert.ToInt32(
                                    reader["idPaciente"]),

                                paciente = reader["paciente"].ToString(),

                                dataHora = Convert.ToDateTime(
                                    reader["dataHora"])
                            };
                        }
                    }
                }
            }

            if (consulta == null)
            {
                return NotFound();
            }

            ViewBag.Medicos = CarregarMedicos();
            ViewBag.Pacientes = CarregarPacientes();

            return View(consulta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Consulta consulta)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Medicos = CarregarMedicos();
                ViewBag.Pacientes = CarregarPacientes();

                return View(consulta);
            }

            using (MySqlConnection conexao = _dataBase.Conectar())
            {
                conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(
                    "sp_consulta_editar", conexao))
                {
                    comando.CommandType =
                        System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue(
                        "p_idConsulta",
                        consulta.idConsulta);

                    comando.Parameters.AddWithValue(
                        "p_idMedico",
                        consulta.idMedico);

                    comando.Parameters.AddWithValue(
                        "p_idPaciente",
                        consulta.idPaciente);

                    comando.Parameters.AddWithValue(
                        "p_dataHora",
                        consulta.dataHora);

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
                        "sp_consulta_excluir", conexao))
                    {
                        comando.CommandType =
                            System.Data.CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue(
                            "p_idConsulta",
                            id);

                        comando.ExecuteNonQuery();
                    }
                }

                TempData["Sucesso"] =
                    "Consulta excluída com sucesso.";
            }
            catch (MySqlException ex)
            {
                TempData["Erro"] = ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}

