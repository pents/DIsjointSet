using Pents.DisjointSet.Dto;

namespace Pents.DisjointSet.Abstractions
{
    public interface IDisjointSet<T>
    {
        bool Find(T scope, T item);
        void Union(T item1, T item2);
    }
    
}