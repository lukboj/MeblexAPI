namespace Meblex.ModelsDTO
{
    public class StatisticsDTO
    {
        public int AmountOfOrders { get; set; }
        public int AmountOfShippedOrders { get; set; }
        public int AmountOfNotShippedOrders { get; set; }
        public int AmountOfSoldMebels { get; set; }
        public decimal AmountOfMoneyEarned { get; set; }
    }
}
