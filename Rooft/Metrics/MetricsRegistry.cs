using App.Metrics;
using App.Metrics.Counter;
using App.Metrics.Meter;

namespace Rooft.Metrics
{
    public static class MetricsRegistry
    {
        public static CounterOptions SampleCounter => new CounterOptions
        {
            Name = "Sample Counter",
            MeasurementUnit = Unit.Calls
        };
        public static MeterOptions SampleMeter => new MeterOptions
        {
            Name = "Sample Meter",
            MeasurementUnit = Unit.Warnings
        };
    }
}