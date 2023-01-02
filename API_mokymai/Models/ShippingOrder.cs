namespace API_mokymai.Models
{
    public class ShippingOrder
    {
        public int Id { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
