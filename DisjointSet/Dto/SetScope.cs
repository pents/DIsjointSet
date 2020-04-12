namespace Pents.DisjointSet.Dto
{
    public class SetScope<T>
    {
        public SetScope(T value)
        {
            Value = value;
            Parent = this;
        }
        
        public T Value { get;}
        public SetScope<T> Parent { get; set; }
    }
}