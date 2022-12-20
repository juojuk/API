using API_mokymai.Models;

namespace API_mokymai.Data
{
    public static class ReservationSet
    {
        public static List<Reservation> reservationList = new List<Reservation>()
        {
            new Reservation(1, new DateTime(2020, 1, 1), null, 2, 1, 1),
            new Reservation(1, new DateTime(2020, 2, 1), null, 2, 1, 1),
            new Reservation(1, new DateTime(2020, 3, 1), null, 2, 1, 1),
            new Reservation(1, new DateTime(2020, 4, 1), null, 2, 1, 1),
            new Reservation(1, new DateTime(2020, 5, 1), null, 2, 1, 1),

        };
         public static List<Reservation> Reservations { get { return reservationList; } set { reservationList = value; } }

    }
}
