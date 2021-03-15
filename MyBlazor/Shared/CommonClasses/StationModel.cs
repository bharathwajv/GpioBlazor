namespace MyBlazor.Shared.CommonClasses
{
    public enum stationStatus { free , busy }
    class StationModel
    {
        public int stationId { get; set; }
        public string stationName { get; set; }
        public stationStatus stationStatus { get; set; }
    }
}
