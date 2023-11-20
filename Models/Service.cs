using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Hosting.Models
{
    public static class Service
    {
        public static List<Host> Hostings { get; set; } = new List<Host>();

        public static void AddHost(Host host) => Hostings.Add(host);
        public static void RemoveHost(Host host) => Hostings.Remove(host);
        public static void UpdateHost(Host host)
        {
            var oldHosting = Hostings.Find((h) => h.Id == host.Id);
            if (oldHosting != null)
            {
                oldHosting = host;
            }
            Hostings.Remove(oldHosting);
            Hostings.Add(host);
        }

       

    }
}
