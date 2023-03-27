using Resturant_Backend.Domain.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Resturant_Backend.Domain.Entities
{
    public class UserGroup : Base
    {
        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User user { get; set; }


        [Required]
        public Guid GroupId { get; set; }

        [ForeignKey(nameof(GroupId))]
        public virtual Group Group { get; set; }


    }
}
