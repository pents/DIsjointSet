using System.Collections.Generic;
using Pents.DisjointSet.Abstractions;
using Pents.DisjointSet.Dto;

namespace Pents.DisjointSet
{
    public class DisjointSet<T> : IDisjointSet<T>
    {
        private Dictionary<T, SetScope<T>> _scopes;
        
        public DisjointSet(IReadOnlyList<T> collection)
        {
            Init(collection);
        }
        
        public bool Find(T scope, T item)
        {
            var root1 = GetScopeRoot(_scopes[scope]);
            var root2 = GetScopeRoot(_scopes[item]);

            return root1.Value.Equals(root2.Value);
        }

        public void Union(T item1, T item2)
        {
            var scope1 = _scopes[item1];
            var scope2 = _scopes[item2];
            if (scope1.Equals(scope2))
            {
                return;
            }
            
            var scope1Count = GetScopeCount(scope1);
            var scope2Count = GetScopeCount(scope2);

            if (scope1Count >= scope2Count)
            {
                GetScopeRoot(scope2).Parent = GetScopeRoot(scope1);
            }
            else
            {
                GetScopeRoot(scope1).Parent = GetScopeRoot(scope2);
            }
        }

        private void Init(IReadOnlyList<T> collection)
        {
            var n = collection.Count;
            _scopes = new Dictionary<T, SetScope<T>>();
            for (var i = 0; i < n; ++i)
            {
                _scopes.Add(collection[i], new SetScope<T>(collection[i]));
            }
        }
        
        private SetScope<T> GetScopeRoot(SetScope<T> scope)
        {
            var current = scope;
            while (!current.Value.Equals(current.Parent.Value))
            {
                current = current.Parent;
            }

            return current;
        }

        private int GetScopeCount(SetScope<T> scope)
        {
            int index = 0;
            var curScope = scope;
            while (!curScope.Value.Equals(curScope.Parent.Value))
            {
                curScope = curScope.Parent;
                index++;
            }

            return index;
        }
    }
}