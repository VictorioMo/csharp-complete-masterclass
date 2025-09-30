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

        [Theory]
        [InlineData( 3, 1,  1, 3)]
        [InlineData( 4, 2,  2, 4)]
        [InlineData(10, 6,  4, 8)]
        //[InlineData(13, 3, 10, 2)]
        public void Cancelling_bookings_frees_up_the_seats(
            int initCapacity,
            int numberOfSeatsToBook,
            int numberOfSeatsToCancel,
            int remainingNumberOfSeats)
        {
            // given
            var flight = new Flight(seatCapacity: initCapacity);
            flight.Book(passengerEmail: "paaw@mowa.ii", numberOfSeats: numberOfSeatsToBook);

            // when
            flight.CancelBooking(passengerEmail: "paaw@mowa.ii", numberOfSeats: numberOfSeatsToCancel);

            // then
            flight.RemainingNumberOfSeats.Should().Be(remainingNumberOfSeats);
        }

        [Fact]
        public void Doesnt_cancel_booking_if_email_not_found()
        {
            var flight = new Flight(seatCapacity: 5);
            var error = flight.CancelBooking(passengerEmail: "paaw@mowa.ii", numberOfSeats: 3);
            error.Should().BeOfType<BookingNotFoundError>();
        }

        [Fact]
        public void Returns_null_when_successfully_cancel_booking()
        {
            var flight = new Flight(seatCapacity: 5);
            flight.Book(passengerEmail: "paaw@mowa.ii", numberOfSeats: 3);
            var error = flight.CancelBooking(passengerEmail: "paaw@mowa.ii", numberOfSeats: 3);
            error.Should().BeNull();
        }
    }
}