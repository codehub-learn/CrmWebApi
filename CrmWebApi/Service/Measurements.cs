using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmWebApi.Service
{
    public class Predictions
    { 
        public static List<WeatherForecast> Predicts { get; set; }
            = new List<WeatherForecast>();



    }
}
