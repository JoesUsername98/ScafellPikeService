﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDerivatives.Factory;
using ScaffelPikeDerivatives.Objects;
using ScaffelPikeDerivatives.Objects.Enums;
using ScaffelPikeDerivatives.Visitors;
using Xunit;

namespace ScaffelPikeTests.Derivatives.OptionPricing
{
  public class AmericanOptionsTests
  {
    [Theory]
    [InlineData(4, 3, 2, 5, 0.25)]
    public void GenerateTreeWithAmericanCallPrice(int So, int N, double u, double k, double r)
    {
      //arrange 
      var d = 1 / u;
      var tree = BinaryTreeFactory.CreateTree(N);
      var underlyingEnhancer = new UnderlyingValueBinaryTreeEnhancer(So, u, d);
      underlyingEnhancer.Enhance(tree);

      //act 
      new ConstantInterestRateBinaryTreeEnhancer(r).Enhance(tree);
      new PayoffBinaryTreeEnhancer(OptionPayoffType.Call, k).Enhance(tree);
      new RiskNuetralProbabilityEnhancer().Enhance(tree);
      new ExpectedBinaryTreeEnhancer("PayOff").Enhance(tree);
      new OptionPriceBinaryTreeEnhancer(OptionExerciseType.American).Enhance(tree);

      //assert
      var expectedOptionPriceValueAtEachTime = new Dictionary<int, double>();
      for (int thisTime = tree.Time; thisTime >= 0; thisTime--)
      {
        var discountedExpectedOptionPrice
          = tree.Where(n => n.Time == thisTime)
                 .Sum(n => n.Data.OptionValue * State.GetAbsoluteDiscountRate(n) * State.GetAbsoluteProb(n));

        expectedOptionPriceValueAtEachTime.Add(thisTime, Math.Round(discountedExpectedOptionPrice, 5));
      }
      //assert that with time the expected value of the american option deminishes. super-martigale
      for (int i = 0; i < expectedOptionPriceValueAtEachTime.Values.Count(); i++)
        Assert.Equal(expectedOptionPriceValueAtEachTime.Values.OrderBy(s => s).ToList()[i], expectedOptionPriceValueAtEachTime.Values.ToList()[i]);
    }

    [Theory]
    [InlineData(4, 2, 2, 5, 0.25)]
    public void GenerateTreeWithAmericanPutPrice(int So, int N, double u, double k, double r)
    {
      //arrange 
      var d = 1 / u;
      var tree = BinaryTreeFactory.CreateTree(N);
      var underlyingEnhancer = new UnderlyingValueBinaryTreeEnhancer(So, u, d);
      underlyingEnhancer.Enhance(tree);

      //act 
      new ConstantInterestRateBinaryTreeEnhancer(r).Enhance(tree);
      new PayoffBinaryTreeEnhancer(OptionPayoffType.Put, k).Enhance(tree);
      new RiskNuetralProbabilityEnhancer().Enhance(tree);
      new ExpectedBinaryTreeEnhancer("PayOff").Enhance(tree);
      new OptionPriceBinaryTreeEnhancer(OptionExerciseType.American).Enhance(tree);

      var expectedOptionPriceValueAtEachTime = new Dictionary<int, double>();
      for (int thisTime = tree.Time; thisTime >= 0; thisTime--)
      {
        var discountedExpectedOptionPrice
          = tree.Where(n => n.Time == thisTime)
                 .Sum(n => n.Data.OptionValue * State.GetAbsoluteDiscountRate(n) * State.GetAbsoluteProb(n));

        expectedOptionPriceValueAtEachTime.Add(thisTime, Math.Round(discountedExpectedOptionPrice, 5));
      }

      //assert that with time the expected value of the american option deminishes. super-martigale
      for (int i = 0; i < expectedOptionPriceValueAtEachTime.Values.Count(); i++)
       Assert.Equal(expectedOptionPriceValueAtEachTime.Values.OrderBy(s => s).ToList()[i], expectedOptionPriceValueAtEachTime.Values.ToList()[i]);
    }
  }
}
