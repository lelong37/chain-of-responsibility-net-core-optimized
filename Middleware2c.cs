using System;

namespace Chain.NetCore.Optimized
{
    public class MiddleWare2c : Middleware
    {
        public override void MiddlewareHandler(object sender, MiddlewareEventArgs e)
        {
            Console.WriteLine($"{this.ToString()} - Processing Request: {e.Request}");
            Next?.MiddlewareHandler(this, e);
        }
    }
}