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
    public class CountryController: ApiController
    {
        private readonly ICountryAppService _countryService;
        
        public CountryController(ICountryAppService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [Route("api/countries/{countryId}")]
        public HttpResponseMessage GetCountry(Guid countryId)
        {
            try
            {
                Country country = _countryService.GetCountryById(countryId);

                if (country == null)
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

                return Request.CreateResponse(HttpStatusCode.OK, new ResponseCountryModel(country));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }


        [HttpGet]
        [Route("api/countries/")]
        public HttpResponseMessage GetAllCountries([FromUri] string page, [FromUri] string size)
        {
            try
            {
                int _page = 0;
                int _size = 0;

                int.TryParse(page, out _page);
                int.TryParse(size, out _size);

                List<ResponseCountryModel> response = _countryService.GetCountries(_page, _size).Select(c => new ResponseCountryModel(c)).ToList();

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
        [Route("api/countries/")]
        public HttpResponseMessage CreateCountry(RequestCountryModel countryModel)
        {
            try
            {
                _countryService.CreateCountry(countryModel.Name);

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }


        [HttpPut]
        [Route("api/countries/{countryId}")]
        public HttpResponseMessage UpdateCountry(RequestCountryModel countryModel)
        {
            try
            {
                _countryService.UpdateCountry(countryModel.Id, countryModel.Name, countryModel.Status);

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }


        [HttpDelete]
        [Route("api/countries/{countryId}")]
        public HttpResponseMessage RemoveCountry(Guid countryId)
        {
            try
            {
                _countryService.RemoveCountry(countryId);

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }
    }
}