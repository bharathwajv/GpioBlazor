﻿using Microsoft.AspNetCore.Mvc;
using MyBlazor.Server.Controllers;
using System.Threading.Tasks;

namespace MyBlazor.Server.Interfaces
{
    public interface IItemSender
    {
        public Task<string> SendItemJson(ItemModel item);
        public Task<string> GetItemJson();
        public Task<string> GetStationStatus();
        public Task<string> SendStationStatus(string status);

        public Task<string> DeleteItem(ItemModel item);
    }
}
