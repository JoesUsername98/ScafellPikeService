using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDerivatives.Factory;
using ScaffelPikeDerivatives.Objects;
using ScaffelPikeDerivatives.Objects.Enums;

namespace ScaffelPikeDerivatives.Visitors
{
  /// <summary>
  /// TODO: add pattern here
  /// </summary>
  public static class BinaryTreeEnhancer
  {
    public static void EnhancePayoff(BinaryTree<State> subject, OptionPayoffType type, double strikePrice)
    {
      var payoffStrategy = GetPayoffStrategy(type);

      foreach (var node in subject)
      {
        node.Data.PayOff = payoffStrategy(node, strikePrice);
      }
    }

    /// <summary>
    /// TODO: Extend to use an actual strategy class. Get the strategy from a StrategyFactory so theres only one switch statement
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private static Func<Node<State>, double, double> GetPayoffStrategy(OptionPayoffType type)
    {
      switch (type)
      {
        case OptionPayoffType.Call:
          return (x, K) => x.Data.UnderlyingValue - K;
          break;
        case OptionPayoffType.Put:
          return (x, K) => K - x.Data.UnderlyingValue;
          break;
        default:
          throw new ArgumentException($"No payoff strategy for type {type}", "type");
      }
    }
  }
}
