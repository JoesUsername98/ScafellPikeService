using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDerivatives.Factory;
using Xunit;

namespace ScaffelPikeTests.Derivatives.Factory
{
  public class CombinationsTest
  {
    [Fact]
    public void CombinationsTestMethod() // 
    {
      //arrange 
      var length = 3;
      var possibleOutcomesAtTime = new List<List<bool>>();
      var inputParams = Combinations.GenerateParams(new bool[] { true, false }, length);

      //act 
      foreach (IEnumerable<bool> item in Combinations.Parameters(inputParams))
      {
        var itemList = item.ToList();
        possibleOutcomesAtTime.Add(itemList);
      };

      //assert
      Assert.All<IEnumerable<bool>>(possibleOutcomesAtTime, combo => Assert.Equal(length,combo.Count()));
      Assert.Equal(possibleOutcomesAtTime.Distinct().Count(), possibleOutcomesAtTime.Count());
      Assert.Equal(Combinations.summedNCR(length), possibleOutcomesAtTime.Count());
    }
  }
}
