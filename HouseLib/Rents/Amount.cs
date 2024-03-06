namespace HouseLib.Rents
{
    public class Amount
    {
        public DateOnly startDate;
        public decimal fixedPrice;
        public decimal expense;

        public Amount(DateOnly startDate, decimal fixedPrice, decimal expense)
        {
            this.startDate = startDate;
            this.fixedPrice = fixedPrice;
            this.expense = expense;
        }

        public bool isFacturate(DateOnly date)
        {
            return date.Month == startDate.Month && date.Year == startDate.Year;
        }
        public decimal GlobalFee()
        {
            return fixedPrice + expense;
        }
    }
}