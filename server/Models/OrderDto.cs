namespace stepmedia_demo.EntityModels;

public class OrderDto
{
    public long Id { get; set; }

    public long CustomerId { get; set; }

    public long ShopId { get; set; }

    public DateTime CreatedDate { get; set; }
}
