using Infrastructure.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roboplas.Model.Entities
{
    public class Duty : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? LastDate { get; set; }
        public bool Status { get; set; } = false;
        public int UserId { get; set; }
        [NotMapped]
        public User Users { get; set; }
    }
}
