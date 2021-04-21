using ClienteWebMatricula.Data;
using ClienteWebMatricula.Models;
using ClienteWebMatricula.Models.Crear;
using ClienteWebMatricula.Models.Modificar;
using ClienteWebMatricula.Models.Secundarias;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClienteWebMatricula.Controllers
{
    public class ProfesoresController : Controller
    {
        private Api api = new Api(@"http://localhost/WebApiMatricula/api/");
        private string URL_API = "http://localhost/WebApiMatricula/api/Usuarios/Profesores";

        public IActionResult Profesores()
        {
            List<ModelUsuario> datos = ConnectGET();
            List<Profesor> datitos = new List<Profesor>();
            foreach (ModelUsuario t in datos)
            {
                Profesor txt = new Profesor();
                datitos.Add(txt.CargarDatosNuevos(t));
            }
            return View("Profesores", datitos);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            Profesor profesor = new Profesor();
            profesor.tiposIdentificacion = cargarTiposUsuario();
            return View(profesor);
        }

        [HttpPost]
        public ActionResult Crear(Profesor profesor)
        {
            ModelUsuarioPos temp = new ModelUsuarioPos();
            temp.cargarDatosNuevos(profesor);

            string res = api.ConnectPOST(temp.ToJsonString(), "/Usuarios");

            if (res.Equals("1"))
            {
                return RedirectToAction("Profesores", "Profesores");
            }

            return View();
        }

        public ActionResult Actualizar(string id, string PropertyName, string value)
        {
            bool status = false;
            string mensaje = "No Modificado";

            List<Profesor> profesor = ActualizarModelo(id, value, PropertyName);
            Profesor pro = new Profesor();

            if (profesor != null)
            {
                foreach (Profesor t in profesor)
                {
                    if (t.NumeroIdentificacion.Equals(id))
                    {
                        pro.NumeroIdentificacion = id;
                        pro.nombre = t.nombre;
                        pro.Apellidos = t.Apellidos;
                        pro.fechanacimiento = t.fechanacimiento;
                        pro.Telefonos = t.Telefonos;
                        pro.emails = t.emails;
                        pro.idtipoIdentificacion = t.idtipoIdentificacion;
                        pro.idtipoUsuario = t.idtipoUsuario;
                    }
                }

                ModelUsuarioPut usu = new ModelUsuarioPut();
                usu.cargarDatosNuevos(pro);
                string res = api.ConnectPUT(usu.ToJsonString(), "/Usuarios", id);

                if (res.Equals("1"))
                {
                    status = true;
                    mensaje = "Valor modificado";
                }

                return Json(new { value = value, status = status, mensaje = mensaje });

            }
            else
            {
                return Json(new { value = value, status = status, mensaje = mensaje });
            }

        }

        public List<Profesor> ActualizarModelo(string id, string cambio, string p)
        {
            List<Profesor> profesor = new List<Profesor>();
            List<ModelUsuario> datos = ConnectGET();
            List<Profesor> datitos = new List<Profesor>();
            foreach (ModelUsuario t in datos)
            {
                Profesor txt = new Profesor();
                datitos.Add(txt.CargarDatosNuevos(t));
            }
            if (datitos != null)
            {
                foreach (Profesor t in datitos)
                {
                    if (t.NumeroIdentificacion.Equals(id))
                    {
                        if (p.Equals("Nombre"))
                        {
                            t.nombre = cambio;
                        }
                        else if (p.Equals("Apellidos"))
                        {
                            t.Apellidos = cambio;
                        }
                        else if (p.Equals("Telefonos"))
                        {
                            t.Telefonos = cambio;
                        }
                        else if (p.Equals("emails"))
                        {
                            t.emails = cambio;
                        }
                        else if (p.Equals("fechanacimiento"))
                        {
                            t.fechanacimiento = DateTime.Parse(cambio);
                        }
                    }

                    profesor.Add(t);
                }
                return profesor;

            }
            else
            {
                return profesor;
            }


        }

        public ActionResult Eliminar(string id)
        {

            string res = api.ConnectDELETE("/Usuarios", id);

            if (res.Equals("1"))
            {
                return RedirectToAction("Profesores", "Profesores");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Emails(string id)
        {
            List<ModelUsuario> data = ConnectGET();
            List<ModelEmails> emails = ObtenerEmails(data, id);
            return View(emails);
        }

        public IActionResult Telefonos(string id)
        {
            List<ModelUsuario> data = ConnectGET();
            List<ModelTelefonos> tels = ObtenerTelefonos(data, id);
            return View(tels);
        }

        public List<ModelUsuario> ConnectGET()
        {
            try
            {
                List<ModelUsuario> lista = null;

                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.GetAsync(URL_API);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        var task1 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task1.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        //lista.Add(error.Exceptionmessage);
                        return lista;

                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        lista = JsonConvert.DeserializeObject<List<ModelUsuario>>(mens);

                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> cargarTiposUsuario()
        {
            try
            {
                List<string> tiposUsuario = new List<string>();
                string data = "Cédula de Identidad,DIMEX,Cédula de Residencia,Pasaporte";

                string[] tipos = data.Split(',');

                foreach (string temp in tipos)
                {
                    tiposUsuario.Add(temp);
                }
                return tiposUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModelTelefonos> ObtenerTelefonos(List<ModelUsuario> data, string id)
        {
            try
            {
                List<ModelTelefonos> lista = new List<ModelTelefonos>();
                foreach (ModelUsuario user in data)
                {
                    if (user.NumeroIdentificacion.Equals(id))
                    {
                        lista = user.Telefonos;
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModelEmails> ObtenerEmails(List<ModelUsuario> data, string id)
        {
            try
            {
                List<ModelEmails> lista = new List<ModelEmails>();
                foreach (ModelUsuario user in data)
                {
                    if (user.NumeroIdentificacion.Equals(id))
                    {
                        lista = user.Emails;
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
