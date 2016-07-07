using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaJXNU.Model.EnumType
{
    /// <summary>
    /// 逻辑删除枚举类型
    /// </summary>
    public enum DelFlagEnumType
    {
        /// <summary>
        /// 正常显示时候的值
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 逻辑删除事的值
        /// </summary>
        LogicDelete = 1
    }
}
