using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaffelPikeDerivatives.Objects
{
  public class BinaryTree<T> : ICloneable, IBinaryTree<T> where T : IComparable<T>
  {
    private Node<T> _root;
    public int Count { get; set; }

    public int Time { get; set; }
    public BinaryTree()
    {
      _root = null;
      Count = 0;
    }
    public BinaryTree(Node<T> root)
    {
      _root = root;
      Count = 0;
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
      InsertRec(newItem, _root);
    }
    private void InsertRec(Node<T> newNode, Node<T> lastNode)
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

      InsertRec(newNode, nextNode);
    }
    public Node<T> GetAt(bool[] path)
    {
      if (path.Length == 0)
      {
        return _root;
      }

      return GetAtRec(_root, path);
    }
    private Node<T> GetAtRec(Node<T> currentNode, bool[] path)
    {
      var isNextTossIsHeads = path[currentNode.Path.Length];

      var nextNode = currentNode.GetNext(isNextTossIsHeads);

      if (nextNode == null)
      {
        throw new ArgumentException("Could not find a node in this path: " + path, "path");
      }

      if (nextNode.Path.SequenceEqual(path))
        return nextNode;

      return GetAtRec(nextNode, path);
    }
    public void Remove(Node<T> node)
    {
      if (node.Path.Last())
        node.Previous.Heads = null;
      else
        node.Previous.Tails = null;

      node.Previous = null;

      //MODIFY COUNT 
      //  Travese leaf nodes and count how many are being removed. 
      //  Subrtract that from count

      //MODIFY TIME
      //  Travese rest tree and recalculate Time.
    }
    /// <summary>
    /// Shallow Clone
    /// </summary>
    /// <returns></returns>
    public object Clone()
    {
      return new BinaryTree<T>(_root) { Count = this.Count };
    }
    public BinaryTree<T> DeepClone()
    {
      throw new NotImplementedException();// REQUIRES TRAVERSAL
    }
    public IEnumerable<Node<T>> MaxInTree()
    {
      return MaxInTree(_root);
    }
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
        max.Union(tailsPath);
      }
      if (headsPath.First().Data.CompareTo(max.First().Data) > 0)
      {
        max = headsPath;
      }
      else if (headsPath.First().Data.CompareTo(max.First().Data) == 0)
      {
        max.Union(headsPath);
      }
      return max;
    }
    public IEnumerable<Node<T>> MinInTree()
    {
      return MinInTree(_root);
    }
    private IEnumerable<Node<T>> MinInTree(Node<T> node)
    {
      if (node == null)
      {
        return new List<Node<T>>() { };
      }

      IEnumerable<Node<T>> tailsPath = MaxInTree(node.Tails);
      IEnumerable<Node<T>> headsPath = MaxInTree(node.Heads);

      IEnumerable<Node<T>> min = new List<Node<T>>() { node };
      if (tailsPath.Count() == 0 && headsPath.Count() == 0) // LEAF
      {
        return min;
      }

      if (tailsPath.First().Data.CompareTo(min.First().Data) < 0)
      {
        min = tailsPath;
      } 
      else if(tailsPath.First().Data.CompareTo(min.First().Data) == 0)
      {
        min.Union(tailsPath);
      }
      if (headsPath.First().Data.CompareTo(min.First().Data) < 0)
      {
        min = headsPath;
      }
      else if (headsPath.First().Data.CompareTo(min.First().Data) == 0)
      {
        min.Union(headsPath);
      }
      return min;
    }

    public void Preorder(Node<T> currentNode)
    {
      Console.Write(currentNode.Data + " ");
      Preorder(currentNode.Tails);
      Preorder(currentNode.Heads);
    }
    public void Inorder(Node<T> currentNode)
    {
      if (currentNode == null) return;
      Inorder(currentNode.Tails);
      Console.Write(currentNode.Data + " ");
      Inorder(currentNode.Heads);
    }
    public void Postorder(Node<T> currentNode)
    {
      if (currentNode == null) return;
      Postorder(currentNode.Tails);
      Postorder(currentNode.Heads);
      Console.Write(currentNode.Data + " ");
    }
  }
}
