using Infrastructure.Model;

namespace Roboplas.Model.Dtos.User
{
    public class UserGetDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
