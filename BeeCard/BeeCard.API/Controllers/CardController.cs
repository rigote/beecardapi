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
    public class CardController : BaseController
    {
        private readonly ICardAppService _cardService;        

        public CardController(ICardAppService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        [Route("api/users/{userId}/cards/{cardId}")]
        public HttpResponseMessage GetUserCard(Guid userId, Guid cardId)
        {
            try
            {
                PersonalCard personalCard = null;
                CorporateCard corporateCard = null;

                personalCard = _cardService.GetPersonalCardById(userId, cardId);

                if (personalCard != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new ResponseCardModel(personalCard));

                corporateCard = _cardService.GetCorporateCardById(userId, cardId);

                if (corporateCard != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new ResponseCardModel(corporateCard));

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

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }        

        [HttpPost]
        [Route("api/users/{userId}/cards")]
        public HttpResponseMessage CreatePersonalCard(Guid userId, RequestCardModel model)
        {
            try
            {
                _cardService.CreatePersonalCard(userId, model.AvatarImage, model.FullName, model.Address, model.Address2, model.Number, model.City, model.PostalCode, model.Neighborhood, 
                                                        model.State, model.Phone, model.Cellphone, model.Email, model.Website, JsonConvert.SerializeObject(model.SocialMedias), model.Bio, model.Skills);

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
        [Route("api/users/{userId}/cards/{cardId}")]
        public HttpResponseMessage UpdatePersonalCard(Guid userId, Guid cardId, RequestCardModel model)
        {
            try
            {
                _cardService.UpdatePersonalCard(userId, cardId, model.AvatarImage, model.FullName, model.Address, model.Address2, model.Number, model.City, model.PostalCode, model.Neighborhood, 
                                                        model.State, model.Phone, model.Cellphone, model.Email, model.Website, JsonConvert.SerializeObject(model.SocialMedias), model.Bio, model.Skills, model.Status);

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
        [Route("api/users/{userId}/cards/{cardId}")]
        public HttpResponseMessage RemovePersonalCard(Guid userId, Guid cardId)
        {
            try
            {
                _cardService.RemovePersonalCard(userId, cardId);
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
        [Route("api/users/{userId}/cards")]
        public HttpResponseMessage GetAllUserPersonalCards(Guid userId, [FromUri] string page = "1", [FromUri] string size = "20")
        {
            try
            {
                int _page = 0;
                int _size = 0;

                int.TryParse(page, out _page);
                int.TryParse(size, out _size);

                _page = _page < 1 ? 1 : _page;
                _size = _size > 50 ? 50 : _size;

                var cards = _cardService.GetPersonalCards(userId, _page, _size);

                CollectionModel<ResponseCardModel> response = new CollectionModel<ResponseCardModel>
                {
                    Total = cards.Item1,
                    Items = cards.Item2.Select(c => new ResponseCardModel(c)).ToList(),
                    Page = _page,
                    Size = _size
                };
;

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
        [Route("api/users/{userId}/companies/{companyId}/cards")]
        public HttpResponseMessage GetAllUserCompanyCards(Guid userId, Guid companyId, [FromUri] string page = "1", [FromUri] string size = "20")
        {
            try
            {
                int _page = 0;
                int _size = 0;

                int.TryParse(page, out _page);
                int.TryParse(size, out _size);

                _page = _page < 1 ? 1 : _page;
                _size = _size > 50 ? 50 : _size;

                var cards = _cardService.GetCorporateCards(userId, _page, _size);

                CollectionModel<ResponseCardModel> response = new CollectionModel<ResponseCardModel>
                {
                    Total = cards.Item1,
                    Items = cards.Item2.Select(c => new ResponseCardModel(c)).ToList(),
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
        [Route("api/users/{userId}/companies/{companyId}/cards")]
        public HttpResponseMessage CreateCompanyCard(Guid userId, Guid companyId, RequestCardModel model)
        {
            try
            {
                _cardService.CreateCorporateCard(userId, companyId, model.FullName, model.Occupation, model.Department, model.Phone, model.Cellphone, model.Email, model.Status);

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
        [Route("api/users/{userId}/companies/{companyId}/cards/{cardId}")]
        public HttpResponseMessage UpdateCompanyCard(Guid userId, Guid companyId, Guid cardId, RequestCardModel model)
        {
            try
            {
                _cardService.UpdateCorporateCard(userId, companyId, cardId, model.FullName, model.Occupation, model.Department, model.Phone, model.Cellphone, model.Email, model.Status);

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
        [Route("api/users/{userId}/companies/{companyId}/cards/{cardId}")]
        public HttpResponseMessage RemoveCompanyCard(Guid userId, Guid companyId, Guid cardId)
        {
            try
            {
                _cardService.RemoveCorporateCard(userId, cardId);
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

    }
}
