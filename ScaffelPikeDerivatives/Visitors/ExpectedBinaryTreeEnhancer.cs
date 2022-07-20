using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDerivatives.Objects;
using ScaffelPikeDerivatives.Objects.Interfaces;

namespace ScaffelPikeDerivatives.Visitors
{
  public class ExpectedBinaryTreeEnhancer : IBinaryTreeEnhancer
  {
    private readonly string _propName;
    private readonly PropertyInfo _property;
    public ExpectedBinaryTreeEnhancer(string propName)
    {
      _propName = propName;
      _property = typeof(State).GetType().GetProperty(_propName);
    }
    public void Enhance(BinaryTree<State> subject)
    {
      foreach (var node in subject)
      {
        var headsProperty = (double)_property.GetValue(node.Heads.Data, null);
        var tailsProperty = (double)_property.GetValue(node.Tails.Data, null);

        var expected = headsProperty * node.Data.ProbabilityHeads + tailsProperty * node.Data.ProbabilityTails;

        _property.SetValue(node.Data.Expected, expected, null);  
      }
    }
  }
}
