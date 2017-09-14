using System;

namespace Chain.NetCore.Optimized
{
    public class MiddleWare2b : Middleware
    {
        public override void MiddlewareHandler(object sender, MiddlewareEventArgs e)
        {
            Console.WriteLine($"{this.ToString()} - Processing Request: {e.Request}");
            Successor?.MiddlewareHandler(this, e);
        }
    }
}