namespace Resturant_Backend.Domain.DTO
{
    public class UserCreditDTO
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }
        public string? OrderName { get; set; }
        public int Amount { get; set; }
        public long WalletAmount { get; set; }


        //public List<Lesson> AttendedLessons { get; set; } = new List<Lesson>();

    }
}
