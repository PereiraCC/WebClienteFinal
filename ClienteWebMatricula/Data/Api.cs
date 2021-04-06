using ClienteWebMatricula.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClienteWebMatricula.Data
{
    public class Api
    {
        private string URL_API = "";
        public Api(string url)
        {
            URL_API = url;
        }

        public string ConnectPOST(string objeto, string Base2)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                            URL_API + Base2,
                            new StringContent(objeto, Encoding.UTF8, "application/json")
                            );
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        return "Ya hay un registro con esa informacion";
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return error.Exceptionmessage;
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string ConnectDELETE(string objeto, string Base2, string codigo)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.DeleteAsync(
                            URL_API + Base2 + codigo);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return "El Registro no se encuentra en la base de datos";
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return error.Exceptionmessage;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string ConnectPUT(string objeto, string Base2, string codigo)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.PutAsync(
                            URL_API + Base2 + codigo,
                            new StringContent(objeto, Encoding.UTF8, "application/json")
                        );
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return "El Registro no se encuentra en nuestra Base de datos";
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return error.Exceptionmessage;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
