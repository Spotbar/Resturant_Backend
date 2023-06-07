using Resturant_Backend.Domain.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_Backend.Domain.Entities
{
    public class Order : Base
    {
        /// <summary>
        /// سفارش
        /// </summary>
        [Required]
        public  string Name { get; set; }
        /// <summary>
        /// مبلغ
        /// </summary>
        [Required]
        public long Cost { get; set; }
        /// <summary>
        /// اشتراکی بدون
        /// </summary>
      
        public bool IsShared { get; set; }
        /// <summary>
        /// وضعیت تایید
        /// </summary>
        public bool IsAccept { get; set; }
        /// <summary>
        /// تاریخ سفارش
        /// </summary>
        public DateTimeOffset OrderDate { get; set; }

        /// <summary>
        /// رستوران
        /// </summary>
        [Required]
        public Guid RestaurantId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant? Restaurant { get; set; }

        /// <summary>
        /// سفارش دهندگان مشترک
        /// </summary>
        public virtual ICollection<UserOrder> UserOrders { get; set; }
    }
}
