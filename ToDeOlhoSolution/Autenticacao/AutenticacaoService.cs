using Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Autenticacao
{
    public class AutenticacaoService
    {
        public LoginRetorno Autenticar(Login login)
        {
            LoginRetorno json = new LoginRetorno();

            try
            {
                string URL = "https://f12xi0nh5j.execute-api.us-east-1.amazonaws.com/dev/login";
                string DATA = "{\"login\": \""+login.email+"\" , \"senha\" : \""+login.senha+"\"}";

                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                client.BaseAddress = new System.Uri(URL);
                byte[] cred = UTF8Encoding.UTF8.GetBytes("username:password");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.Http.HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage messge = client.PutAsync(URL, content).Result;
                string description = string.Empty;
                if (messge.IsSuccessStatusCode)
                {
                    string result = messge.Content.ReadAsStringAsync().Result;
                    json = JsonConvert.DeserializeObject<LoginRetorno>(result, new JsonSerializerSettings
                    {
                        DateFormatString = "yyyy-MM-dd"
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Problemas ao realizar login. Contacte do administrador!");
            }

            return json;
        }
    }
}
