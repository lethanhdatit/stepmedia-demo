namespace stepmedia_demo.EntityModels;

public class OrderDetailDto
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long OrderId { get; set; }

    public double UnitPrice { get; set; }

    public byte Quantity { get; set; }
}
