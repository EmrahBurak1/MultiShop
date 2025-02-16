namespace MultiShop.SignalRRealTimeApi.Hubs.Services.SignalRCommentServices
{
    public interface ISignalRCommentService
    {
        Task<int> GetTotalCommentCount();
    }
}
