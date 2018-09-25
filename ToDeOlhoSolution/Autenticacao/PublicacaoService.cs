using Modelo;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace Autenticacao
{
    public class PublicacaoService
    {
        public Retorno NovaPublicacao(Publicacao publicacao)
        {
            Retorno json = new Retorno();

            try
            {
                string URL = "https://f12xi0nh5j.execute-api.us-east-1.amazonaws.com/dev/publicacoes";
                string DATA = "{\"login\": \"" + publicacao.Login + "\" , " +
                    "\"titulo\" : \"" + publicacao.Titulo + "\" , " +
                    "\"descricao\" : \"" + publicacao.Descricao +"\" , " +
                    "\"latitude\" : \"" + publicacao.Latitude  +"\" , " +
                    "\"longitude\" : \"" + publicacao.Longitude +"\" , "  +
                    "\"image\" : \"" + publicacao.Imagem + "\"}";

                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                client.BaseAddress = new System.Uri(URL);
                byte[] cred = UTF8Encoding.UTF8.GetBytes("username:password");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.Http.HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage messge = client.PostAsync(URL, content).Result;
                string description = string.Empty;
                if (messge.IsSuccessStatusCode)
                {
                    string result = messge.Content.ReadAsStringAsync().Result;
                    json = JsonConvert.DeserializeObject<Retorno>(result);
                }
                else
                {
                    json = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Problemas ao criar publicação. Contacte do administrador!");
            }

            return json;
        }
    }
}
