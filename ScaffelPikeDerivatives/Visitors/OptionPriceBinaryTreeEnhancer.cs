using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDerivatives.Factory;
using ScaffelPikeDerivatives.Objects;
using ScaffelPikeDerivatives.Objects.Enums;
using ScaffelPikeDerivatives.Objects.Interfaces;

namespace ScaffelPikeDerivatives.Visitors
{
  public class OptionPriceBinaryTreeEnhancer : IBinaryTreeEnhancer
  {
    private readonly Func<Node<State>, double> _optionPricingStrategy;

    public OptionPriceBinaryTreeEnhancer(OptionExerciseType optionType)
    {
      _optionPricingStrategy = GetOptionPricingStrategy(optionType);
    }

    public void Enhance(BinaryTree<State> subject)
    {
      foreach (var node in subject.OrderByDescending(n => n.Time))
      {
        if (node?.Data?.PayOff is null) throw new NullReferenceException($"Payoff is null {node.Path}");

        if (node.Time == subject.Time)
        {
          node.Data.OptionValue = _optionPricingStrategy(node);
          continue;
        }

        node.Data.OptionValue = node.Data.DiscountRate *
                                  (node.Heads.Data.OptionValue * node.Data.ProbabilityHeads +
                                   node.Tails.Data.OptionValue * node.Data.ProbabilityTails);
      }
    }

    private Func<Node<State>, double> GetOptionPricingStrategy(OptionExerciseType type)
    {
      switch (type)
      {
        case OptionExerciseType.European:
          return (x) => Math.Max(x.Data.PayOff, 0);
          break;
        case OptionExerciseType.American:
          return (x) => Math.Max(x.Data.PayOff, x.Data.DiscountRate * x.Data.Expected.PayOff);
          break;
        default:
          throw new ArgumentException($"No option pricing strategy for type {type}", "type");
      }
    }
  }
}
