using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaffelPikeDerivatives.Objects.Iterators
{
internal enum NodeIteratorState
  {
    CurrentIsLeaf = 1,
    CurrentIsNotInitialized = 0,
    CurrentIsBranch = -1
  }
}
