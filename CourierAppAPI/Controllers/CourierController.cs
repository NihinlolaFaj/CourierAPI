﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CourierAppAPI.services;
using CourierAppAPI.dto;
using Newtonsoft.Json;
using log4net;
using System.Reflection;

namespace CourierAppAPI.Controllers
{
    public class CourierController : ApiController
    {
        private CourierService courierService;
        protected ILog Logger;

        public CourierController()
        {
            courierService = new CourierService();
            Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }


        [ActionName("get-all-names")]
        [HttpPost]
        public HttpResponseMessage GetNames()
        {
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState.Values
                                 from error in item.Errors
                                 select error.ErrorMessage).ToArray();
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { RequestMessage = Request, ReasonPhrase = JsonConvert.SerializeObject(errorList) };
            }
            var resp = courierService.GetListOfAllNames();

            if (resp == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { RequestMessage = Request, ReasonPhrase = "" };
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp, "application/json");
        }

        [ActionName("register-user")]
        [HttpPost]
        public HttpResponseMessage RegisterUser(RegisterUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState.Values
                                 from error in item.Errors
                                 select error.ErrorMessage).ToArray();
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { RequestMessage = Request, ReasonPhrase = JsonConvert.SerializeObject(errorList) };
            }
            var resp = courierService.RegisterUser(dto);

            if (resp == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { RequestMessage = Request, ReasonPhrase = "" };
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp, "application/json");
        }

        [ActionName("get-all-rider-requests")]
        [HttpPost]
        public HttpResponseMessage GetRiderRequests(GetRiderRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState.Values
                                 from error in item.Errors
                                 select error.ErrorMessage).ToArray();
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { RequestMessage = Request, ReasonPhrase = JsonConvert.SerializeObject(errorList) };
            }

            Logger.Info("Values sent from the App are below");
            Logger.Info("Email Address: " + dto.RiderEmail);
            Logger.Info("Branch Code is: " + dto.BranchCode);

            var resp = courierService.GetAllRiderRequests(dto);

            if (resp == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { RequestMessage = Request, ReasonPhrase = "" };
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp, "application/json");
        }

        [ActionName("get-all-mailroom-requests")]
        [HttpPost]
        public HttpResponseMessage GetRequest(GetMailroomRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState.Values
                                 from error in item.Errors
                                 select error.ErrorMessage).ToArray();
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { RequestMessage = Request, ReasonPhrase = JsonConvert.SerializeObject(errorList) };
            }
            var resp = courierService.GetAllMailroomRequests(dto);

            if (resp == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { RequestMessage = Request, ReasonPhrase = "" };
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp, "application/json");
        }

        [ActionName("submit-rider-pickup-request")]
        [HttpPost]
        public HttpResponseMessage SubmitRiderPickupRequest(SubmitRiderPickupRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState.Values
                                 from error in item.Errors
                                 select error.ErrorMessage).ToArray();
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { RequestMessage = Request, ReasonPhrase = JsonConvert.SerializeObject(errorList) };
            }
            var resp = courierService.SubmitRiderPickUp(dto);

            if (resp == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { RequestMessage = Request, ReasonPhrase = "" };
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp, "application/json");
        }

        [ActionName("submit-mailroom-pickup-request")]
        [HttpPost]
        public HttpResponseMessage SubmitMailroomPickupRequest(SubmitMailroomPickupRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState.Values
                                 from error in item.Errors
                                 select error.ErrorMessage).ToArray();
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { RequestMessage = Request, ReasonPhrase = JsonConvert.SerializeObject(errorList) };
            }
            var resp = courierService.SubmitMailroomPickUp(dto);

            if (resp == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { RequestMessage = Request, ReasonPhrase = "" };
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp, "application/json");
        }
    }
}
