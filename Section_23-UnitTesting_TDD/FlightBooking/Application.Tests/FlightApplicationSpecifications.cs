using FluentAssertions;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using Application.Tests;

namespace Application.Tests
{
    public class FlightApplicationSpecifications
    {
        [Theory]
        [InlineData("M@n.c"  , 2)]
        [InlineData("a@b.c"  , 4)]
        [InlineData("n@k.com", 1)]
        public void Books_flights(string passengerEmail, int numberOfSeats)
        {
            var entities = new Entities(new DbContextOptionsBuilder<Entities>()
                .UseInMemoryDatabase("Flights")
                .Options);
            var flight = new Flight(5);
            entities.Flights.Add(flight);

            var BookingService = new BookingService(entities: entities);
            BookingService.Book(new BookDto(
                flightId: flight.Id, passengerEmail, numberOfSeats));
            BookingService.FindBookings(flight.Id).Should().ContainEquivalentOf(
                new BookingRm(passengerEmail, numberOfSeats)
                );
        }

        [Fact]
        public void Cancels_Bookings()
        {
            // Given

            // When

            // Then
        }
    }
}