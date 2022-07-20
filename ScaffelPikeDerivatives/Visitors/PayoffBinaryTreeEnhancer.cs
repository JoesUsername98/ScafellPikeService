using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDerivatives.Factory;
using ScaffelPikeDerivatives.Objects;
using ScaffelPikeDerivatives.Objects.Interfaces;

namespace ScaffelPikeDerivatives.Visitors
{
  public class PayoffBinaryTreeEnhancer : IBinaryTreeEnhancer
  {
    private readonly Func<Node<State>, double, double> _payoffMethod;
    private readonly double _strikePrice;

    public PayoffBinaryTreeEnhancer(OptionType optionType, double strikePrice)
    {
      _payoffMethod = GetPayoffStrategy(optionType);
      _strikePrice = strikePrice;
    }

    public void Enhance(BinaryTree<State> subject)
    {
      foreach (var node in subject)
      {
        node.Data.PayOff = _payoffMethod(node, _strikePrice);
      }
    }

    private Func<Node<State>, double, double> GetPayoffStrategy(OptionType type)
    {
      switch (type)
      {
        case OptionType.Call:
          return (x, K) => x.Data.Value - K;
          break;
        case OptionType.Put:
          return (x, K) => K - x.Data.Value;
          break;
        default:
          throw new ArgumentException($"No payoff strategy for type {type}", "type");
      }
    }
  }
}
