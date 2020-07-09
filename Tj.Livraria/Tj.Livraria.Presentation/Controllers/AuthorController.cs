using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tj.Livraria.App.Interfacies;
using Tj.Livraria.App.Response;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Exceptions;

namespace Tj.Livraria.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorAppService _appService;

        public AuthorController(IAuthorAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public List<Author> GetAll()
        {
            try
            {
                return _appService.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ResponseBase Add(Author author)
        {
            ResponseBase response = new ResponseBase();

            try
            {
                response.Success = _appService.Add(author);
            }
            catch(LibraryException ex)
            {
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        [HttpPut]
        public ResponseBase Update(Author author)
        {
            ResponseBase response = new ResponseBase();

            try
            {
                response.Success = _appService.Update(author);
            }
            catch (LibraryException ex)
            {
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        [HttpDelete]
        public ResponseBase Delete(int authorCod)
        {
            ResponseBase response = new ResponseBase();

            try
            {
                response.Success = _appService.Delete(authorCod);
            }
            catch (LibraryException ex)
            {
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }
    }
}