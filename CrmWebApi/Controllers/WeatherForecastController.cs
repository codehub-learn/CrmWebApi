using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmWebApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CrmWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PredictController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", 
            "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PredictController> _logger;

        public PredictController(ILogger<PredictController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("/hello")]
        public string getHello()
        {
            return "hello to all";
        }

        [HttpGet("/my")]
        public List<WeatherForecast> getMyForecast()
        {
           
            return Predictions.Predicts;
          
        }


        [HttpGet("/my/{id}")]
        public  WeatherForecast  getOneForecast(string id)
        {
            int idd = validateInt(id) ;
            if (idd >= Predictions.Predicts.Count || idd<0) return null;
            return Predictions.Predicts[idd];

        }


        private int  validateInt(string input)
        {
            int idd = 0;
            try {   idd = Int32.Parse(input);}
            catch(Exception e)
            {
                return -1;
            }
            return idd;
        }



        [HttpPost("/my")]
        public WeatherForecast postMyForecast(WeatherForecast wf)
        {
            Predictions.Predicts.Add(wf);
            return wf;

        }




    }
}
