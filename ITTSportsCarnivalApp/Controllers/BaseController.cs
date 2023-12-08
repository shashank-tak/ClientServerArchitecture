using ITTSportsCarnivalApp.Models;
using CommunicationProtocolProject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITTSportsCarnivalApp.DataConverter;
using System.IO;
using Exceptions;
using log4net.Config;
using log4net;

namespace ITTSportsCarnivalApp.Controllers
{
    class BaseController
    {
        EventManagerController _eventManagerController = new EventManagerController();
        DataConverterClass _dataConverter = new DataConverterClass();
        private static readonly ILog _logger = LogManager.GetLogger(typeof(BaseController));
        public byte[] HandleRequest(string messageGot, string IP, int PORT)
        {
            try
            {
                var _iscRequest = JsonConvert.DeserializeObject<ISCRequest>(messageGot);
                var requestData = Encoding.ASCII.GetString(_iscRequest.data, 0, _iscRequest.size);
                if (_iscRequest.action == "create_team")
                {
                    var gameModel = JsonConvert.DeserializeObject<GameModel>(requestData);
                    var result = _eventManagerController.CreateTeamForEvents(gameModel, _iscRequest.outputFilePath);
                    _logger.Info("Created Team, sending response.");
                    return ConvertIntoICSResponse(result, IP, PORT);
                }
                else if (_iscRequest.action.StartsWith("get_team"))
                {
                    var gametypeId = _iscRequest.action.Last();
                    var Teams = _eventManagerController.GetTeams(Convert.ToInt32(gametypeId.ToString()), _iscRequest.outputFilePath);
                    if (Teams >= 0)
                    {
                        return ConvertIntoICSResponse(1, IP, PORT);
                    }
                    if (Teams < 0)
                    {
                        _logger.Info("Error in fetching teams Invalid game Id passed.");
                    }                                   
                }
                return ConvertIntoICSResponse(0, IP, PORT);
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                return ConvertIntoICSResponse(0, IP, PORT);
            }
        }
        private byte[] ConvertIntoICSResponse(int response, String IP, int PORT)
        {
            Response _response = new Response()
            {
                Type = response>0 ? "Success":"Error",
                Message = response > 0 ? "Success in performing action.":"Error in performing action."
            };
            byte[] replyData = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(_response));
            ISCRequest _icsResponse = new ISCRequest()
            {
                size = replyData.Length,
                data = replyData,
                sourceIp = IP,
                sourcePort = PORT,
                destIp = IP,
                destPort = PORT,
            };
            return Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(_icsResponse));
        }
    }
}
