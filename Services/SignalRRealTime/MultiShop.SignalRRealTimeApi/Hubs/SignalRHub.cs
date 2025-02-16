using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTimeApi.Hubs.Services.SignalRCommentServices;
using MultiShop.SignalRRealTimeApi.Hubs.Services.SignalRMessageServices;

namespace MultiShop.SignalRRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;
        private readonly ISignalRMessageService _signalMessageService;

        public SignalRHub(ISignalRCommentService signalRService, ISignalRMessageService signalMessageService)
        {
            _signalRCommentService = signalRService;
            _signalMessageService = signalMessageService;
        }

        public async Task SendStatisticCount()
        {
            string id = "1";
            var getTotalCommentCount = _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);

            var getTotalMessageCount = _signalMessageService.GetTotalMessageCountByReceiverId(id);
            await Clients.All.SendAsync("ReceiveMessageCount", getTotalMessageCount);
        }
    }
}
