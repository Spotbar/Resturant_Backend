namespace Resturant_Backend.DataAccess.Models
{
    public class UserRemainingModel
    {
        public DateTimeOffset CurrentTime { get; set; }
        public int AmountSpent { get; set; }
        public long WalletAmount { get; set; }
        public long Remaining { get { return WalletAmount - AmountSpent; } }
       

    }
}
