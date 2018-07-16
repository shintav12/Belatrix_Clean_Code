
using System;
using System.Collections.Generic;

namespace CleanCode.LongParameterList
{
    public class LongParameterList
    {
        // Manuel Alzamora, Miguel Salas, JeanPierre Jordan, James Ordinola
        public IEnumerable<Reservation> GetReservations(ReservationFilter reservationFilter)
        {
            if (reservationFilter.DateRange.Datefrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (reservationFilter.DateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetUpcomingReservations(ReservationFilter reservationFilter)
        {
            if (reservationFilter.DateRange.Datefrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (reservationFilter.DateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        private static Tuple<DateTime, DateTime> GetReservationDateRange(DateRange dateRange, ReservationDefinition reservationDefinition)
        {
            if (dateRange.Datefrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public void CreateReservation(DateRange dateRange, int locationId)
        {
            if (dateRange.Datefrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }
    }

    internal class ReservationDefinition
    {
    }

    public class LocationType
    {
    }

    public class DateRange
    {
        public DateTime Datefrom { get; set; }
        public DateTime DateTo { get; set; }
    }

    public class User
    {
        public object Id { get; set; }
    }

    public class Reservation
    {

    }

    public class ReservationRequest
    {
        public int LocationId { get; set; }
    }

    public class ReservationFilter
    {
        public DateRange DateRange { get; set; }
        public User User { get; set; }
        public LocationType LocationType { get; set; }
        public int? LocationId { get; set; }
        public int? CustomerId { get; set; }
    }
        
}
