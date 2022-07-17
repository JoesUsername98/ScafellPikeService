using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDerivatives.Objects.Interfaces;
using ScaffelPikeDerivatives.Objects.Iterators;

namespace ScaffelPikeDerivatives.Objects
{
  [DataContract]
  public class Node<T> : INode<T> where T : IComparable<T>
  {
    public Node(T data, bool[] path)
    {
      Data = data;
      Path = path;
    }
    [DataMember]
    public T Data { get; set; }
    [DataMember]
    public bool[] Path { get; private set; }
    [DataMember]
    public int Time { get { return Path.Length; } }
    [DataMember]
    public Node<T> Previous { get; set; }
    [DataMember]
    public Node<T> Heads { get; set; }
    [DataMember]
    public Node<T> Tails { get; set; }
    public Node<T> GetNext(bool isHeads)
    {
      return isHeads ? Heads : Tails;
    }
    internal void AddNext(Node<T> newNode, bool isNextTossIsHeads)
    {
      newNode.Previous = this;

      if (isNextTossIsHeads)
      {
        if (Heads != null) throw new ArgumentException("Cannot overwrite an existing head node");
        Heads = newNode;
        return;
      }

      if (Tails != null) throw new ArgumentException("Cannot overwrite an existing tails node");
      Tails = newNode;
    }
    public IEnumerable<Node<T>> MaxInPath()
    {
      var maxDataInTree = this.Max(x => x.Data);
      return this.Where(x => x.Data.CompareTo(maxDataInTree) == 0);
    }
    public IEnumerable<Node<T>> MinInPath()
    {
      var minDataInTree = this.Min(x => x.Data);
      return this.Where(x => x.Data.CompareTo(minDataInTree) == 0);
    }
    public int CountSubsequentNodes(Node<T> node)
    {
      if (node is null) return 0;

      return CountSubsequentNodes(node.Tails) + CountSubsequentNodes(node.Heads) + 1;
    }
    public int CountTime(Node<T> node)
    {
      if (node == null) return -1;

      return Math.Max(CountTime(node.Tails), CountTime(node.Heads)) + 1;
    }
    public object Clone()
    {
      var copiedNode = new Node<T>(this.Data, this.Path);
      if (Heads != null)
      {
        copiedNode.Heads = (Node<T>)this.Heads.Clone();
        copiedNode.Heads.Previous = copiedNode;
      }
      if (Tails != null)
      {
        copiedNode.Tails = (Node<T>)this.Tails.Clone();
        copiedNode.Tails.Previous = copiedNode;
      }
      return copiedNode;
    }
    /// <summary>
    /// Returns only the history of the node.
    /// </summary>
    /// <returns></returns>
    public IEnumerator<Node<T>> GetEnumerator() => new NodeReverseOrderIterator<T>(this);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    /// <summary>
    /// Returns the node with foresight. For Tree Traversal
    /// </summary>
    /// <returns></returns>
    public IEnumerator<Node<T>> GetForesightEnumerator() => new NodeInOrderIterator<T>(this);
  }
}
