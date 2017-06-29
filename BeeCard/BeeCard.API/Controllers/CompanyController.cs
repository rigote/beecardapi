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
    public class CompanyController: ApiController
    {
        private readonly ICompanyAppService _companyService;
        private readonly ICompanyTypeAppService _companyTypeService;
        private readonly ICompanyGroupAppService _companyGroupService; 

        public CompanyController(ICompanyAppService companyService,
                                 ICompanyTypeAppService companyTypeService,
                                 ICompanyGroupAppService companyGroupService)
        {
            _companyService = companyService;
            _companyTypeService = companyTypeService;
            _companyGroupService = companyGroupService;
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
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
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
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
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
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
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
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
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
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        [HttpGet]
        [Route("api/companies/")]
        public HttpResponseMessage GetAllCompanies()
        {
            try
            {
                List<ResponseCompanyModel> response = _companyService.GetCompanies().Select(c => new ResponseCompanyModel(c)).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
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
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
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
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
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
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
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
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/companies/types/")]
        public HttpResponseMessage GetAllCompanyTypes()
        {
            try
            {
                List<ResponseCompanyTypeModel> response = _companyTypeService.GetCompanyTypes().Select(c => new ResponseCompanyTypeModel(c)).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }
        
        #region Companies Groups
        [HttpPost]
        [Route("api/companies/{companyId}/groups/")]
        public HttpResponseMessage CreateCompanyGroup(Guid companyId, RequestCompanyGroupModel model)
        {
            try
            {
                _companyGroupService.CreateCompanyGroup(companyId, model.Name, model.Status);

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }


        [HttpGet]
        [Route("api/companies/{companyId}/groups/")]
        public HttpResponseMessage GetAllCompanyGroups(Guid companyId)
        {
            try
            {
                List<ResponseCompanyGroupModel> response = _companyGroupService.GetCompanyGroups(companyId).Select(c => new ResponseCompanyGroupModel(c)).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        [HttpGet]
        [Route("api/companies/{companyId}/groups/{companyGroupId}")]
        public HttpResponseMessage GetCompanyGroup(Guid companyId, Guid companyGroupId)
        {
            try
            {
                CompanyGroup companyGroup = _companyGroupService.GetCompanyGroupById(companyGroupId, companyId);

                if (companyGroup == null)
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

                return Request.CreateResponse(HttpStatusCode.OK, new ResponseCompanyGroupModel(companyGroup));                

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        [HttpDelete]
        [Route("api/companies/{companyId}/groups/{companyGroupId}")]
        public HttpResponseMessage RemoveCompanyGroup(Guid companyId, Guid companyGroupId)
        {
            try
            {
                _companyGroupService.RemoveCompanyGroup(companyGroupId, companyId);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        #endregion
    }
}