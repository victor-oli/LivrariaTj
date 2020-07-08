using System;

namespace Tj.Livraria.Domain.Exceptions
{
    public class AlreadyExistsException : LibraryException
    {
        public AlreadyExistsException(string message) : base(message) { }
    }
}