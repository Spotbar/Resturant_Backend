using Resturant_Backend.Domain.BaseModels;
using System.ComponentModel.DataAnnotations;


namespace Resturant_Backend.Domain.Entities
{
    public class Restaurant : Base
    {
        [Required]
        public  string Name { get; set; }
        [Required]
        public  string Tel { get; set; }

        public string? OpratorName { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public Restaurant(string name , string tel):base()
        {
            Name=name;
            Tel = tel;
        }
        public Restaurant( string name, string tel,string? opratorName ,string? mobile ,string? address) : base()
        {
            Name = name;
            Tel = tel;
            OpratorName = opratorName;
            Mobile = mobile;
            Address = address;
        }
    }
}
