using System;

namespace Tj.Livraria.Domain.Exceptions
{
    public class LibraryException : Exception
    {
        public LibraryException(string message) : base(message) { }
        public LibraryException(string message, Exception innerException) : base(message, innerException) { }
    }
}