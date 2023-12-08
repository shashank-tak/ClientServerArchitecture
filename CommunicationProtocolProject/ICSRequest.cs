using System;
using System.Collections;
namespace CommunicationProtocolProject
{
    public class ISCRequest : CommunicationProtocol
    {
        private Hashtable headerParameters = new Hashtable();
        private const string METHOD = "method";
        public string action;
        public string outputFilePath;
        public ISCRequest()
        {
            this.protocolType = REQUEST;
            headerParameters.Add(METHOD, "");
            this.setHeaders(headerParameters);
        }
    }
}