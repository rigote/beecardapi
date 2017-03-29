using BeeCard.API.Models;
using BeeCard.Application.Interfaces;
using BeeCard.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeeCard.API.Controllers
{
    public class CardController : ApiController
    {
        private readonly ICardAppService _cardService;

        public CardController(ICardAppService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        [Route("api/users/{userId}/cards/{cardId}")]
        public HttpResponseMessage GetCard(Guid userId, Guid cardId)
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
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }

            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }        

        [HttpPost]
        [Route("api/users/{userId}/cards")]
        public HttpResponseMessage CreatePersonalCard(Guid userId, RequestCardModel model)
        {
            try
            {
                _cardService.CreatePersonalCard(userId, model.AvatarImage, model.FullName, model.Address, model.Phone, model.Cellphone, model.Email, model.Website, JsonConvert.SerializeObject(model.SocialMedias));

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        [HttpPut]
        [Route("api/users/{userId}/cards/{cardId}")]
        public HttpResponseMessage UpdatePersonalCard(Guid userId, Guid cardId, RequestCardModel model)
        {
            try
            {
                _cardService.UpdatePersonalCard(userId, cardId, model.AvatarImage, model.FullName, model.Address, model.Phone, model.Cellphone, model.Email, model.Website, JsonConvert.SerializeObject(model.SocialMedias));

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
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
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/users/{userId}/cards")]
        public HttpResponseMessage GetAllCards(Guid userId)
        {
            try
            {
                List<ResponseCardModel> response = new List<ResponseCardModel>();

                response.AddRange(_cardService.GetPersonalCards(userId).Select(c => new ResponseCardModel(c)).ToList());
                response.AddRange(_cardService.GetCorporateCards(userId).Select(c => new ResponseCardModel(c)).ToList());

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }

    }
}
