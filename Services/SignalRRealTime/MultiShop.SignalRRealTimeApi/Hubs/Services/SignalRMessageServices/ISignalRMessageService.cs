﻿namespace MultiShop.SignalRRealTimeApi.Hubs.Services.SignalRMessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
