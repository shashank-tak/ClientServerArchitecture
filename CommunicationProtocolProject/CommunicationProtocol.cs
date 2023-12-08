using System;
using System.Collections;

namespace CommunicationProtocolProject
{
    public class CommunicationProtocol
    {
        public int size;
        public string REQUEST = "request";
        public string RESPONSE = "response";
        public byte[] data;
        public string protocolVersion;
        public string protocolFormat;
        public string protocolType;
        public string sourceIp;
        public int sourcePort;
        public string destIp;
        public int destPort;
        public Hashtable headers;
        public void setHeaders(Hashtable headers)
        {
            this.headers = headers;
        }
        public Hashtable getHeaders()
        {
            return headers;
        }
    }
}