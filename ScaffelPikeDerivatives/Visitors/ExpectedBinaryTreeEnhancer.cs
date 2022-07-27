using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ScafellPikeDerivatives.Objects;
using ScafellPikeDerivatives.Objects.Interfaces;

namespace ScafellPikeDerivatives.Visitors
{
  public class ExpectedBinaryTreeEnhancer : IBinaryTreeEnhancer
  {
    private readonly string _propName;
    private readonly PropertyInfo _property;
    private readonly PropertyInfo _expectedProperty;
    public ExpectedBinaryTreeEnhancer(string propName)
    {
      _propName = propName;
      _property = typeof(State).GetProperty(_propName, BindingFlags.FlattenHierarchy | BindingFlags.Instance |BindingFlags.Public );
      _expectedProperty = typeof(ExpectableState).GetProperty(_propName);
    }
    public void Enhance(BinaryTree<State> subject)
    {
      foreach (var node in subject.Where(n => n.Heads != null && n.Tails != null)) 
      {
        var headsProperty = (double)_property.GetValue(node.Heads.Data, null);
        var tailsProperty = (double)_property.GetValue(node.Tails.Data, null);

        // eq. (2.3.3)
        var expected = headsProperty * node.Data.ProbabilityHeads + tailsProperty * node.Data.ProbabilityTails;

        _expectedProperty.SetValue(node.Data.Expected, expected, null);  
      }
    }
  }
}
