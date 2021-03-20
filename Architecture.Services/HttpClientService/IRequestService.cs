using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Services.HttpClientService
{
    public interface IRequestService
    {
        Task<HttpResponseMessage> GetHttpResponseAsync(string host, string uri, string token = "");

        Task<HttpResponseMessage> PostHttpResponseAsync<TResult>(string host, string uri, TResult data, string token = "", Dictionary<string, string> CustomHeaders = null);

        Task<TResult> GetAsync<TResult>(string uri, string token = "");

        Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "");

        Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data, string token = "");

        Task<TResult> PutAsync<TResult>(string uri, TResult data, string token = "");

        Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data, string token = "");
    }
}
