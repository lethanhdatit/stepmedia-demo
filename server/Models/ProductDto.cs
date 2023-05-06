namespace stepmedia_demo.EntityModels;

public class ProductDto
{
    public long Id { get; set; }

    public long ShopId { get; set; }

    public string Name { get; set; } = null!;

    public double UnitPrice { get; set; }

    public DateTime CreatedDate { get; set; }
}
