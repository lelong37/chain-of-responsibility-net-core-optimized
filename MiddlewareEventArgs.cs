namespace Chain.NetCore.Optimized
{
    public class MiddlewareEventArgs
    {
        public int Request { get; set; }
        
        public int[] Requests { get; set; }
    }
}