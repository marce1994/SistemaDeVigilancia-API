using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeVigilancia.Common.Database.Models
{
    public class MovementDetection
    {
        public int Id { get; set; }
        public long TimeStamp { get; set; }
        public string Info { get; set; }
    }
}
