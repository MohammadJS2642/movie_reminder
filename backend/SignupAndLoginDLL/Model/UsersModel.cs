using System;
using System.ComponentModel.DataAnnotations;

namespace SignupAndLoginDLL.Model
{
    public class UsersModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
    }
}