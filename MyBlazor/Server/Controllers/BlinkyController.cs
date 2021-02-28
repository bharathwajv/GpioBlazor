using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    public class BlinkyController
    {
        private readonly LedBlinkClient _blinkClient;

        public BlinkyController(LedBlinkClient blinkClient)
        {
            _blinkClient = blinkClient;
        }

        [HttpGet("[action]")]
        public bool IsBlinking()
        {
            return _blinkClient.IsBlinking;
        }

        [HttpGet("[action]")]
        public void StartBlinking()
        {
            _blinkClient.StartBlinking();
        }

        [HttpGet("[action]")]
        public void StopBlinking()
        {
            _blinkClient.StopBlinking();
        }
        [HttpGet("{pinNumber}/{neededQuantity}")]
        public void StartBlinking(int pinNumber, int neededQuantity)
        {
            _blinkClient.StartBlinking(pinNumber, neededQuantity);
        }
    }
}
