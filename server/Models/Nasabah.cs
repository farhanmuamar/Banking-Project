using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Nasabah
    {
        [Key]
        public int AccountId { get; set; }
        public string Name { get; set; }
    }
}