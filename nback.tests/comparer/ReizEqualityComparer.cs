using nback.data.data;
using System;
using System.Collections.Generic;

namespace nback.tests.comparer
{
    public class ReizEqualityComparer : IEqualityComparer<Reiz>
    {
        public bool Equals(Reiz x, Reiz y)
        {
            return x.Buchstabe == y.Buchstabe && x.Anzahl == y.Anzahl && x.Index == y.Index;
        }

        public int GetHashCode(Reiz obj)
        {
            throw new NotImplementedException();
        }
    }
}
