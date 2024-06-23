using System;
using System.Collections.Generic;

namespace GamesHUb.Domain.Entity;

public partial class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string MobileNo { get; set; } = null!;

    public virtual ICollection<UserOtp> UserOtps { get; } = new List<UserOtp>();
}
