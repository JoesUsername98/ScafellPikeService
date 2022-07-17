using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDerivatives.Objects.Interfaces;

namespace ScaffelPikeDerivatives.Objects
{
  [DataContract]
  public class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
  {
    [DataMember]
    private Node<T> _root;
    [DataMember]
    public int Count { get; private set; }
    [DataMember]
    public int Time { get; private set; }
    public BinaryTree()
    {
      _root = null;
      Count = 0;
    }
    public BinaryTree(Node<T> root)
    {
      _root = root;
      Count = 1;
    }
    public void Insert(Node<T> newItem)
    {
      if (_root == null)
      {
        _root = newItem;
        Count++;
        Time = 0;
        return;
      }
      InsertRecursive(newItem, _root);
    }
    private void InsertRecursive(Node<T> newNode, Node<T> lastNode)
    {
      var isNextTossIsHeads = newNode.Path[lastNode.Path.Length];
      var nextNode = lastNode.GetNext(isNextTossIsHeads);

      if (nextNode == null)
      {
        lastNode.AddNext(newNode, isNextTossIsHeads);
        Time = newNode.Path.Length > Time ? newNode.Path.Length : Time;
        Count++;
        return;
      }

      InsertRecursive(newNode, nextNode);
    }
    public Node<T> GetAt(bool[] path)
    {
      if (path.Length == 0)
      {
        return _root;
      }

      return GetAtRecursive(_root, path);
    }
    private Node<T> GetAtRecursive(Node<T> currentNode, bool[] path)
    {
      var nextTossIsHeads = path[currentNode.Path.Length];

      var nextNode = currentNode.GetNext(nextTossIsHeads);

      if (nextNode == null)
      {
        throw new ArgumentException("Could not find a node in this path: " + path, "path");
      }

      if (nextNode.Path.SequenceEqual(path))
        return nextNode;

      return GetAtRecursive(nextNode, path);
    }
    public void Remove(Node<T> node)
    {
      int nodesInSubtree = node.CountSubsequentNodes(node);

      if(node == _root)
      {
        _root = null;
        Count = 0;
        Time = -1;
        return;
      }

      if (node.Path.Last())
        node.Previous.Heads = null;
      else
        node.Previous.Tails = null;

      node.Previous = null;

      Count -= nodesInSubtree;

      Time = _root.CountTime(_root);
    }
    public object Clone() => new BinaryTree<T>((Node<T>)_root.Clone()) { Count = this.Count, Time = this.Time };
    public IEnumerable<Node<T>> MaxInTree() => MaxInTree(_root);
    private IEnumerable<Node<T>> MaxInTree(Node<T> node)
    {
      if (node == null)
      {
        return new List<Node<T>>() { };
      }

      IEnumerable<Node<T>> tailsPath = MaxInTree(node.Tails);
      IEnumerable<Node<T>> headsPath = MaxInTree(node.Heads);

      IEnumerable<Node<T>> max = new List<Node<T>>() { node };
      if (tailsPath.Count() == 0 && headsPath.Count() == 0) // LEAF
      {
        return max;
      }

      if (tailsPath.First().Data.CompareTo(max.First().Data) > 0)
      {
        max = tailsPath;
      }
      else if (tailsPath.First().Data.CompareTo(max.First().Data) == 0)
      {
        max = max.Union(tailsPath);
      }
      if (headsPath.First().Data.CompareTo(max.First().Data) > 0)
      {
        max = headsPath;
      }
      else if (headsPath.First().Data.CompareTo(max.First().Data) == 0)
      {
        max = max.Union(headsPath);
      }
      return max;
    }
    public IEnumerable<Node<T>> MinInTree() => MinInTree(_root);
    private IEnumerable<Node<T>> MinInTree(Node<T> node)
    {
      if (node == null)
      {
        return new List<Node<T>>() { };
      }

      IEnumerable<Node<T>> tailsPath = MinInTree(node.Tails);
      IEnumerable<Node<T>> headsPath = MinInTree(node.Heads);

      IEnumerable<Node<T>> min = new List<Node<T>>() { node };
      if (tailsPath.Count() == 0 && headsPath.Count() == 0) // LEAF
      {
        return min;
      }

      if (tailsPath.First().Data.CompareTo(min.First().Data) < 0)
      {
        min = tailsPath;
      }
      else if (tailsPath.First().Data.CompareTo(min.First().Data) == 0)
      {
        min = min.Union(tailsPath);
      }
      if (headsPath.First().Data.CompareTo(min.First().Data) < 0)
      {
        min = headsPath;
      }
      else if (headsPath.First().Data.CompareTo(min.First().Data) == 0)
      {
        min = min.Union(headsPath);
      }
      return min;
    }
  }
}
