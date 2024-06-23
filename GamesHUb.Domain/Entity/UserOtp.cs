using System;
using System.Collections.Generic;

namespace GamesHUb.Domain.Entity;

public partial class UserOtp
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Otp { get; set; }

    public string MobileNo { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
