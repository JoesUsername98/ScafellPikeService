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

namespace ScaffelPikeTests.Derivatives.OptionPricing
{
  public class AmericanOptimalStoppingTimeTests
  {
    public class AmericanOptionsTests
    {
      [Theory]
      [InlineData(4, 3, 2, 5, 0.25)]
      public void OptimalStoppingTimeCall(int So, int N, double u, double k, double r)
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
      }

      [Theory]
      [InlineData(4, 6, 2, 5, 0.25)]
      public void OptimalStoppingTimePut(int So, int N, double u, double k, double r)
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


        //assert
      }
    }
  }
}
