using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.model.EnumType
{
    public class DeleteEnumType
    {
        public enum DelFlag
        { 
            /// <summary>
            /// 正常
            /// </summary>
            Normal=0,
            /// <summary>
            /// 逻辑删除
            /// </summary>
            LogicDelete=1
        }
    }
}
