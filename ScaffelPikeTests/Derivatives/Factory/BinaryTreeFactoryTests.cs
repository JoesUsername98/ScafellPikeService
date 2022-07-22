using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDerivatives.Factory;
using ScaffelPikeDerivatives.Objects;
using ScaffelPikeDerivatives.Objects.Enums;
using ScaffelPikeDerivatives.Visitors;
using Xunit;

namespace ScaffelPikeTests.Derivatives.Factory
{
  public class BinaryTreeFactoryTests
  {
    [Theory]
    [InlineData(3)]
    [InlineData(10)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(10)]
    [InlineData(2)]
    public void GenerateEmptyTree(int N)
    {
      //act and arrange 
      var tree = BinaryTreeFactory.CreateTree(N);

      //assert
      Assert.Equal(tree.Count, Enumerable.Range(0, N + 1).Sum(i => Combinations.summedNCR(i)));
    }

    [Theory]
    [InlineData(4, 3, 2)]
    [InlineData(4, 10, 2)]
    [InlineData(4, 2, 1.1)]
    [InlineData(4, 3, 2, 0.33)]
    [InlineData(4, 10, 2, 0.8)]
    [InlineData(4, 2, 1.1, 0.1)]
    public void GenerateTreeWithUnderlyingValue(int So, int N, double u, double d = -1)
    {
      //arrange 
      var tree = BinaryTreeFactory.CreateTree(N);
      var underlyingEnhancer = d == -1 ? new UnderlyingValueBinaryTreeEnhancer(So, u) : new UnderlyingValueBinaryTreeEnhancer(So, u, d);
      underlyingEnhancer.Enhance(tree);

      //act 
      var maxValueInTree = tree.Max(x => x.Data.UnderlyingValue);
      var minValueInTree = tree.Min(x => x.Data.UnderlyingValue);
      var exMin = d == -1 ? So * Math.Pow(u, -N) : So * Math.Pow(d, N);

      //assert
      Assert.Equal(tree.Count, Enumerable.Range(0, N + 1).Sum(i => Combinations.summedNCR(i)));
      Assert.Equal(So * Math.Pow(u, N), maxValueInTree);
      Assert.Equal(exMin, minValueInTree);
    }

    [Theory]
    [InlineData(0.25)]
    [InlineData(1)]
    [InlineData(4)]
    [InlineData(0.33)]
    [InlineData(0.8)]
    [InlineData(0.1)]
    public void GenerateTreeWithConstantInterestRate(double r)
    {
      //arrange 
      int N = 3;
      var tree = BinaryTreeFactory.CreateTree(N);

      //act 
      new ConstantInterestRateBinaryTreeEnhancer(r).Enhance(tree);

      //assert
      Assert.Equal(tree.Count, Enumerable.Range(0, N + 1).Sum(i => Combinations.summedNCR(i)));
      foreach(var node in tree)  Assert.Equal(r, node.Data.InterestRate);
    }

    [Theory]
    [InlineData(4, 3, 2, 0.25)]
    [InlineData(4, 10, 2, 0.25)]
    [InlineData(4, 3, 2, 0.25, 0.33)]
    [InlineData(4, 10, 2, 0.25, 0.8)]
    public void GenerateTreeWithUnderlyingAndRiskNuetralProbs(int So, int N, double u, double r, double d = -1)
    {
      //arrange 
      d = d == -1 ? 1 / u : d;
      var tree = BinaryTreeFactory.CreateTree(N);
      var underlyingEnhancer = new UnderlyingValueBinaryTreeEnhancer(So, u, d);
      underlyingEnhancer.Enhance(tree);

      //act 
      new ConstantInterestRateBinaryTreeEnhancer(r).Enhance(tree);
      new RiskNuetralProbabilityEnhancer().Enhance(tree);
      
      //assert
      foreach (var node in tree) Assert.Equal(r, node.Data.InterestRate);
      foreach (var node in tree) Assert.Equal(1, node.Data.ProbabilityHeads + node.Data.ProbabilityTails);
      foreach (var node in tree) { Assert.True(node.Data.ProbabilityHeads > 0); Assert.True(node.Data.ProbabilityTails > 0); }
    }

    [Theory]
    [InlineData(4, 2, 1.1, 0.25)]
    ///if (u< 1 + node.Data.InterestRate) throw new InvalidOperationException("u > 1 + r to prevent arbitrage");
    public void ErrorWhenBreachingArbitrageConditions1(int So, int N, double u, double r, double d = -1)
    {
      //arrange 
      d = d == -1 ? 1 / u : d;
      var tree = BinaryTreeFactory.CreateTree(N);
      var underlyingEnhancer = new UnderlyingValueBinaryTreeEnhancer(So, u, d);
      underlyingEnhancer.Enhance(tree);

      //act 
      new ConstantInterestRateBinaryTreeEnhancer(r).Enhance(tree);

      //assert
      var ex = Assert.Throws<InvalidOperationException>(() => new RiskNuetralProbabilityEnhancer().Enhance(tree));
      Assert.Equal(ex.Message, "u > 1 + r to prevent arbitrage");
    }

