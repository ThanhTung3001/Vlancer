namespace TSoft.TaskManagement.Domain.Dto;

public class UserInfoDto
{
    
    public int Id { get; set; }
    
    public string UserName { get; set; }
    
    public string FullName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Description { get; set; }

    public double Rating { get; set; }

    public string Country { get; set; }

    public string Address { get; set; }
}