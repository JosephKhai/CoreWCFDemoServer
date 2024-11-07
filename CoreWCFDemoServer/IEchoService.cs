namespace CoreWCFDemoServer
{
    [ServiceContract]
    public interface IEchoService
    {

        [OperationContract]
        string ComplexEcho(EchoMessage message);

    }

}
