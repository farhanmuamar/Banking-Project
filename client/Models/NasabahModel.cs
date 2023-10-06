using System.ComponentModel.DataAnnotations;

namespace client.Models
{
    public class NasabahModel
    {
        [Key]
        public int AccountId { get; set; }
        public string Name { get; set; }
    }
}