using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeVigilancia.Common.Database.Models
{
    public class VpnUser
    {
        public int Id { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public byte[] Certificate { get; set; }
    }
}
