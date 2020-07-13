using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tj.Livraria.App.Interfacies;
using Tj.Livraria.App.Response;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Exceptions;

namespace Tj.Livraria.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookAppService _appService;

        public BookController(IBookAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public List<Book> GetAll()
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

        [HttpGet]
        public Book Get(int cod)
        {
            try
            {
                return _appService.Get(cod);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ResponseBase Add(Book book)
        {
            ResponseBase response = new ResponseBase();

            try
            {
                response.Success = _appService.Add(book);
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

        [HttpPut]
        public ResponseBase Update(Book book)
        {
            ResponseBase response = new ResponseBase();

            try
            {
                response.Success = _appService.Update(book);
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
        public ResponseBase Delete(int bookCod)
        {
            ResponseBase response = new ResponseBase();

            try
            {
                response.Success = _appService.Delete(bookCod);
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

        [HttpGet]
        public Book GetWithRelationship(int bookCod, bool addAuthor = false, bool addSubject = false)
        {
            try
            {
                return _appService.Get(bookCod, addAuthor, addSubject);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}