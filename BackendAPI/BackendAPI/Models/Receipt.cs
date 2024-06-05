using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackendAPI.Models
{
    public class Receipt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Cost { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double AmountCharged { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Profit => AmountCharged - Cost;

        [JsonIgnore]
        public Historic? Historic { get; set; }

        public Receipt() { }

        public Receipt(double cost, double amountCharged)
        {
            Cost = cost;
            AmountCharged = amountCharged;
        }
    }
}
