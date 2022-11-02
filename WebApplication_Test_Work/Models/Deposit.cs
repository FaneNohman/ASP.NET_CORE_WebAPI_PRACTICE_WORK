namespace WebApplication_Test_Work.Models
{
    public class Deposit
    {
        public Guid DepositId { get; set; }
        public string? FromAccount { get; set; }
        public string? ToAccount { get; set; }
        public decimal? SumUSD { get; set; }
        //public decimal? SumKZT { get { return SumUSD * 467.31663m; } }
        //public decimal? SumEUR { get { return SumUSD * 1.009665m; } }
        //public decimal? SumCNY { get { return SumUSD * 7.3007544m; } }
    }
}
