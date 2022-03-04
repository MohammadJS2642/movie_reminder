using System;
using System.Collections.Generic;

namespace UserAuth.Models
{
    public partial class UserAuthentication
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
    }
}
