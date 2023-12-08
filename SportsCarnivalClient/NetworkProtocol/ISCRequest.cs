using System;
using System.Collections;

namespace NetworkProtocol
{
    public class ISCRequest : CommunicationProtocol
    {
        private Hashtable headerParameters = new Hashtable();
        private const string METHOD = "method";

        public ISCRequest()
        {
            this.protocolType = REQUEST;
            headerParameters.Add(METHOD, "");
            this.setHeaders(headerParameters);
        }
    }
}
