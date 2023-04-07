namespace Resturant_Backend.Domain.DTO
{
    public class UserRemainingDTO
    {
        public DateTimeOffset CurrentTime { get; set; }
        public int AmountSpent { get; set; }
        public long WalletAmount { get; set; }
        public long Remaining { get { return WalletAmount - AmountSpent; } }
       

    }
}
