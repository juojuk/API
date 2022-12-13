namespace CarApiAiskinimas.Services
{
    public interface ICarLeasingService
    {
        decimal AddPrice(double price, double percent);
        bool CanLease(int carId);
    }
}