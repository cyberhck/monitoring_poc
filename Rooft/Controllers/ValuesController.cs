﻿using System.Collections.Generic;
using App.Metrics;
using App.Metrics.Registry;
using Microsoft.AspNetCore.Mvc;
using Rooft.Metrics;

namespace Rooft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IMetrics _metrics;
        public ValuesController(IMetrics metrics)
        {
            _metrics = metrics;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _metrics.Measure.Counter.Increment(MetricsRegistry.SampleCounter);
            _metrics.Measure.Meter.Mark(MetricsRegistry.SampleMeter);
            System.Threading.Thread.Sleep(200);
            return new string[] {"value1", "value2"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}