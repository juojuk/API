namespace API_mokymai.Services
{
    public class GuidService : IOperationTransient, IOperationScoped, IOperationSingleton

    {
        private readonly string _operationId;

        public GuidService()
        {
            _operationId = Guid.NewGuid().ToString();
        }

        public string GetOperationId()
        {
            return _operationId;
        }
    }
}
