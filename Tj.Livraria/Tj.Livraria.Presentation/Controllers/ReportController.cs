using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tj.Livraria.App.Interfaces;
using Tj.Livraria.Domain.Views;

namespace Tj.Livraria.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReportAppService _appService;

        public ReportController(IReportAppService appService)
        {
            _appService = appService;
        }

        public List<BooksBySubject> GetBooksBySubject()
        {
            try
            {
                return _appService.GetBooksBySubject();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AuthorsBySubject> GetAuthorsBySubject()
        {
            try
            {
                return _appService.GetAuthorsBySubject();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}