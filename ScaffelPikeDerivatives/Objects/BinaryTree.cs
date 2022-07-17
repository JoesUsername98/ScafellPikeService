using System;
using System.Collections;
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

      if (node == _root)
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

      Time = this.Max( x => x.Path.Length);
    }
    public object Clone() => new BinaryTree<T>((Node<T>)_root.Clone()) { Count = this.Count, Time = this.Time };
    public IEnumerable<Node<T>> MaxInTree()
    {
      var maxInTree = this.Max(x => x.Data);
      return this.Where(x => x.Data.CompareTo(maxInTree) == 0);
    }
    public IEnumerable<Node<T>> MinInTree()
    {
      var minInTree = this.Min(x => x.Data);
      return this.Where(x => x.Data.CompareTo(minInTree) == 0);
    }

    public IEnumerator<Node<T>> GetEnumerator()
    {
      return _root.GetForesightEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}
