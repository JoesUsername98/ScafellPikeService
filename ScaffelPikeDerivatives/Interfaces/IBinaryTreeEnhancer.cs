using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDerivatives.Objects;

namespace ScaffelPikeDerivatives.Objects.Interfaces
{
  public interface IBinaryTreeEnhancer 
  { 
    void Enhance(BinaryTree<State> subject);
  }
}
