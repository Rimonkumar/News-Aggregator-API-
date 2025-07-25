using BLL.DTOs;
using BLL.Services;
using NewsAggregatorAPI.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsAggregatorAPI.Controllers
{
    //[EnableCorsAttribut("*", "*", "*")]
    public class ArticleController : ApiController
    {

        [HttpGet]
        [Route("api/GetArticel")]
        public HttpResponseMessage GetArticel()
        {
            try
            {
                var data = ArticleService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        [Logged]
        [HttpGet]
        
        [Route("api/GetArticel/{id}")]
        public HttpResponseMessage GetArticel(int id)
        {
            try 
            {
                var data = ArticleService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/CreateArticle")]
        public HttpResponseMessage CreateArticle(ArticleDTO article)
        {
            try
            {
                var data = ArticleService.Create(article);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, data);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Article creation failed." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }



        [HttpGet]
        [Route("api/articles/search/{title}")]
        public HttpResponseMessage SearchArticles(string title)
        {
            try
            {
                var data = ArticleService.SearchByTitle(title);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }






    }
}
