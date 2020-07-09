using System;

namespace Tj.Livraria.Domain.Exceptions
{
    public class FormatException : Exception
    {
        public FormatException(string message) : base(message) { }
    }
}