using System;

namespace Tj.Livraria.Domain.Exceptions
{
    public class NullOrEmptyException : LibraryException
    {
        public NullOrEmptyException(string message) : base(message) { }
    }
}
