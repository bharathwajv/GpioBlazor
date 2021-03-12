using Microsoft.AspNetCore.Mvc;
using System;
using MyBlazor.Server.Interfaces;

namespace MyBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlinkyController : ControllerBase
    {

        private IBlink _ledBlinkUtility;
        public BlinkyController(IBlink LedBlinkUtility)
        {
            _ledBlinkUtility = LedBlinkUtility;
        }

        [HttpGet("[action]")]
        public bool IsBlinking()
        {
            return _ledBlinkUtility.IsBlinking;
        }

        [HttpGet("[action]")]
        public void StartBlinking()
        {
            _ledBlinkUtility.StartBlinking();
        }

        [HttpGet("[action]")]
        public void StopBlinking()
        {
            _ledBlinkUtility.StopBlinking();
        }
        [HttpPost("[action]/{pinNumber}/{neededQuantity}")]
         public void StartBlinking(int pinNumber, int neededQuantity)
        {
            //_ledBlinkUtility.StopBlinking();
             Console.WriteLine("came in "+pinNumber);
            _ledBlinkUtility.StartBlinking(pinNumber, neededQuantity);
        }
    }
}
