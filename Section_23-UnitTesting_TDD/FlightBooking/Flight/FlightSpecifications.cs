using Domain;
using FluentAssertions;

namespace FlightTest
{
    public class FlightSpecifications
    {
        [Theory]
        [InlineData( 3 , 1 ,  2)]
        [InlineData( 6 , 3 ,  3)]
        [InlineData(10 , 6 ,  4)]
        [InlineData(13 , 3 , 10)]
        public void Booking_Reduces_the_Number_of_Seats(
            int seatCapacity, int numberOfSeats, int remainingNumberOfSeats)
        {
            var flight = new Flight(seatCapacity: seatCapacity);

            flight.Book("passenger1@somemail.com", numberOfSeats);

            flight.RemainingNumberOfSeats.Should().Be(remainingNumberOfSeats);
        }

        [Fact]
        public void Avoid_Overbooking()
        {
            // Given
            var flight = new Flight(seatCapacity: 3);

            // When
            var error = flight.Book("passenger1@somemail.com", 4);

            // Then
            error.Should().BeOfType<OverbookingError>();
        }

        [Fact]
        public void Flight_Booked_Successfully()
        {
            var flight = new Flight(seatCapacity: 3);
            var error = flight.Book("passenger1@somemail.com", 2);
            error.Should().BeNull();
        }

        [Fact]
        public void Remember_Bookings()
        {
            var flight = new Flight(seatCapacity: 150);

            flight.Book(passengerEmail: "passenger1@somemail.com", numberOfSeats: 4);

            flight.BookingList.Should().ContainEquivalentOf(new Booking("passenger1@somemail.com", 4));
        }
    }
}