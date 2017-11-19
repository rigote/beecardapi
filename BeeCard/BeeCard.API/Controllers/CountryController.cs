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
    public class CountryController: BaseController
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
        [Route("api/countries/")]
        public HttpResponseMessage GetAllCountries([FromUri] string page = null, [FromUri] string size = null)
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
        [Route("api/countries/")]
        public HttpResponseMessage CreateCountry(RequestCountryModel countryModel)
        {
            try
            {
                _countryService.CreateCountry(countryModel.Name);

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
        [Route("api/countries/{countryId}")]
        public HttpResponseMessage UpdateCountry(RequestCountryModel countryModel)
        {
            try
            {
                _countryService.UpdateCountry(countryModel.Id, countryModel.Name, countryModel.Status);

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
        [Route("api/countries/{countryId}")]
        public HttpResponseMessage RemoveCountry(Guid countryId)
        {
            try
            {
                _countryService.RemoveCountry(countryId);

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