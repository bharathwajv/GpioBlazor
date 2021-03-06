using MyBlazor.Server.Controllers;
namespace MyBlazor.Server.Interfaces
{
    public interface IItemSender
    {
        public void SendItemJson(Item item);
    }
}
