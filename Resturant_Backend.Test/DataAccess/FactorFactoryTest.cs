﻿using Resturant_Backend.DataAccess.Factory;
using Resturant_Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Resturant_Backend.DataAccess.Test
{
    public class FactorFactoryTest
    {
        private FactorFactory _factorFactory;
        public FactorFactoryTest()
        {
            _factorFactory = new FactorFactory();
        }

      

        [Fact]
        [Trait("Category", "FactorFactory_CreateFactor")]
      
        public void CreateFactor()
        {

            // Act 
            Restaurant restaurant = new Restaurant("test", "0918");
            ICollection<Order> orders = new List<Order> { new Order { } } ;
            //Act && Assert
            Assert.Throws<ArgumentException>(() => _factorFactory.CreateFactor(string.Empty,DateTimeOffset.Now,100,200,false,true, string.Empty , null));
            Assert.Throws<ArgumentException>(() => _factorFactory.CreateFactor("100", DateTimeOffset.Now.AddDays(-10), 100, 200, false, true, string.Empty , orders));
            Assert.Throws<ArgumentException>(() => _factorFactory.CreateFactor("100", DateTimeOffset.Now.AddDays(10), -1, -1, false, true, restaurant.Id.ToString(), orders));
            Assert.Throws<ArgumentException>(() => _factorFactory.CreateFactor("100", DateTimeOffset.Now, -1, 200, false, true, restaurant.Id.ToString(), orders));

        

        }




    }




}

