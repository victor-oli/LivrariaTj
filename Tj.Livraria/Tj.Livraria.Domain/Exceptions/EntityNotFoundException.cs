using System;

namespace Tj.Livraria.Domain.Exceptions
{
    public class EntityNotFoundException : LibraryException
    {
        public EntityNotFoundException(string message) : base(message) { }
    }
}
