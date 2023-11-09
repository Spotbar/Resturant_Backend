using Resturant_Backend.Domain.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Reflection;

namespace Resturant_Backend.Domain.Entities
{
    public class Factor : Base
    {

       /// <summary>
       /// شماره فاکتور
       /// </summary>
        public string? FactorNumber { get; set; }

        /// <summary>
        /// تاریخ فاکتور
        /// </summary>
        public DateTimeOffset FactorDate { get; set; }

        /// <summary>
        /// هرینه پیک
        /// </summary>
        [Required]
        public long DeliveryCost { get; set; }
        /// <summary>
        /// مبلغ فاکتور
        /// </summary>
        [Required]
        public long FactorAmount { get; set; }
      
      
        /// <summary>
        /// هزینه پیک با شرکت
        /// </summary>
        public bool IsDeliveryByCompanyPaid { get; set; }

        /// <summary>
        /// وضعیت فاکتور
        /// </summary>
        public bool IsClosed { get; set; }

        
        /// <summary>
        /// رستوران
        /// </summary>
        [Required]
        public Guid RestaurantId { get; set; }
        /// <summary>
        /// رستوران
        /// </summary>
        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant? Restaurant { get; set; }

        /// <summary>
        /// سفارش ها
        /// </summary>
      //  public  ICollection<Order> Orders { get; set; }




        public Factor()
        {
            
        }
        public Factor(Guid id, string factorNumber,
      DateTimeOffset factorDate,
      long deliveryCost,
      long factorAmount,
      bool isClosed,
      bool isDeliveryByCompanyPaid,
      string restaurantId ,

      ICollection<Order> orders) : base()
        {
            Id = id;
            FactorNumber = factorNumber;
            FactorDate = factorDate;
            DeliveryCost = deliveryCost;
            FactorAmount = factorAmount;
            IsClosed = isClosed;
            IsDeliveryByCompanyPaid = isDeliveryByCompanyPaid;
            RestaurantId = Guid.Parse( restaurantId);
        }
    }
}
