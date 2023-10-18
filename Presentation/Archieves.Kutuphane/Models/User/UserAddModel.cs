﻿using Archieves.Kutuphane.Models.Common;

namespace Archieves.Kutuphane.Models.User
{
    public class UserAddModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
    }
}
