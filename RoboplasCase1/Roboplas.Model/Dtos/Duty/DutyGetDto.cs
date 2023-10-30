using Infrastructure.Model;
using Roboplas.Model.Dtos.User;

namespace Roboplas.Model.Dtos.Task
{
    public class DutyGetDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? LastDate { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public UserGetDto Users { get; set; }
    }
}
