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
        public double Cost { get; set; }
        public double AmountCharged { get; set; }

        public double Profit { get; private set; }

        [JsonIgnore]
        public Historic? Historic { get; set; }

        public Receipt() { }

        public Receipt(double cost, double amountCharged)
        {
            Cost = cost;
            AmountCharged = amountCharged;
            ProfitCalculation();
        }

        private void ProfitCalculation()
        {
            Profit = AmountCharged - Cost;
        }
    }
}
