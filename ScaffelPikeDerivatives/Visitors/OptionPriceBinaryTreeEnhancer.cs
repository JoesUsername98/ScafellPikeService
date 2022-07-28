using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScafellPikeDerivatives.Factory;
using ScafellPikeDerivatives.Objects;
using ScafellPikeDerivatives.Objects.Enums;
using ScafellPikeDerivatives.Objects.Interfaces;
using ScaffelPikeDerivatives.Objects;

namespace ScafellPikeDerivatives.Visitors
{
  public class OptionPriceBinaryTreeEnhancer : IBinaryTreeEnhancer
  {
    private readonly OptionExerciseType _optionType; 
    private readonly Func<Node<State>, double> _optionPricingStrategy;

    public OptionPriceBinaryTreeEnhancer(OptionExerciseType optionType)
    {
      _optionType = optionType;
      _optionPricingStrategy = GetOptionPricingStrategy(optionType);
    }

    public void Enhance(BinaryTree<State> subject)
    {
      foreach (var node in subject.OrderByDescending(n => n.Time))
      {
        if (node?.Data?.PayOff is null) throw new NullReferenceException($"Payoff is null {node.Path}");

        if (node.Time == subject.Time || _optionType == OptionExerciseType.American)
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
          return (x) => Math.Max(x.Data.PayOff, (x.Heads is null || x.Tails is null) ? 0.0 :
                                    x.Data.DiscountRate *
                                  (x.Heads.Data.OptionValue * x.Data.ProbabilityHeads +
                                   x.Tails.Data.OptionValue * x.Data.ProbabilityTails));
          break;
        default:
          throw new ArgumentException($"No option pricing strategy for type {type}", "type");
      }
    }
  }
}
