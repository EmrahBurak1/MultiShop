using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTimeApi.Hubs.Services.SignalRCommentServices;
using MultiShop.SignalRRealTimeApi.Hubs.Services.SignalRMessageServices;

namespace MultiShop.SignalRRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;
        //private readonly ISignalRMessageService _signalMessageService;

        public SignalRHub(ISignalRCommentService signalRService)
        {
            _signalRCommentService = signalRService;
        }

        public async Task SendStatisticCount()
        {
            var getTotalCommentCount = await _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);

        }
    }
}
