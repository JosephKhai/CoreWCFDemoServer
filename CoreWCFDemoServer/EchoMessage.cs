namespace CoreWCFDemoServer
{
    [DataContract]
    public class EchoMessage
    {
        string stringValue = "";

        [DataMember]
        public string Text
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
