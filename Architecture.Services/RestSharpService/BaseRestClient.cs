using Architecture.Entities.Session;
using Architecture.Utility;
using Microsoft.AspNetCore.Http;
using RestSharp;
using System.Collections.Generic;

namespace Architecture.Services.RestSharpService
{

    public class BaseRestClient : IBaseClient
    {
        private readonly Dictionary<string, object> DefaultHeaders;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;

        public BaseRestClient(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            DefaultHeaders = new Dictionary<string, object>();
            _session = _httpContextAccessor.HttpContext.Session;
            MySession sessionObj = _session.Get<MySession>(ArchitectureDefaults.SessionName);
            if (!sessionObj.CheckIsNull())
            {
                DefaultHeaders.Add(TokenEnum.TenantId.ToString(), sessionObj.TenantId);
                DefaultHeaders.Add("Authorization", sessionObj.AuthorizationToken);
            }
        }

        public IRestResponse Send<T>(string BaseUrl, Method method, string endPoint, T body, Dictionary<string, object> parameters = null, Dictionary<string, object> queryParameters = null, Dictionary<string, object> headers = null)
        {
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = GenerateRequest(method, endPoint, body, parameters, queryParameters, ref headers);
            return client.Execute(request);
        }
        public K Send<T, K>(string BaseUrl, Method method, string endPoint, T body, Dictionary<string, object> parameters = null, Dictionary<string, object> queryParameters = null, Dictionary<string, object> headers = null)
        {
            var response = Send(BaseUrl, method, endPoint, body, parameters, queryParameters, headers);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializeDeserializer.JSONStringToObject<K>(response.Content);
            }
            else
            {
                return JsonSerializeDeserializer.JSONStringToObject<K>(response.Content);
            }
            
        }
        public byte[] DownloadFile<T>(string BaseUrl, Method method, string endPoint, T body, Dictionary<string, object> parameters = null, Dictionary<string, object> queryParameters = null, Dictionary<string, object> headers = null)
        {
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = GenerateRequest(method, endPoint, body, parameters, queryParameters, ref headers);
            var response = client.DownloadData(request);
            return response;
        }

        private RestRequest GenerateRequest<T>(Method method, string endPoint, T body, Dictionary<string, object> parameters, Dictionary<string, object> queryParameters, ref Dictionary<string, object> headers)
        {
            RestRequest request = new RestRequest(endPoint, method);
            if (headers.CheckIsNull())
            {
                headers = DefaultHeaders;
            }
            if (!headers.CheckIsNull())
                foreach (var key in headers.Keys)
                {
                    if (headers[key].GetType().ToString().StartsWith("System.Collections.Generics.List"))
                    {
                        request.AddHeader(key, JsonSerializeDeserializer.JsonString(headers[key]));
                    }
                    else
                    {
                        request.AddHeader(key, headers[key].ToString());
                    }
                }
            if (!parameters.CheckIsNull())
                foreach (var key in parameters.Keys)
                {
                    request.AddParameter(key, parameters[key]);
                }
            if (!queryParameters.CheckIsNull())
                foreach (var key in queryParameters.Keys)
                {
                    if (!queryParameters.Values.CheckIsNull() && !queryParameters[key].CheckIsNull())
                    {
                        if (queryParameters[key].GetType().ToString().StartsWith("System.Collections.Generics.List"))
                        {
                            request.AddQueryParameter(key, JsonSerializeDeserializer.JsonString(queryParameters[key]));
                        }
                        else
                        {
                            request.AddQueryParameter(key, queryParameters[key].ToString());
                        }
                    }
                }
            if (!body.CheckIsNull())
            {
                var bodyContent = JsonSerializeDeserializer.JsonString(body);
                if (!bodyContent.CheckIsNull()) // http body (model) parameter
                    request.AddParameter("application/json", bodyContent, ParameterType.RequestBody);
            }

            return request;
        }
    }

}