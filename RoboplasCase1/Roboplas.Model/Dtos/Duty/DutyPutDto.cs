using Infrastructure.Model;

namespace Roboplas.Model.Dtos.Task
{
    public class DutyPutDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? LastDate { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
    }
}
