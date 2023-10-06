using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace client.Models
{
    public class PointModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Transaksi")]
        public int TransaksiID { get; set; }
        public int TotalPoint { get; set; }
    }
}