using NeDersinV2.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersinV2.Constants.Const
{
    static public class OrderTypeConst
    {
        static public string StartDate { get => nameof(OrderTypeEnum.StartDate); }
        static public string EndDate { get => nameof(OrderTypeEnum.EndDate); }
        static public string Rating { get => nameof(OrderTypeEnum.Rating); }
        static public string ResponseCount { get => nameof(OrderTypeEnum.ResponseCount); }
    }
}
