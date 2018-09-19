using Autenticacao;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace ToDeOlho
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void login_Clicked(object sender, EventArgs e)
        {
            Login login = new Login
            {
                email = Email_entry.Text,
                senha = Senha_entry.Text
            };

            try
            {

                string URL = "http://www.mocky.io/v2/5ba2b2b72f00005c008d2e30";
                string DATA = @"{
                    ""name"": ""Component 2"",
                    ""description"": ""This is a JIRA component"",
                    ""leadUserName"": ""xx"",
                    ""assigneeType"": ""PROJECT_LEAD"",
                    ""isAssigneeTypeValid"": false,
                    ""project"": ""TP""}";

                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                client.BaseAddress = new System.Uri(URL);
                //byte[] cred = UTF8Encoding.UTF8.GetBytes("username:password");
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.Http.HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage messge = client.PostAsync(URL, content).Result;
                string description = string.Empty;
                if (messge.IsSuccessStatusCode)
                {
                    string result = messge.Content.ReadAsStringAsync().Result;
                    Retorno json = JsonConvert.DeserializeObject<Retorno>(result);


                    description = json.status;

                    DisplayAlert("Login", description, "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Login", ex.Message, "OK");
            }


        }
    }

    public class Retorno
    {
        public String status
        {
            get;
            set;
        }
    }
}
