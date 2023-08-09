namespace ProductCRUD.Models;

public class ProductFilter
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal? FromPrice { get; set; }
    public decimal? ToPrice { get; set; }
}
