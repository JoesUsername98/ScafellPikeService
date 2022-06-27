using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaffelPikeDerivatives.Objects
{
  public class Node<T> where T : IComparable<T> 
  {
    public Node(T data, bool[] path)
    {
      Data = data;
      Path = path;
    }
    public T Data { get; private set; }
    public bool[] Path { get; private set; }
    public int Time { get { return Path.Length; } }
    public Node<T> Previous { get; set; }
    public Node<T> Heads { get; set; }
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
      Node<T> max = this;
      IEnumerable<Node<T>> maxCol = new List<Node<T>>() {max};
      Node <T> currentNode = this;

      while (currentNode != null)
      {
        if(currentNode.Data.CompareTo(max.Data) > 0)
        {
          max = currentNode;
          maxCol = new List<Node<T>>() { max };
        }
        else if (currentNode.Data.CompareTo(max.Data) == 0 && currentNode != this) 
        {
          maxCol = maxCol.Append(currentNode);
        }

          currentNode = currentNode.Previous;
      }

      return maxCol;
    }

    public IEnumerable<Node<T>> MinInPath()
    {
      Node<T> min = this;
      IEnumerable<Node<T>> minCol = new List<Node<T>>() { min };
      Node<T> currentNode = this;

      while (currentNode != null)
      {
        if (currentNode.Data.CompareTo(min.Data) < 0)
        {
          min = currentNode;
          minCol = new List<Node<T>>() { min };
        }
        else if (currentNode.Data.CompareTo(min.Data) == 0 && currentNode != this)
        {
          minCol = minCol.Append(currentNode);
        }

        currentNode = currentNode.Previous;
      }

      return minCol;
    }
  }
}
