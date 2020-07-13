﻿using System.Collections.Generic;
using Tj.Livraria.Domain.Entities;

namespace Tj.Livraria.Domain.Interfaces.Repository
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        Subject GetByDescription(string description);
        List<Subject> GetAllByBookCod(int bookCod);
    }
}