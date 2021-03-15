using MyBlazor.Server.Controllers;

namespace MyBlazor.Shared.CommonClasses
{
    public enum orderStatus { ordered, sent, completed }
    class OrderModel
    {
        public ItemModel item { get; set; }
        public orderStatus orderStatus { get; set; }
    }
}
