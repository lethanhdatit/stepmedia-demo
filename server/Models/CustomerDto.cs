namespace stepmedia_demo.EntityModels;

public class CustomerDto
{
    public long Id { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public DateTime? DoB { get; set; }

    public DateTime CreatedDate { get; set; }
}
