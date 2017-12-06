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
    public class PlanController : BaseController
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
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "NotFound")
                    return SendResponse(HttpStatusCode.NotFound);
                else
                    return SendResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return SendResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/plans/")]
        public HttpResponseMessage GetAllPlans([FromUri] string page = "1", [FromUri] string size = "20")
        {
            try
            {
                int _page = 0;
                int _size = 0;

                int.TryParse(page, out _page);
                int.TryParse(size, out _size);

                _page = _page < 1 ? 1 : _page;
                _size = _size > 50 ? 50 : _size;

                var plans = _planService.GetPlans(_page, _size);

                CollectionModel<ResponsePlanModel> response = new CollectionModel<ResponsePlanModel>
                {
                    Total = plans.Item1,
                    Items = plans.Item2.Select(c => new ResponsePlanModel(c)).ToList(),
                    Page = _page,
                    Size = _size
                };

                if (response == null)
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "NotFound")
                    return SendResponse(HttpStatusCode.NotFound);
                else
                    return SendResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return SendResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/plans/")]
        public HttpResponseMessage CreatePlan(RequestPlanModel planModel)
        {
            try
            {
                _planService.CreatePlan(planModel.Name, planModel.Description);

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "NotFound")
                    return SendResponse(HttpStatusCode.NotFound);
                else
                    return SendResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return SendResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/plans/{planId}")]
        public HttpResponseMessage UpdatePlan(RequestPlanModel planModel)
        {
            try
            {
                _planService.UpdatePlan(planModel.Id, planModel.Name, planModel.Description, planModel.Status);

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "NotFound")
                    return SendResponse(HttpStatusCode.NotFound);
                else
                    return SendResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return SendResponse(HttpStatusCode.InternalServerError, ex.Message);
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
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "NotFound")
                    return SendResponse(HttpStatusCode.NotFound);
                else
                    return SendResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return SendResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}