namespace Tj.Livraria.Domain.Exceptions
{
    public class FormatException : LibraryException
    {
        public FormatException(string message) : base(message) { }
    }
}