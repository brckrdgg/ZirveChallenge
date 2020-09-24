using System;
using System.Collections.Generic;
using System.Text;

namespace ZirveChallenge.Core.Dto
{
    public class LoginModel
    {
        /// <summary>
        /// Token döndüren Login modeli
        /// </summary>
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }

    }
}
