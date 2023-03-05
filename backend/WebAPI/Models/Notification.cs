namespace WebAPI.Models;

public class Notification
{
    public int Id { get; set; }
    
    public string Description { get; set; }
    
    public string Title { get; set; }
    
    public int ReceiveId { get; set; }
    
    public int SenderId { get; set; }
    
    public bool Invite { get; set; }
}