using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaffelPikeDerivatives.Objects
{
  public class BinaryTree<T>
  {
    private Node<T> _root;
    public int Count;
    public BinaryTree()
    {
      _root = null;
      Count = 0;
    }
    public void Insert(Node<T> newItem)
    {
      if (_root == null)
      {
        _root = newItem;
        Count++;
        return;
      }
      InsertRec(newItem, _root);
    }
    private void InsertRec(Node<T> newNode, Node<T> lastNode)
    {
      var isNextTossIsHeads = newNode.Path[lastNode.Path.Length];
      var nextNode = lastNode.GetNext(isNextTossIsHeads);

      if(nextNode == null)
      {
        lastNode.AddNext(newNode, isNextTossIsHeads);
        Count++;
        return;
      }

      InsertRec(newNode, nextNode);
    }
    public Node<T> GetAt(bool[] path)
    {
      if(path.Length == 0)
      {
        return _root;
      }

      return GetAtRec(_root, path);
    }
    private Node<T> GetAtRec(Node<T> currentNode, bool[] path)
    {
      var isNextTossIsHeads = path[currentNode.Path.Length];

      var nextNode = currentNode.GetNext(isNextTossIsHeads);
      
      if(nextNode == null)
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
    }
  } 
}
