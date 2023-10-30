using Infrastructure.Model;

namespace Roboplas.Model.Dtos.User
{
    public class UserPostDto : IDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
