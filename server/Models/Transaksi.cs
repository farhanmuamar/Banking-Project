using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Transaksi
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Nasabah")]
        public int AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }
        public string? DebitCreditStatus { get; set; }
        [Column(TypeName = "Money")]
        public decimal? Amount { get; set; }
    }
}