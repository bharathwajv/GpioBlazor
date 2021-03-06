namespace MyBlazor.Server.Interfaces
{
    public interface IBlink
    {
        bool IsBlinking { get; }
        public void StartBlinking();
        public void StopBlinking();
        public void StartBlinking(int pinNumber, int neededQuantity);
    }
}
