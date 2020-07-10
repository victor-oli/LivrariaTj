using System;

namespace Tj.Livraria.Domain.Exceptions
{
    public class RelationshipViolationException : LibraryException
    {
        public RelationshipViolationException(string message) : base(message) { }
        public RelationshipViolationException(string message, Exception innerException) : base(message, innerException) { }
    }
}