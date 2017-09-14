using System;

namespace Chain.NetCore.Optimized
{
    public class MiddleWare2 : Middleware
    {
        public override void MiddlewareHandler(object sender, MiddlewareEventArgs e)
        {
            Console.WriteLine(this.ToString());

            var middleWare2a = new MiddleWare2a();

            middleWare2a
                .Use<MiddleWare2b>()
                .Use<MiddleWare2c>();

            foreach (int request in e.Requests)
            {
                var middlewareEventArgs = new MiddlewareEventArgs(){ Request = request };
                middleWare2a.Invoke(middlewareEventArgs);
            }

            Next?.MiddlewareHandler(this, e);
        }
    }
}