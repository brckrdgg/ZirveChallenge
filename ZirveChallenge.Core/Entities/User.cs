using System;
using System.Collections.Generic;
using System.Text;

namespace ZirveChallenge.Core.Entities
{
    public class User
    {
        /// <summary>
        ///Sistem kullanıcı modeli
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
      
        public string Password { get; set; }

    }
}
