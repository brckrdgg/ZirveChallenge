using System;
using System.Collections.Generic;
using System.Text;
using ZirveChallenge.Core.Dto;

namespace ZirveChallenge.Core.Helpers
{
    public class ActiveUser
    {
        private static ActiveUser activeUser;
        public string UserName { get; set; }
        public int UserId { get; set; }
      
        public string Token { get; set; }
   

        public static ActiveUser Get()
        {
            return activeUser ?? (activeUser = new ActiveUser());
        }
        public static ActiveUser Set(LoginModel loginModel)
        {
            activeUser = new ActiveUser();
            activeUser.UserName = loginModel.UserName;          
            activeUser.Token = loginModel.Token;
            activeUser.UserId = loginModel.UserId;
            return activeUser;
        }

        private ActiveUser()
        {
        }


    }
}
