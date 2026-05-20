namespace ProductManagementAPI.Model.Entities;

public class AppLog
{
    public int Id { get; set; }
    public string Message { get; set; }
    public string Level { get; set; }
    public DateTime CreatedAt { get; set; }
}