namespace Domain
{
    public class Flight
    {
        private List<Booking> _bookingList = new();

        public IEnumerable<Booking> BookingList => _bookingList;
        public int RemainingNumberOfSeats { get; set; }

        public Flight(int seatCapacity)
        {
            RemainingNumberOfSeats = seatCapacity;
        }

        public object? Book(string passengerEmail, int numberOfSeats)
        {
            if (numberOfSeats > RemainingNumberOfSeats)
            {
                return new OverbookingError();
            }

            _bookingList.Add(new Booking(passengerEmail, numberOfSeats));
            RemainingNumberOfSeats -= numberOfSeats;

            return null;
        }
    }
}
