using Architecture.Services.HttpClientService;
using Architecture.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Architechture.Web.Controllers
{
    public class HttpClientController : BaseHttpClientController
    {
        private readonly IRequestService _requestService;

        public HttpClientController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        /// <summary>
        /// GET response
        /// </summary>
        /// <param name="portfolioId"></param>
        /// <returns></returns>
        ///
        [Route("api/{Id}")]
        [HttpGet]
        public async Task<IActionResult> GetAsync(string Id)
        {
            ApiResponse<object> apiResponse = new ApiResponse<object>();
            try
            {
                var postResponse = await _requestService.GetHttpResponseAsync(
                    host: "",
                    uri: $"{""}/{""}",
                    token: Request.Headers["Authorization"]);

                return GenerateResponse(apiResponse, postResponse, await postResponse.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return ErrorResponse(apiResponse, ex);
            }
        }
        /// <summary>
        /// POST response
        /// </summary>
        /// <param name="closePortfolioRequest"></param>
        /// <param name="portfolioId"></param>
        /// <returns></returns>
        [Route("api/{Id}")]
        [HttpPost]
        public async Task<IActionResult> ClosePostAsync(object model, string Id)
        {
            ApiResponse<object> apiResponse = new ApiResponse<object>();
            try
            {
                var postResponse = await _requestService.PostHttpResponseAsync(
                    host: "",
                    uri: $"{""}/{""}",
                    data: model,
                    token: Request.Headers["Authorization"].ToString());

                return GenerateResponse(apiResponse, postResponse, await postResponse.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return ErrorResponse(apiResponse, ex);
            }
        }
    }
    public class BaseHttpClientController : Controller
    {
        protected static IActionResult GenerateResponse<T>(ApiResponse<T> apiResponse, HttpResponseMessage postResponse, string data)
        {
            apiResponse.statusCode = postResponse.StatusCode;
            if (postResponse.IsSuccessStatusCode)
            {
                //De-serializing the response received from api
                T dataToPost = JsonSerializeDeserializer.JSONStringToObject<T>(data);
                apiResponse.result = dataToPost;
                apiResponse.timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
                apiResponse.message = "success";
                return new ObjectResult(apiResponse)
                {
                    StatusCode = (int)postResponse.StatusCode
                };
                //actionContext.Request.CreateResponse(postResponse.StatusCode, apiResponse);
            }
            else if (postResponse.Content.Headers.ContentType.MediaType == new MediaTypeHeaderValue("text/html").MediaType)
            {
                //De-serializing the response received from api
                apiResponse.message = data;
                apiResponse.timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
                return new ObjectResult(apiResponse)
                {
                    StatusCode = (int)postResponse.StatusCode
                };
            }
            else
            {
                //De-serializing the response received from api
                object errorResponse = JsonSerializeDeserializer.JSONStringToObject<object>(data);
                //apiResponse.message = errorResponse.message;
                //apiResponse.timestamp = errorResponse.timestamp;
                return new ObjectResult(apiResponse)
                {
                    StatusCode = (int)postResponse.StatusCode
                };
            }
        }

        protected static IActionResult GenerateResponse<T>(ApiResponse<T> apiResponse, T response)
        {
            apiResponse.result = response;
            apiResponse.timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
            apiResponse.message = "success";
            return new ObjectResult(apiResponse)
            {
                StatusCode = 200
            };
        }

        protected static IActionResult GenerateResponseId<T>(ApiResponse<T> apiResponse, T response)
        {
            apiResponse.result = response;
            var apiResponseId = response;
            apiResponse.timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
            apiResponse.message = "success";
            return new ObjectResult(apiResponse)
            {
                StatusCode = 200
            };
        }

        protected static IActionResult ErrorResponse<T>(ApiResponse<T> apiResponse, Exception ex)
        {
            apiResponse.statusCode = HttpStatusCode.InternalServerError;
            apiResponse.message = ex.Message + " | Inner Exception:" + ex.InnerException?.Message;
            return new ObjectResult(apiResponse)
            {
                StatusCode = 200
            };
        }
        public class ApiResponse<T>
        {
            public HttpStatusCode statusCode { get; set; }
            public string message { get; set; }
            public T result { get; set; }
            public string timestamp { get; set; }
        }
    }
}
