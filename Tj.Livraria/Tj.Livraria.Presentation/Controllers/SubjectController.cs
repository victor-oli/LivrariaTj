﻿using Microsoft.AspNetCore.Mvc;
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
    public class SubjectController : ControllerBase
    {
        private ISubjectAppService _appService;

        public SubjectController(ISubjectAppService appService)
        {
            this._appService = appService;
        }

        [HttpGet]
        public IList<Subject> GetSubjectList()
        {
            try
            {
                return _appService.GetAll();
            }
            catch (LibraryException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error");
            }
        }

        [HttpPost]
        public ResponseBase Add(Subject subject)
        {
            ResponseBase response = new ResponseBase();

            try
            {
                response.Success = _appService.Add(subject);
            }
            catch (LibraryException ex)
            {
                response.Message = ex.Message;
            }
            catch (Exception)
            {
                response.Message = "Internal server error";
            }

            return response;
        }

        [HttpPut]
        public ResponseBase Edit(Subject subject)
        {
            ResponseBase response = new ResponseBase();

            try
            {
                response.Success = _appService.Update(subject);
            }
            catch (LibraryException ex)
            {
                response.Message = ex.Message;
            }
            catch (Exception)
            {
                response.Message = "Internal server error";
            }

            return response;
        }

        [HttpDelete]
        public ResponseBase Delete(int subjectCod)
        {
            ResponseBase response = new ResponseBase();

            try
            {
                response.Success = _appService.Delete(subjectCod);
            }
            catch (LibraryException ex)
            {
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Message = "Internal server error";
            }

            return response;
        }
    }
}