using BeeCard.API.Models;
using BeeCard.Application.Interfaces;
using BeeCard.Domain.Entities;
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

        public CompanyController(ICompanyAppService companyService)
        {
            _companyService = companyService;
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
        public HttpResponseMessage CreatePersonalCard(RequestCompanyModel model)
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
        public HttpResponseMessage UpdatePersonalCard(Guid companyId, RequestCompanyModel model)
        {
            try
            {
                _companyService.UpdateCompany(companyId, model.Name, model.Address, model.Address2, model.Number, model.PostalCode, model.Neighborhood, model.City, model.State, model.ContactName, model.ContactEmail, model.ContactPhone, model.Password, model.SubscriptionType, model.SubscriptionPrice, model.SubscriptionDate, model.SubscriptionStatus, model.Logo, model.Website, JsonConvert.SerializeObject(model.SocialNetwork), JsonConvert.SerializeObject(model.CardIdentityConfig), model.PlanId, model.CountryId, model.CompanyTypeId);

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }


        }

        [HttpDelete]
        [Route("api/companies/{companyId}")]
        public HttpResponseMessage RemovePersonalCard(Guid companyId)
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

        [HttpGet]
        [Route("api/companies/")]
        public HttpResponseMessage GetAllCards()
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

    }
}