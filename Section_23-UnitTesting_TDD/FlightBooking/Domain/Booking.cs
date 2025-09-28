using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Booking
    {
        public string Email { get; set; }
        public int NumberOfSeats { get; set; }

        public Booking(string email, int numberOfSeats)
        {
            Email = email;
            NumberOfSeats = numberOfSeats;
        }
    }
}
