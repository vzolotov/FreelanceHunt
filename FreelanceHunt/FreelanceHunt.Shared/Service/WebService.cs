using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FreelanceHunt.Models;
using Newtonsoft.Json;
using System.Linq;


namespace FreelanceHunt.Service
{
    public class WebService : FreelanceHunt.Service.IWebService
    {
        IConfigService _config;
        public WebService(IConfigService config)
        {
            _config = config;
        }

        #region CreateRequest
        private async Task<string> HttpClientCall(string url, string methodName, HttpMethod httpMethod, string requestString = default(string))
        {
            try
            {
                HttpResponseMessage response = await CreateResponse(url, methodName, httpMethod, requestString);
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return string.Empty;
                }
                string responseAsString = await response.Content.ReadAsStringAsync();
                return responseAsString;
            }
            catch
            {
                return string.Empty;
            }
        }

        private async Task<HttpResponseMessage> CreateResponse(string url, string methodName, HttpMethod httpMethod, string requestString)
        {
            HttpClient httpClient = new HttpClient();
            // Assign the authentication headers
            var signature = HashCreator.GetSHA256Key(url + methodName, _config.Secret, requestString);
            httpClient.DefaultRequestHeaders.Authorization = CreateBasicHeader(_config.Token, signature);
            var request = new HttpRequestMessage(httpMethod, url);
            if (httpMethod == HttpMethod.Post)
            {
                request.Content = new StringContent(requestString, Encoding.UTF8, "application/json");
            }
            HttpResponseMessage response = await httpClient.SendAsync(request);
            return response;
        }

        public AuthenticationHeaderValue CreateBasicHeader(string username, string password)
        {
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(username + ":" + password);
            var res = Convert.ToBase64String(byteArray);
            return new AuthenticationHeaderValue("Basic", res);
        }
        #endregion

        public async Task<string> GetMyMessage()
        {
            var response = await this.HttpClientCall("https://api.freelancehunt.com/threads?filter=new", "GET", HttpMethod.Get);
            return response;
        }

        public async Task<List<Project>> GetProjects()
        {
            var response = await this.HttpClientCall("https://api.freelancehunt.com/projects", "GET", HttpMethod.Get);
            var result = JsonConvert.DeserializeObject<List<Project>>(response);
            return result;
        }

        public async Task<List<Project>> GetProjectsByPage(ushort pageNumber)
        {
            var url = string.Format("https://api.freelancehunt.com/projects?page={0}", pageNumber);
            var response = await this.HttpClientCall(url, "GET", HttpMethod.Get);
            var result = JsonConvert.DeserializeObject<List<Project>>(response);
            return result;
        }

        public async Task<List<Dialog>> GetDialogsByPage(ushort pageNumber)
        {
            var url = string.Format("https://api.freelancehunt.com/threads?page={0}", pageNumber);
            var response = await this.HttpClientCall(url, "GET", HttpMethod.Get);
            var result = JsonConvert.DeserializeObject<List<Dialog>>(response);
            return result;
        }

        public async Task<List<ChatMessage>> GetDialogMessages(ulong threadId)
        {
            var url = string.Format("https://api.freelancehunt.com/threads/{0}", threadId);
            var response = await this.HttpClientCall(url, "GET", HttpMethod.Get);
            var result = JsonConvert.DeserializeObject<List<ChatMessage>>(response);
            return result;
        }

        public async Task<Profile> GetAccountInfo(string login = "me")
        {
            var url = string.Format("https://api.freelancehunt.com/profiles/{0}", login);
            var response = await this.HttpClientCall(url, "GET", HttpMethod.Get);
            var result = JsonConvert.DeserializeObject<Profile>(response);
            return result;
        }

        public async Task<ProjectDetail> GetProjectInfo(ulong projectId)
        {
            var url = string.Format("https://api.freelancehunt.com/projects/{0}", projectId);
            var response = await this.HttpClientCall(url, "GET", HttpMethod.Get);
            var result = JsonConvert.DeserializeObject<ProjectDetail>(response);
            return result;
        }

        public async Task<bool> SetRate(ulong projectId, Rate rateProject)
        {
            rateProject.CurrencyCode = "RUB";
            var request = JsonConvert.SerializeObject(rateProject);
            var url = string.Format("https://api.freelancehunt.com/projects/{0}", projectId);
            var response = await this.CreateResponse(url, "POST", HttpMethod.Post, request);
            string responseAsString = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
