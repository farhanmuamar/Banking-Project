using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Point
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public int TotalPoint { get; set; }
    }
}