    [Theory]
    [InlineData(4, 3, 6, 4, 5.1)]
    ///if (1 + node.Data.InterestRate < d) throw new InvalidOperationException("1 + r > d to prevent arbitrage");
    public void ErrorWhenBreachingArbitrageConditions2(int So, int N, double u, double r, double d = -1)
    {
      //arrange 
      d = d == -1 ? 1 / u : d;
      var tree = BinaryTreeFactory.CreateTree(N);
      var underlyingEnhancer = new UnderlyingValueBinaryTreeEnhancer(So, u, d);
      underlyingEnhancer.Enhance(tree);

      //act 
      new ConstantInterestRateBinaryTreeEnhancer(r).Enhance(tree);

      //assert
      var ex = Assert.Throws<InvalidOperationException>(() => new RiskNuetralProbabilityEnhancer().Enhance(tree));
      Assert.Equal(ex.Message, "1 + r > d to prevent arbitrage");
    }

    [Theory]
    [InlineData(4, 3, 2, 0.25)]
    public void GenerateTreeWithExpectedValues(int So, int N, double u, double r)
    {
      //arrange 
      var d = 1 / u;
      var tree = BinaryTreeFactory.CreateTree(N);
      var underlyingEnhancer = new UnderlyingValueBinaryTreeEnhancer(So, u, d);
      underlyingEnhancer.Enhance(tree);

      //act 
      new ConstantInterestRateBinaryTreeEnhancer(r).Enhance(tree);
      new RiskNuetralProbabilityEnhancer().Enhance(tree);
      new ExpectedBinaryTreeEnhancer("UnderlyingValue").Enhance(tree);

      //assert
      foreach (var node in tree.Where(n => n.Heads != null && n.Tails != null)) 
      {
        Assert.Equal(node.Data.UnderlyingValue, node.Data.DiscountRate * node.Data.Expected.UnderlyingValue); //eq (2.3.5)
        Assert.Equal(Math.Round(node.Data.UnderlyingValue * Math.Pow(node.Data.DiscountRate, node.Time), 4),
              Math.Round(node.Data.Expected.UnderlyingValue * Math.Pow(node.Data.DiscountRate, node.Time + 1),4)); //eq (2.4.5)
      }
    }

    [Theory]
    [InlineData(4, 3, 2, 5, 0.25)]
    public void GenerateTreeWithCallPayoff(int So, int N, double u, double k, double r)
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
      new ExpectedBinaryTreeEnhancer("UnderlyingValue").Enhance(tree);
      new ExpectedBinaryTreeEnhancer("PayOff").Enhance(tree);

      //assert
      foreach (var node in tree.Where(n => n.Heads != null && n.Tails != null)) 
      {
        Assert.Equal(node.Data.UnderlyingValue - k, node.Data.PayOff);
      }
    }


    [Theory]
    [InlineData(4, 3, 2, 5, 0.25)]
    public void GenerateTreeWithPutPayoff(int So, int N, double u, double k, double r)
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
      new ExpectedBinaryTreeEnhancer("UnderlyingValue").Enhance(tree);
      new ExpectedBinaryTreeEnhancer("PayOff").Enhance(tree);

      //assert
      foreach (var node in tree.Where(n => n.Heads != null && n.Tails != null))
      {
        Assert.Equal(k - node.Data.UnderlyingValue, node.Data.PayOff);
      }
    }

    [Theory]
    [InlineData(4, 3, 2, 5, 0.25)]
    public void GenerateTreeWithEuropeanCallPrice(int So, int N, double u, double k, double r)
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
      new OptionPriceBinaryTreeEnhancer(OptionExerciseType.European).Enhance(tree);

      //assert
      //Theorem 2.4.7 Risk-nuetral pricing formula 
      //The Discounted price of a derivative security is a martingale under risk nuetral pricing. 
      // Vn / (1+r)^n = En ( Vn+1 / (1+r)^(n+1) )   ---   (2.4.12)
      var expectedOptionPriceValueAtEachTime = new Dictionary<int, double>();
      for (int thisTime = tree.Time; thisTime >= 0; thisTime--)
      {
        var discountedExpectedOptionPrice
          = tree.Where(n => n.Time == thisTime)
                 .Sum(n => n.Data.OptionValue * State.GetAbsoluteDiscountRate(n) * State.GetAbsoluteProb(n));

        expectedOptionPriceValueAtEachTime.Add(thisTime,Math.Round(discountedExpectedOptionPrice,5));
      }
      Assert.Equal(1, expectedOptionPriceValueAtEachTime.Values.Distinct().Count());
    }

    [Theory]
    [InlineData(4, 3, 2, 5, 0.25)]
    public void GenerateTreeWithEuropeanPutPrice(int So, int N, double u, double k, double r)
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
      new OptionPriceBinaryTreeEnhancer(OptionExerciseType.European).Enhance(tree);

      //assert
      //Theorem 2.4.7 Risk-nuetral pricing formula 
      //The Discounted price of a derivative security is a martingale under risk nuetral pricing. 
      // Vn / (1+r)^n = En ( Vn+1 / (1+r)^(n+1) )   ---   (2.4.12)
      var expectedOptionPriceValueAtEachTime = new Dictionary<int, double>();
      for (int thisTime = tree.Time; thisTime >= 0; thisTime--)
      {
        var discountedExpectedOptionPrice
          = tree.Where(n => n.Time == thisTime)
                 .Sum(n => n.Data.OptionValue * State.GetAbsoluteDiscountRate(n) * State.GetAbsoluteProb(n));

        expectedOptionPriceValueAtEachTime.Add(thisTime, Math.Round(discountedExpectedOptionPrice, 5));
      }
      Assert.Equal(1, expectedOptionPriceValueAtEachTime.Values.Distinct().Count());
    }
  }
}
