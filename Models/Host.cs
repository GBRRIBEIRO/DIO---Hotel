using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Hosting.Models
{
    public class Host
    {
        public Host(List<Person> peopleHosted, double pricePerDay, DateTime startingDay, DateTime finishingDay)
        {
            Id = Guid.NewGuid();
            PeopleHosted = peopleHosted;
            PricePerDay = pricePerDay;
            StartingDay = startingDay;
            FinishingDay = finishingDay;
        }
        public Host()
        {
            Id = Guid.NewGuid();
            PeopleHosted = new List<Person>();
        }
        public Guid Id { get; set; }
        public List<Person> PeopleHosted { get; set; }
        public double? PricePerDay { get; set; }
        public DateTime? StartingDay { get; set; } = DateTime.MinValue;
        public DateTime? FinishingDay { get; set; }
        public Room? Room { get; set; }
        public bool haveDiscount => StartingDay > DateTime.Now.AddDays(10);

        public double GetTotalDays()
        {
            return ((DateTime)FinishingDay - (DateTime)StartingDay).TotalDays;
        }
        public double GetPricePerDay()
        {
            PricePerDay = 100;
            if(haveDiscount) PricePerDay = PricePerDay - (PricePerDay * 0.10);
            return (double)PricePerDay;
        }

        public double GetTotalPrice()
        {
            return GetPricePerDay() * GetTotalDays();
        }
        public void AddPerson(Person person) => PeopleHosted.Add(person);
    }
}
