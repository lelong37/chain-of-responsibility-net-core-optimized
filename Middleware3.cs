using System;

namespace Chain.NetCore.Optimized
{
    public class MiddleWare3 : Middleware
    {
        public override void MiddlewareHandler(object sender, MiddlewareEventArgs e)
        {
            Console.WriteLine(this.ToString());
            Next?.MiddlewareHandler(this, e);
        }
    }
}