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
      if (isNextTossIsHeads)
      {
        if (Heads != null) throw new ArgumentException("Cannot overwrite an existing head node");
        Heads = newNode;
        return;
      }

      if (Tails != null) throw new ArgumentException("Cannot overwrite an existing tails node");
      Tails = newNode;
    }

    internal IEnumerable<Node<T>> MaxInPath()
    {
      Node<T> Max = this;
      List < Node < T >> MaxCol = new List<Node<T>>() {Max};
      Node <T> CurrentNode = this;

      while (CurrentNode != null)
      {
        if(CurrentNode.Data.CompareTo(Max.Data) > 0)
        {
          Max = CurrentNode;
          MaxCol = new List<Node<T>>() { Max };
        }
        else if (CurrentNode.Data.CompareTo(Max.Data) == 0) 
        {
          MaxCol.Add(CurrentNode);
        }

          CurrentNode = CurrentNode.Previous;
      }

      return MaxCol;
    }

    internal IEnumerable<Node<T>> MinInPath()
    {
      Node<T> Max = this;
      IEnumerable<Node<T>> MaxCol = new List<Node<T>>() { Max };
      Node<T> CurrentNode = this;

      while (CurrentNode != null)
      {
        if (CurrentNode.Data.CompareTo(Max.Data) > 0)
        {
          Max = CurrentNode;
          MaxCol = new List<Node<T>>() { Max };
        }
        else if (CurrentNode.Data.CompareTo(Max.Data) == 0)
        {
          MaxCol.Append(CurrentNode);
        }

        CurrentNode = CurrentNode.Previous;
      }

      return MaxCol;
    }
  }
}
