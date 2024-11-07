namespace CoreWCFDemoServer
{
    public class EchoService : IEchoService
    {


        public string ComplexEcho(EchoMessage message)
        {
            Console.WriteLine(message.Text);
            return message.Text;
        }
    }
}
