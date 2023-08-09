namespace ProductCRUD.Exceptions;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string message) : base($"Product NOT FOUND with ID: {message}") 
    { 
    
    }
}
