using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolTest
{

    interface IPooldObject
    {
        ObjectPooler.ObjectInfo.ObjectType _type { get;  }
    }
}
