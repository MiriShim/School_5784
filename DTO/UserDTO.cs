﻿namespace DTO;


public class UserDTO
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string? Email { get; set; }

    public string PasswordDTO { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

}
