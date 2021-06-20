using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Tests
{
    class TimeComparer : IComparer<Time>
    {
        public int Compare(Time x, Time y)
        {
            return (x.Hours * 60 + x.Minutes) - (y.Hours * 60 + y.Minutes);
        }
    }
}
