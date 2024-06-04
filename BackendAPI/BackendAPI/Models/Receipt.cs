namespace BackendAPI.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public double AmountCharged { get; set; }

        public double Profit { get; private set; }

        public Historic Historic { get; set; }

        public Receipt() { }

        public Receipt(int id, double cost, double amountCharged, Historic historic)
        {
            Id = id;
            Cost = cost;
            AmountCharged = amountCharged;
            ProfitCalculation();
            Historic = historic;
        }

        private void ProfitCalculation()
        {
            Profit = AmountCharged - Cost;
        }
    }
}
