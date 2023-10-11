using App.Metrics;
using App.Metrics.Counter;

namespace ApplicationInstight
{
    public class MetricsRegistry
    {
        public static CounterOptions CreatedCustomerCounter => new CounterOptions()
        {
            Name = "Created Customers",
            Context = "CustomersApi",
            MeasurementUnit = Unit.Calls
        };
    }
}
