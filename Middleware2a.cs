using System;

namespace Chain.NetCore.Optimized
{
    public class MiddleWare2a : Middleware
    {
        public override void MiddlewareHandler(object sender, MiddlewareEventArgs e)
        {
            Console.WriteLine(this.ToString());
            Successor?.MiddlewareHandler(this, e);
        }
    }
}