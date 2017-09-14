# Chain of Responsibility Pattern - .Net Core Optimized

Examples how to implement Chain of Responsibility Pattern Optimized for .Net Core v2.x

#### Program.cs

Creating chain of responsibility

```csharp
var middleWare1 = new MiddleWare1();

middleWare1
    .Use(new MiddleWare2())
    .Use(new MiddleWare3());

var middlewareEventArgs = new MiddlewareEventArgs()
{
    Requests = new int[] { 2, 5, 14, 22, 18, 3, 27, 20 }
};

middleWare1.Invoke(middlewareEventArgs);
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
            .Use(new MiddleWare2b())
            .Use(new MiddleWare2c());

        foreach (int request in e.Requests)
        {
            var middlewareEventArgs = new MiddlewareEventArgs(){ Request = request };
            middleWare2a.Invoke(middlewareEventArgs);
        }

        Successor?.MiddlewareHandler(this, e);
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
```

