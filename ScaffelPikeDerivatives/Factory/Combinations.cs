using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaffelPikeDerivatives.Factory
{
  public class Combinations
  {
    private static IEnumerable<T> AsSingleton<T>(T source){ yield return source;}
    /// <summary>
    ///https://stackoverflow.com/questions/44894067/combinations-from-different-groups-in-a-specific-order
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ParmLists"></param>
    /// <returns></returns>
    public static IEnumerable<IEnumerable<T>> GenerateParams<T>(IEnumerable<T> uniqueElements, int comboLength)
    {
      var parmLists = new List<List<T>>();
      for (int i = 0; i < comboLength; i++)
      {
        parmLists.Add(uniqueElements.ToList());
      }
      return parmLists;
    }
    public static IEnumerable<IEnumerable<T>> Parameters<T>( IEnumerable<IEnumerable<T>> ParmLists)
    {
      if (ParmLists.Count() == 1)
        foreach (var p in ParmLists.First())
          yield return AsSingleton(p);
      else
      {
        var rest = Parameters(ParmLists.Skip(1));
        foreach (var p in ParmLists.First())
        {
          foreach (var r in rest)
            yield return r.Prepend(p);
        }
      }
    }

    private static long Factorial(int number)
    {
      if (number < 0)
        return -1; //Error

      long result = 1;

      for (int i = 1; i <= number; ++i)
        result *= i;

      return result;
    }

    public static long NCR(int n, int r)
    {
      return Factorial(n) / (Factorial(r) * Factorial(n - r));
    }

    public static long summedNCR(int r)
    {
      long expectedCount = 0;
      for (int i = 0; i <= r; i++)
      {
        expectedCount += NCR(r, i);
      }
      return expectedCount;
    }
  }
}
