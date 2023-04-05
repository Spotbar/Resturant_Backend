using Moq;
using Resturant_Backend.Business;
using Resturant_Backend.DataAccess.Factory;
using Resturant_Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant_Backend.Test
{
    public class UserManagerServiceTest
    {
        //private IUserManagerService _userManager;
        //public UserManagerServiceTest(IUserManagerService userManager)
        //{
        //    _userManager =  userManager;
        //}


        public Mock<IUserManagerService> mock = new Mock<IUserManagerService>();

        [Fact]
        [Trait("Category", "Login")]
      
        public  void   Login()
        {

            // Act 
            var model = new DataAccess.Models.Auth.LoginModel() { Username = "3240486611", Password = "S@ber09187315779" };
            var token = new DataAccess.Models.Auth.TokenModel() { Token = "", Expiration = DateTime.Now };
           var login = mock.Setup(p => p.Login(model)).Returns( Task.FromResult(token));
            
                 //Act && Assert
             Assert.NotNull(login);


        }




    }




}

