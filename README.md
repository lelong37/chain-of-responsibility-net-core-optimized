<img src="https://user-images.githubusercontent.com/4691404/38285238-ed284f68-3784-11e8-8ab6-d94d51745b9e.png" width="85" /><h1>Chain of Responsibility Pattern - .Net Core Optimized</h1>

Examples how to implement Chain of Responsibility Pattern Optimized for .Net Core v2.x

#### Program.cs

Creating chain of responsibility

```csharp
class Program
{
    static void Main(string[] args)
    {
        var middlewareEventArgs = new MiddlewareEventArgs()
        {
            Requests = new [] { 2, 5, 14, 22, 18, 3, 27, 20 }
        };

        var middleWare1 = new MiddleWare1();

        middleWare1
            .Use<MiddleWare2>()
            .Use<MiddleWare3>()
            .Use<MiddleWare4>()
            .Use<MiddleWare5>();

        middleWare1.Invoke(middlewareEventArgs);
    }
}
```

#### Middleware2.cs

Examplifies if this chain has to iterate of a set of objects, how to do this and pass the object to another chain: Middleware2a -> Middleware2b -> Middleware2c.

```csharp
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

        Successor?.MiddlewareHandler(this, e);
    }
}
```

#### Middleware.cs

```csharp
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
```

#### Chain of Responsibility Workflow in this Example
```
Chain.NetCore.Optimized.MiddleWare1
Chain.NetCore.Optimized.MiddleWare2
Chain.NetCore.Optimized.MiddleWare2a - Processing Request: 2
Chain.NetCore.Optimized.MiddleWare2b - Processing Request: 2
Chain.NetCore.Optimized.MiddleWare2c - Processing Request: 2
Chain.NetCore.Optimized.MiddleWare2a - Processing Request: 5
Chain.NetCore.Optimized.MiddleWare2b - Processing Request: 5
Chain.NetCore.Optimized.MiddleWare2c - Processing Request: 5
Chain.NetCore.Optimized.MiddleWare2a - Processing Request: 14
Chain.NetCore.Optimized.MiddleWare2b - Processing Request: 14
Chain.NetCore.Optimized.MiddleWare2c - Processing Request: 14
Chain.NetCore.Optimized.MiddleWare2a - Processing Request: 22
Chain.NetCore.Optimized.MiddleWare2b - Processing Request: 22
Chain.NetCore.Optimized.MiddleWare2c - Processing Request: 22
Chain.NetCore.Optimized.MiddleWare2a - Processing Request: 18
Chain.NetCore.Optimized.MiddleWare2b - Processing Request: 18
Chain.NetCore.Optimized.MiddleWare2c - Processing Request: 18
Chain.NetCore.Optimized.MiddleWare2a - Processing Request: 3
Chain.NetCore.Optimized.MiddleWare2b - Processing Request: 3
Chain.NetCore.Optimized.MiddleWare2c - Processing Request: 3
Chain.NetCore.Optimized.MiddleWare2a - Processing Request: 27
Chain.NetCore.Optimized.MiddleWare2b - Processing Request: 27
Chain.NetCore.Optimized.MiddleWare2c - Processing Request: 27
Chain.NetCore.Optimized.MiddleWare2a - Processing Request: 20
Chain.NetCore.Optimized.MiddleWare2b - Processing Request: 20
Chain.NetCore.Optimized.MiddleWare2c - Processing Request: 20
Chain.NetCore.Optimized.MiddleWare3
Chain.NetCore.Optimized.MiddleWare4
Chain.NetCore.Optimized.MiddleWare5
```

Thanks to rest of the team: [Tony Sneed](https://github.com/tonysneed) and [Larry Popiel](https://github.com/LawzPopiel).
