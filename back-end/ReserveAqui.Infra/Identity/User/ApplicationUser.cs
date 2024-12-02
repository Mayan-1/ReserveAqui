﻿using Microsoft.AspNetCore.Identity;

namespace ReserveAqui.Infra.Identity.User;

public class ApplicationUser : IdentityUser
{
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiryTime { get; set; }
}
