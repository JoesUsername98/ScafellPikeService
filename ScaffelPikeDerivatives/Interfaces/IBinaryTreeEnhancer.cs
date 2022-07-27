using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScafellPikeDerivatives.Objects;

namespace ScafellPikeDerivatives.Objects.Interfaces
{
  public interface IBinaryTreeEnhancer 
  { 
    void Enhance(BinaryTree<State> subject);
  }
}
