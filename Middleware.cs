using System;

namespace Chain.NetCore.Optimized
{
    public abstract class Middleware
    {
        public EventHandler<MiddlewareEventArgs> EventHandler;
        public abstract void MiddlewareHandler(object sender, MiddlewareEventArgs e);

        public Middleware Successor { get; set; }

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
            if (EventHandler != null)
            {
                EventHandler(this, e);
            }
        }

        public Middleware Use<TMiddleWare>() where TMiddleWare: Middleware, new ()
        {
           var middleWare = new TMiddleWare();
           Successor = middleWare;
           return Successor;
        }
    }
}