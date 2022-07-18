using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDerivatives.Objects;

namespace ScaffelPikeDerivatives.Factory
{
  /// <summary>
  /// TODO: add pattern here
  /// </summary>
  public static class BinaryTreeEnhancer
  {
    public static void EnhancePayoff(BinaryTree<State> subject, OptionType type, double strikePrice)
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
    private static Func<Node<State>, double, double> GetPayoffStrategy(OptionType type)
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
