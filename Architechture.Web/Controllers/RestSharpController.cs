using Architecture.Services.RestSharpService;
using Architecture.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architechture.Web.Controllers
{
    public class RestSharpController : Controller
    {
        private readonly IBaseClient _baseClient;
        private readonly IConfiguration _config;

        public RestSharpController(IBaseClient baseClient, IConfiguration config)
        {
            _baseClient = baseClient;
            _config = config;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _baseClient.Send<object, PagedResponse<object>>
                (
                BaseUrl: _config["APISettings:URL"],
                method: RestSharp.Method.GET,
                endPoint: "/api/Category",
                body: null
                );
            return Json(response.Result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Object model)
        {
            SingleResponse<object> response = new SingleResponse<object>();
            try
            {
                if (ModelState.IsValid)
                {
                    response = _baseClient.Send<object, SingleResponse<object>>
                        (
                        BaseUrl: _config["APISettings:URL"],
                        method: RestSharp.Method.POST,
                        endPoint: "/api/Category",
                        body: model
                        );
                    return RedirectToAction("Index");

                }
                else
                {
                    response.Errors.Add(new Error() { ErrorCode = "500", Message = "Some required fields are missing" });
                }
            }
            catch (Exception e)
            {
                response.Errors.Add(new Error() { ErrorCode = "500", ErrorMessage = e.Message });
            }
            return View(model);
        }

    }
}
