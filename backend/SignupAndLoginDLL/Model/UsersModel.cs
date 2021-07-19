using System;
namespace SignupAndLoginDLL.Model
{
    public class UsersModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
    }
}