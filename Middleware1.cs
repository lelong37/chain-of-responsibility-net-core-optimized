using System;

namespace Chain.NetCore.Optimized
{
    public class MiddleWare1 : Middleware
    {
        public override void MiddlewareHandler(object sender, MiddlewareEventArgs e)
        {
            Next?.MiddlewareHandler(this, e);
        }
    }
}