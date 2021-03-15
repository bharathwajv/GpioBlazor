namespace MyBlazor.Server.Controllers
{
    public class ItemModel
    {
        public int itemID { get; set; }

        public string itemName { get; set; }

        public decimal itemRate { get; set; }

        public int leftAmount { get; set; }

        public int neededQuantity { get; set; }
    }
}