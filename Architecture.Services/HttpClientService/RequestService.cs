using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Services.HttpClientService
{
    public class RequestService : IRequestService
    {
        private readonly JsonSerializerSettings serializerSettings;
        public RequestService()
        {
            serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
            serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public async Task<TResult> GetAsync<TResult>(string uri, string token = "")
        {
            var httpClient = CreateHttpClient(token);
            var response = await httpClient.GetAsync(uri);
            await HandleResponse(response);
            var serialized = await response.Content.ReadAsStringAsync();
            var result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized, serializerSettings));
            return result;
        }

        public async Task<HttpResponseMessage> GetHttpResponseAsync(string host, string uri, string token = "")
        {
            var httpClient = CreateHttpClient(token, host);
            var response = await httpClient.GetAsync(uri);
            return await Task.Run(() => response);
        }

        public Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "") => PostAsync<TResult, TResult>(uri, data, token);

        public async Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data, string token = "")
        {
            var httpClient = CreateHttpClient(token);
            var serialized = JsonConvert.SerializeObject(data, serializerSettings);
            var response = await httpClient.PostAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json"));
            await HandleResponse(response);
            var responseData = await response.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData, serializerSettings));
        }

        public async Task<HttpResponseMessage> PostHttpResponseAsync<TRequest>(string host, string uri, TRequest data, string token = "", Dictionary<string, string> CustomHeaders = null)
        {
            var httpClient = CreateHttpClient(token, host, CustomHeaders);
            var serialized = JsonConvert.SerializeObject(data, serializerSettings);
            var response = await httpClient.PostAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json"));
            return await Task.Run(() => response);
        }

        public Task<TResult> PutAsync<TResult>(string uri, TResult data, string token = "") => PutAsync<TResult, TResult>(uri, data, token);

        public async Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data, string token = "")
        {
            var httpClient = CreateHttpClient(token);
            var serialized = await Task.Run(() => JsonConvert.SerializeObject(data, serializerSettings));
            var response = await httpClient.PutAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json"));
            var responseData = await response.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData, serializerSettings));
        }

        private HttpClient CreateHttpClient(string token = "", string host = "", Dictionary<string, string> CustomHeaders = null)
        {
            var httpClient = new HttpClient(new HttpClientHandler { UseCookies = false });
            httpClient.BaseAddress = new Uri(host);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
            if (CustomHeaders != null && CustomHeaders.Count > 0)
            {
                AddCustomHeaders(httpClient, CustomHeaders);
            }
            if (!string.IsNullOrEmpty(token))
            {
                if (IsEmail(token))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Email", token);
                }
                else
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }
            return httpClient;
        }

        private bool IsEmail(string email) => new EmailAddressAttribute().IsValid(email);

        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //throw new Exception(content);
                }
                //throw new HttpRequestException(content);
            }
        }
        private void AddCustomHeaders(HttpClient httpClient, Dictionary<string, string> customHeaders)
        {
            customHeaders.ToList().ForEach(x => httpClient.DefaultRequestHeaders.Add(x.Key, x.Value));
        }
    }
}
