namespace WebApiEstadios.Services
{

    public interface IService
    {
        dynamic ExecuteJob();
        Guid GetScoped();
        Guid GetSingleton();
        Guid GetTransient();
    }

    public class ServiceScoped
    {
        public Guid guid = Guid.NewGuid();
    }

    public class ServiceSingleton
    {
        public Guid guid = Guid.NewGuid();
    }

    public class ServiceTransient
    {
        public Guid guid = Guid.NewGuid();
    }

    public class ServiceA : IService
    {
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceSingleton serviceSingleton;
        private readonly ServiceTransient serviceTransient;
        private readonly ILogger<ServiceA> logger;

        //Cnstructor
        public ServiceA(ILogger<ServiceA> logger, ServiceTransient serviceTransient, ServiceScoped serviceScoped, ServiceSingleton serviceSingleton)
        {
            this.logger = logger;
            this.serviceScoped = serviceScoped;
            this.serviceSingleton = serviceSingleton;
            this.serviceTransient = serviceTransient;
        }

        public dynamic ExecuteJob() { return "Hola desde el ServiceA"; }

        public Guid GetScoped() { return serviceScoped.guid; }

        public Guid GetSingleton() { return serviceSingleton.guid; }

        public Guid GetTransient() { return serviceTransient.guid; }
    }

    public class ServiceB : IService
    {
        public dynamic ExecuteJob() { return "Hola desde el ServiceB"; }

        public Guid GetScoped() { throw new NotImplementedException(); }

        public Guid GetSingleton() { throw new NotImplementedException(); }

        public Guid GetTransient() { throw new NotImplementedException(); }
    }
}
