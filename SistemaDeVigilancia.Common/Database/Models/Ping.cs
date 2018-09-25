using System.Net;

namespace SistemaDeVigilancia.Common.Database.Models
{
    public class Ping
    {
        public int Id { get; set; }

        public int Time { get; set; }

        public string IpFrom { get; set; }

        public string IpTo { get; set; }
    }
}
