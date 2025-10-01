using FluentAssertions;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using Application.Tests;

namespace Application.Tests
{
    public class FlightApplicationSpecifications
    {
        readonly Entities entities = new Entities(new DbContextOptionsBuilder<Entities>()
                                            .UseInMemoryDatabase("Flights")
                                            .Options);
        readonly BookingService BookingService;

        public FlightApplicationSpecifications()
        {
            BookingService = new BookingService(entities: entities);
        }

        [Theory]
        [InlineData("M@n.c"  , 2)]
        [InlineData("a@b.c"  , 4)]
        [InlineData("n@k.com", 1)]
        public void Books_flights(string passengerEmail, int numberOfSeats)
        {
            var flight = new Flight(5);
            entities.Flights.Add(flight);

            BookingService.Book(new BookDto(
                flightId: flight.Id, passengerEmail, numberOfSeats));
            BookingService.FindBookings(flight.Id).Should().ContainEquivalentOf(
                new BookingRm(passengerEmail, numberOfSeats)
                );
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(10)]
        public void Frees_up_number_of_seats_if_booking_canceled(int initialCapacity)
        {
            // Given
            var flight = new Flight(initialCapacity);
            entities.Flights.Add(flight);

            BookingService.Book(new BookDto(
                flightId: flight.Id, passengerEmail: "m@m.co", 2));
            // When
            BookingService.CancelBooking(
                new CancelBookingDto(flightId: flight.Id,
                    passengerEmail: "m@m.co",
                    numberOfSeats: 2));

            // Then
            BookingService.GetRemainingNumberOfSeatsFor(flight.Id)
                .Should().Be(initialCapacity);
        }
    }
}