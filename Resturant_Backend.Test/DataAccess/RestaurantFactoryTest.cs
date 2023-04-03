using Resturant_Backend.DataAccess.Factory;
using Resturant_Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant_Backend.DataAccess.Test
{
    public class UserManagerServiceTest 
    {
        private RestaurantFactory _restaurantFactory;
        public UserManagerServiceTest()
        {
            _restaurantFactory = new RestaurantFactory();
        }

      

        [Fact]
        [Trait("Category", "RestaurantFactory_CreateRestaurant_InitialTuitionFee")]
      
        public void  CreateRestaurant_ConstructInCampusStudent_InitialTuitionFeeMustBe2500()
        {

            // Act 


            //Act && Assert
            Assert.Throws<ArgumentException>(() => _restaurantFactory.CreateRestaurant(null, null));
            Assert.Throws<ArgumentException>(() => _restaurantFactory.CreateRestaurant("", ""));
            Assert.Throws<ArgumentException>(() => _restaurantFactory.CreateRestaurant("آریایی", ""));
            Assert.Throws<ArgumentException>(() => _restaurantFactory.CreateRestaurant("", "08317315779"));

            Assert.Throws<ArgumentException>(() => _restaurantFactory.CreateRestaurant("آریایی", "0831722852"));
            Assert.Throws<ArgumentException>(() => _restaurantFactory.CreateRestaurant("آریایی", "8317228521"));

            Assert.Throws<ArgumentException>(() => _restaurantFactory.CreateRestaurant("آریایی", "0831722852",null,"09187315",null));


        }




    }




}

