using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Hosting.Models
{
    public class Person
    {
        public Person(string fullName)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
    }
}
