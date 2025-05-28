namespace UserService.Worker.Models;
public class UserEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }
}