namespace StoreOnline.Domain.Exceptions;

public class DomainException : Exception // sem uso
{
    public DomainException(string message) : base(message)
    {
    }

    // Método auxiliar para lançar a exceção se uma condição for verdadeira
    public static void When(bool hasError, string message)
    {
        if (hasError)
            throw new DomainException(message);
    }
}