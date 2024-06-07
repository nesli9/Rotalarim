namespace Rotalarim.Entity;

public class User{
    public int UserId { get; set; }
    public string? UserName { get; set;}
    public string? Image { get; set; }

    public List<Post> Posts { get; set; } = new List<Post>(); //tablolar arası ilişkilendirme için kullanılan kodlar.
    public List<Comment> Comments { get; set; } = new List<Comment>();

}
