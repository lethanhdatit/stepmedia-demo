namespace stepmedia_demo.EntityModels;

public class ShopDto
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
