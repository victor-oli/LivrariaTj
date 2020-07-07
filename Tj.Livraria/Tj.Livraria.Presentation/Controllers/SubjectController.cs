using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tj.Livraria.App.Interfacies;
using Tj.Livraria.Domain.Entities;

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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public bool Add(string subjectDescription)
        {
            try
            {
                return _appService.Add(new Subject
                {
                    Description = subjectDescription
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}