using BeeCard.API.Models;
using BeeCard.Application.Interfaces;
using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeeCard.API.Controllers
{
    public class CompanyController: BaseController
    {
        private readonly ICompanyAppService _companyService;
        private readonly ICompanyTypeAppService _companyTypeService;
        private readonly ISubscriptionHistoryAppService _subscriptionHistoryService;

        public CompanyController(ICompanyAppService companyService,
                                 ICompanyTypeAppService companyTypeService,
                                 ISubscriptionHistoryAppService subscriptionHistoryService)
        {
            _companyService = companyService;
            _companyTypeService = companyTypeService;
            _subscriptionHistoryService = subscriptionHistoryService;
        }

        [HttpGet]
        [Route("api/companies/{companyId}")]
        public HttpResponseMessage GetCompany(Guid companyId)
        {
            try
            {
                Company company = _companyService.GetCompanyById(companyId);

                if (company == null)
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

                return Request.CreateResponse(HttpStatusCode.OK, new ResponseCompanyModel(company));
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
        [Route("api/companies/")]
        public HttpResponseMessage CreateCompany(RequestCompanyModel model)
        {
            try
            {
                _companyService.CreateCompany(model.Name, model.Address, model.Address2, model.Number, model.PostalCode, model.Neighborhood, model.City, model.State, model.ContactName, model.ContactEmail, model.ContactPhone, model.Password, model.SubscriptionType, model.SubscriptionPrice, model.SubscriptionDate, model.SubscriptionStatus, model.Logo, model.Website, JsonConvert.SerializeObject(model.SocialNetwork), JsonConvert.SerializeObject(model.CardIdentityConfig), model.PlanId, model.CountryId, model.CompanyTypeId);

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
        [Route("api/companies/{companyId}")]
        public HttpResponseMessage UpdateCompany(Guid companyId, RequestCompanyModel model)
        {
            try
            {
                _companyService.UpdateCompany(companyId, model.Name, model.Address, model.Address2, model.Number, model.PostalCode, model.Neighborhood, model.City, model.State, model.ContactName, model.ContactEmail, model.ContactPhone, model.SubscriptionType, model.SubscriptionPrice, model.SubscriptionDate, model.SubscriptionStatus, model.Logo, model.Website, JsonConvert.SerializeObject(model.SocialNetwork), JsonConvert.SerializeObject(model.CardIdentityConfig), model.PlanId, model.CountryId, model.CompanyTypeId, model.Status);

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
        [Route("api/companies/{companyId}")]
        public HttpResponseMessage RemoveCompany(Guid companyId)
        {
            try
            {
                _companyService.RemoveCompany(companyId);
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

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("api/companies/{companyId}/{companyStatus}")]
        public HttpResponseMessage UpdateStatusCompany(Guid companyId, EntityStatus companyStatus)
        {
            try
            {
                _companyService.UpdateStatus(companyId, companyStatus);

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

        [HttpGet]
        [Route("api/companies/")]
        public HttpResponseMessage GetAllCompanies([FromUri] string page = "1", [FromUri] string size = "20")
        {
            try
            {
                int _page = 0;
                int _size = 0;

                int.TryParse(page, out _page);
                int.TryParse(size, out _size);

                _page = _page < 1 ? 1 : _page;
                _size = _size > 50 ? 50 : _size;

                var companies = _companyService.GetCompanies(_page, _size);

                CollectionModel<ResponseCompanyModel> response = new CollectionModel<ResponseCompanyModel>
                {
                    Total = companies.Item1,
                    Items = companies.Item2.Select(c => new ResponseCompanyModel(c)).ToList(),
                    Page = _page,
                    Size = _size
                };

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

        [HttpGet]
        [Route("api/companies/types/{companyTypeId}")]
        public HttpResponseMessage GetCompanyType(Guid companyTypeId)
        {
            try
            {
                CompanyType companyType = _companyTypeService.GetCompanyTypeById(companyTypeId);

                if (companyType == null)
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

                return Request.CreateResponse(HttpStatusCode.OK, new ResponseCompanyTypeModel(companyType));
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
        [Route("api/companies/types/")]
        public HttpResponseMessage CreateCompanyType(RequestCompanyTypeModel model)
        {
            try
            {
                _companyTypeService.CreateCompanyType(model.Name);

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
        [Route("api/companies/types/{companyTypeId}")]
        public HttpResponseMessage UpdateCompanyType(Guid companyTypeId, RequestCompanyTypeModel model)
        {
            try
            {
                _companyTypeService.UpdateCompanyType(companyTypeId, model.Name, model.Status);

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
        [Route("api/companies/types/{companyTypeId}")]
        public HttpResponseMessage RemoveCompanyType(Guid companyTypeId)
        {
            try
            {
                _companyTypeService.RemoveCompanyType(companyTypeId);
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

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/companies/types/")]
        public HttpResponseMessage GetAllCompanyTypes([FromUri] string page = "1", [FromUri] string size = "20")
        {
            try
            {
                int _page = 0;
                int _size = 0;

                int.TryParse(page, out _page);
                int.TryParse(size, out _size);

                _page = _page < 1 ? 1 : _page;
                _size = _size > 50 ? 50 : _size;

                var companyTypes = _companyTypeService.GetCompanyTypes(_page, _size);

                CollectionModel<ResponseCompanyTypeModel> response = new CollectionModel<ResponseCompanyTypeModel>
                {
                    Total = companyTypes.Item1,
                    Items = companyTypes.Item2.Select(c => new ResponseCompanyTypeModel(c)).ToList(),
                    Page = _page,
                    Size = _size
                };
                
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

        [HttpGet]
        [Route("api/companies/{companyId}/subscriptions/history/{subscriptionHistoryId}")]
        public HttpResponseMessage GetAllSubscriptionHistory(Guid companyId, Guid subscriptionHistoryId)
        {
            try
            {
                var subscriptionHistory = _subscriptionHistoryService.GetSubscriptionHistoryById(companyId, subscriptionHistoryId);

                if (subscriptionHistory == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new ResponseSubscriptionHistoryModel(subscriptionHistory));
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
        [Route("api/companies/{companyId}/subscriptions/history/")]
        public HttpResponseMessage GetAllSubscriptionHistory(Guid companyId, [FromUri] string page = "1", [FromUri] string size = "20")
        {
            try
            {
                int _page = 0;
                int _size = 0;

                int.TryParse(page, out _page);
                int.TryParse(size, out _size);

                _page = _page < 1 ? 1 : _page;
                _size = _size > 50 ? 50 : _size;

                var subscriptionHistory = _subscriptionHistoryService.GetAllSubscriptionHistory(companyId, _page, _size);

                CollectionModel<ResponseSubscriptionHistoryModel> response = new CollectionModel<ResponseSubscriptionHistoryModel>
                {
                    Total = subscriptionHistory.Item1,
                    Items = subscriptionHistory.Item2.Select(c => new ResponseSubscriptionHistoryModel(c)).ToList(),
                    Page = _page,
                    Size = _size
                };


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
        [Route("api/companies/{companyId}/subscriptions/history/")]
        public HttpResponseMessage AddSubscriptionHistory(RequestSubscriptionHistoryModel model)
        {
            try
            {
                _subscriptionHistoryService.CreateSubscriptionHistory(model.CompanyID, model.SubscriptionType, model.SubscriptionPrice, model.SubscriptionDate, model.SubscriptionStatus);

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

    }
}