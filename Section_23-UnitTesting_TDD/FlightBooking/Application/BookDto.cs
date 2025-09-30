using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    // Dto - data transfer object
    public class BookDto
    {
        public Guid FlightId { get; set; }
        public string PassengerEmail { get; set; }
        public int NumberOfSeats { get; set; }

        public BookDto(Guid flightId, string passengerEmail, int numberOfSeats)
        {
            FlightId = flightId;
            PassengerEmail = passengerEmail;
            NumberOfSeats = numberOfSeats;
        }
    }
}
