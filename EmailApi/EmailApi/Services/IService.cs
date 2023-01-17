namespace EmailApi.Services
{
    public interface IService
    {
        void Send(string message,string recipient);
    }
}
