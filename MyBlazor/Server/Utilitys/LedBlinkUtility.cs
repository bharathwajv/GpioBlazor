using MyBlazor.Server.Interfaces;
using System;
using System.Device.Gpio;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlazor.Server
{
    public class LedBlinkUtility : IDisposable, IBlink
    {
        private const int LedPin = 10;

        private bool disposedValue = false;
        private object _locker = new object();
        private bool _isBlinking = false;

        private Task _blinkTask;
        private CancellationTokenSource _tokenSource;
        private CancellationToken _token;

        //public LedBlinkUtility(CancellationTokenSource cts, CancellationToken ct,)
        //{

        //}
        public void StartBlinking()
        {

            if (_blinkTask != null)
            {
                return;
            }

            lock (_locker)
            {
                if (_blinkTask != null)
                {
                    return;
                }

                _tokenSource = new CancellationTokenSource();
                _token = _tokenSource.Token;

                _blinkTask = new Task(() =>
                {
                    using (var controller = new GpioController(PinNumberingScheme.Board))
                    {
                        controller.OpenPin(LedPin, PinMode.Output);

                        _isBlinking = true;
                        Console.WriteLine("Entered printtt");
                        while (true)
                        {
                            if (_token.IsCancellationRequested)
                            {
                                break;
                            }
                            
                            controller.Write(LedPin, PinValue.Low);
                            //Thread.Sleep(LightTimeInMilliseconds);
                            //controller.Write(LedPin, PinValue.Low);
                            //Thread.Sleep(DimTimeInMilliseconds);
                        }

                        _isBlinking = false;
                    }
                });
                _blinkTask.Start();
            }
        }

        public void StopBlinking()
        {
            if (_blinkTask == null)
            {
                return;
            }

            lock (_locker)
            {
                if (_blinkTask == null)
                {
                    return;
                }
                Console.WriteLine("Stoped printinf");
                _tokenSource.Cancel();
                _blinkTask.Wait();
                _isBlinking = false;

                _tokenSource.Dispose();
                _blinkTask.Dispose();

                _tokenSource = null;
                _blinkTask = null;
            }
        }

        public bool IsBlinking
        {
            get { return _isBlinking; }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    StopBlinking();
                }

                disposedValue = true;
            }
        }

        //IDisposable usage
        public void Dispose()
        {
            Dispose(true);
        }

        public void StartBlinking(int pinNumber, int neededQuantity)
        {

                if (_blinkTask != null)
                {
                    return;
                }

                _tokenSource = new CancellationTokenSource();
                _token = _tokenSource.Token;

                  _blinkTask = new Task(() =>
                {
                    using (var controller = new GpioController(PinNumberingScheme.Board))
                    {
                        controller.OpenPin(pinNumber, PinMode.Output);

                        _isBlinking = true;
                        Console.WriteLine("Entered custom");
                        while (true)
                        {
                            if (_token.IsCancellationRequested)
                            {
                                break;
                            }
                            Console.WriteLine("Drop quantity "+neededQuantity);
                            controller.Write(pinNumber, PinValue.Low);
                            Thread.Sleep(neededQuantity);
                            controller.Write(pinNumber, PinValue.High);
                            Thread.Sleep(neededQuantity);
                        }

                        _isBlinking = false;
                    }
                });
                _blinkTask.Start();
            


        }
    }
}
