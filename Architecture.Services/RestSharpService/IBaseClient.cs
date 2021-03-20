using RestSharp;
using System.Collections.Generic;

namespace Architecture.Services.RestSharpService
{
    public interface IBaseClient
    {
        K Send<T, K>(string BaseUrl, Method method, string endPoint, T body, Dictionary<string, object> parameters = null, Dictionary<string, object> queryParameters = null, Dictionary<string, object> headers = null);
        IRestResponse Send<T>(string BaseUrl, Method method, string endPoint, T body, Dictionary<string, object> parameters = null, Dictionary<string, object> queryParameters = null, Dictionary<string, object> headers = null);
        byte[] DownloadFile<T>(string BaseUrl, Method method, string endPoint, T body, Dictionary<string, object> parameters = null, Dictionary<string, object> queryParameters = null, Dictionary<string, object> headers = null);
    }
}