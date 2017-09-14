using System;

namespace Chain.NetCore.Optimized
{
    class Program
    {
        static void Main(string[] args)
        {
            var middleWare1 = new MiddleWare1();

            middleWare1
                .Use<MiddleWare2>()
                .Use<MiddleWare3>()
                .Use<MiddleWare4>()
                .Use<MiddleWare5>();

            var middlewareEventArgs = new MiddlewareEventArgs()
            {
                Requests = new [] { 2, 5, 14, 22, 18, 3, 27, 20 }
            };

            middleWare1.Invoke(middlewareEventArgs);
        }
    }
}
