using MyBlazor.Server.Controllers;
using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlazor.Server
{
    public class LedBlinkClient : IDisposable
    {
        private const int LedPin = 10;
        private const int LightTimeInMilliseconds = 1000;
        private const int DimTimeInMilliseconds = 200;

        private bool disposedValue = false;
        private object _locker = new object();
        private bool _isBlinking = false;

        private Task _blinkTask; 
        private CancellationTokenSource _tokenSource;
        private CancellationToken _token;

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
                            
                            controller.Write(LedPin, PinValue.High);
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

        public void Dispose()
        {
            Dispose(true);
        }

        public void StartBlinking(int pinNumber, int neededQuantity)
        {

            Console.WriteLine(pinNumber);
            Console.WriteLine(neededQuantity);

            GpioController controller = new GpioController(PinNumberingScheme.Board);

            var pin = pinNumber;

            controller.OpenPin(pin, PinMode.Output);

            controller.Write(pin, PinValue.High);
            Thread.Sleep(neededQuantity);
            controller.Write(pin, PinValue.Low);


        }
    }
}
