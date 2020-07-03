using System;

namespace Tj.Livraria.Domain.Exceptions
{
    public class NullOrEmptyException : Exception
    {
        public NullOrEmptyException(string message) : base(message) { }
    }
}
