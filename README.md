# Disjoint set

My implementation of disjoint set (union find) data structure


## Usage

```C#
// divide collection on separate scopes
var unionFind = new DisjointSet<Node>(nodes);

// check intersections between scopes of given objects
unionFind.Find(Node1, Node2)

// union scopes
unionFind.Union(Node1, Node2)
```
## License
[MIT](https://choosealicense.com/licenses/mit/)