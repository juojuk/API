namespace API_mokymai.Services.XServices
{
    public class BadService : IBadService
    {
        public string DoSomeWork()
        {
            var a = "a";
            var b = int.Parse(a);
            return "Darbas baigtas b=" + b;
        }

    }
}
