using System;

namespace Chain.NetCore.Optimized
{
    public abstract class Middleware
    {
        private EventHandler<MiddlewareEventArgs> EventHandler;
        public abstract void MiddlewareHandler(object sender, MiddlewareEventArgs e);
        protected Middleware Next { get; set; }

        protected Middleware()
        {
            EventHandler += MiddlewareHandler;
        }

        public void Invoke(MiddlewareEventArgs args)
        {
            OnInvoke(args);
        }

        public virtual void OnInvoke(MiddlewareEventArgs e)
        {
            Console.WriteLine(this.ToString());
            EventHandler?.Invoke(this, e);
        }

        public Middleware Use<TMiddleWare>() where TMiddleWare: Middleware, new ()
        {
           return Next = new TMiddleWare();
        }
    }
}