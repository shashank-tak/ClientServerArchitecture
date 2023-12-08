using System;
using System.Collections;

namespace NetworkProtocol
{
	public class ICSResponse : CommunicationProtocol
    {
        private Hashtable headerParameters = new Hashtable();
        private const string STATUS = "status";
        private const string ERROR_CODE = "error-code";
        private const string ERROR_MESSAGE = "error-message";

        public ICSResponse()
        {
            this.protocolType = RESPONSE;
            headerParameters.Add(STATUS, "");
            headerParameters.Add(ERROR_CODE, "");
            headerParameters.Add(ERROR_MESSAGE, "");
            this.setHeaders(headerParameters);
        }

        //set different parameters as needed sample given below

        public string getErrorMessage()
        {
            return getValue(ERROR_MESSAGE);
        }

        public void setErrorMessage(string message)
        {
            setValue(ERROR_MESSAGE, message);
        }

        public string getValue(string key)
        {
            Hashtable headers = getHeaders();
            return headers[key].ToString();
        }

        public void setValue(string key, string value)
        {
            headerParameters[key] = value;
            setHeaders(headerParameters);
        }
    }
}
