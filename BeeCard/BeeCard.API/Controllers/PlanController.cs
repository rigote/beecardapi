using BeeCard.API.Models;
using BeeCard.Application.Interfaces;
using BeeCard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace BeeCard.API.Controllers
{
    public class PlanController : ApiController
    {

        private readonly IPlanAppService _planService;

        public PlanController(IPlanAppService planService)
        {
            _planService = planService;
        }

        [HttpGet]
        [Route("api/plans/{planId}")]
        public HttpResponseMessage GetPlan(Guid planId)
        {
            try
            {
                Plan plan = _planService.GetPlanById(planId);

                if (plan == null)
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

                return Request.CreateResponse(HttpStatusCode.OK, new ResponsePlanModel(plan));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }


        [HttpGet]
        [Route("api/plans/")]
        public HttpResponseMessage GetAllPlans()
        {
            try
            {
                List<ResponsePlanModel> response = _planService.GetPlans().Select(c => new ResponsePlanModel(c)).ToList();

                if (response == null)
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }



        [HttpPost]
        [Route("api/plans/")]
        public HttpResponseMessage CreateCountry(RequestPlanModel planModel)
        {
            try
            {
                _planService.CreatePlan(planModel.Name, planModel.Description);

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }


        [HttpPut]
        [Route("api/plans/{planId}")]
        public HttpResponseMessage UpdatePlan(Guid planId, RequestPlanModel planModel)
        {
            try
            {
                _planService.UpdatePlan(planId, planModel.Name, planModel.Description, planModel.Status);

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }


        [HttpDelete]
        [Route("api/plans/{planId}")]
        public HttpResponseMessage RemovePlan(Guid planId)
        {
            try
            {
                _planService.RemovePlan(planId);

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }


    }
}