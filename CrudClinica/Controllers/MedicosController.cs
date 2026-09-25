using CrudClinica.Data;
using CrudClinica.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CrudClinica.Controllers
{
    public class MedicosController : Controller
    {
        private readonly DataBase _dataBase;

        public MedicosController(DataBase dataBase)
        {
            _dataBase = dataBase;
        }

        [HttpGet]
        public IActionResult Index()
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

                                nome = reader["nome"].ToString()!,

                                crm = reader["crm"].ToString()!,

                                idEspecialidade = Convert.ToInt32(
                                    reader["idEspecialidade"]),

                                especialidade = reader["especialidade"]
                                    .ToString()
                            });
                        }
                    }
                }
            }

            return View(medicos);
        }

        private List<Especialidade> CarregarEspecialidades()
        {
            List<Especialidade> especialidades =
                new List<Especialidade>();

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

            return especialidades;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Especialidades = CarregarEspecialidades();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Especialidades = CarregarEspecialidades();

                return View(medico);
            }

            using (MySqlConnection conexao = _dataBase.Conectar())
            {
                conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(
                    "sp_medico_criar", conexao))
                {
                    comando.CommandType =
                        System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue(
                        "p_nome",
                        medico.nome);

                    comando.Parameters.AddWithValue(
                        "p_crm",
                        medico.crm);

                    comando.Parameters.AddWithValue(
                        "p_idEspecialidade",
                        medico.idEspecialidade);

                    comando.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Medico? medico = null;

            using (MySqlConnection conexao = _dataBase.Conectar())
            {
                conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(
                    "sp_medico_obter", conexao))
                {
                    comando.CommandType =
                        System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue(
                        "p_idMedico",
                        id);

                    using (MySqlDataReader reader =
                        comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            medico = new Medico
                            {
                                idMedico = Convert.ToInt32(
                                    reader["idMedico"]),

                                nome = reader["nome"].ToString()!,

                                crm = reader["crm"].ToString()!,

                                idEspecialidade = Convert.ToInt32(
                                    reader["idEspecialidade"]),

                                especialidade = reader["especialidade"]
                                    .ToString()
                            };
                        }
                    }
                }
            }

            if (medico == null)
            {
                return NotFound();
            }

            ViewBag.Especialidades = CarregarEspecialidades();

            return View(medico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Especialidades = CarregarEspecialidades();

                return View(medico);
            }

            using (MySqlConnection conexao = _dataBase.Conectar())
            {
                conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(
                    "sp_medico_editar", conexao))
                {
                    comando.CommandType =
                        System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue(
                        "p_idMedico",
                        medico.idMedico);

                    comando.Parameters.AddWithValue(
                        "p_nome",
                        medico.nome);

                    comando.Parameters.AddWithValue(
                        "p_crm",
                        medico.crm);

                    comando.Parameters.AddWithValue(
                        "p_idEspecialidade",
                        medico.idEspecialidade);

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
                        "sp_medico_excluir", conexao))
                    {
                        comando.CommandType =
                            System.Data.CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue(
                            "p_idMedico",
                            id);

                        comando.ExecuteNonQuery();
                    }
                }

                TempData["Sucesso"] =
                    "Médico excluído com sucesso.";
            }
            catch (MySqlException ex)
            {
                TempData["Erro"] = ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}

