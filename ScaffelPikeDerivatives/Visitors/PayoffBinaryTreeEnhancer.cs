﻿using System;
using ScaffelPikeDerivatives.Objects;
using ScaffelPikeDerivatives.Objects.Enums;
using ScaffelPikeDerivatives.Objects.Interfaces;

namespace ScaffelPikeDerivatives.Visitors
{
  public class PayoffBinaryTreeEnhancer : IBinaryTreeEnhancer
  {
    private readonly Func<Node<State>, double, double> _payoffMethod;
    private readonly double _strikePrice;

    public PayoffBinaryTreeEnhancer(OptionPayoffType optionType, double strikePrice)
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

    private Func<Node<State>, double, double> GetPayoffStrategy(OptionPayoffType type)
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
