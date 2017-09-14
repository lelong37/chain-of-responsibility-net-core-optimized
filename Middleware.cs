using System;

namespace Chain.NetCore.Optimized
{
    public abstract class Middleware
    {
        public EventHandler<MiddlewareEventArgs> EventHandler;
        public abstract void MiddlewareHandler(object sender, MiddlewareEventArgs e);

        public Middleware Next { get; set; }

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
            EventHandler?.Invoke(this, e);
        }

        public Middleware Use<TMiddleWare>() where TMiddleWare: Middleware, new ()
        {
           return Next = new TMiddleWare();
        }
    }
}