using System;

namespace Chain.NetCore.Optimized
{
    class Program
    {
        static void Main(string[] args)
        {
            var middleWare1 = new MiddleWare1();

            middleWare1
                .Use(new MiddleWare2())
                .Use(new MiddleWare3());

            var middlewareEventArgs = new MiddlewareEventArgs()
            {
                Requests = new int[] { 2, 5, 14, 22, 18, 3, 27, 20 }
            };

            middleWare1.Invoke(middlewareEventArgs);
        }
    }
}
