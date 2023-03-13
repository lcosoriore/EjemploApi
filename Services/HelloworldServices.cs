namespace EjemploApi.Services
{
    public class HelloworldServices: IHelloworldServices
    {
        public string GetHelloWorld()
        {
            return "Hello World, Dependence Inyection";
        }
    }
}
