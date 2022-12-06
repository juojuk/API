using CarApiAiskinimas.Models;
using CarApiAiskinimas.Models.Dto;

namespace CarApiAiskinimas
{
    public interface ICarAdapter
    {
        public GetCarResult Bind(Car car);
        Car Bind(PostCarRequest car);
        Car Bind(PutCarRequest car);
    }
}