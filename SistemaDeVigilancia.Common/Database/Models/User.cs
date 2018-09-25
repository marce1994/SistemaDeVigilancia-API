using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeVigilancia.Common.Database.Models
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Certificates { get; set; }
    }
}
