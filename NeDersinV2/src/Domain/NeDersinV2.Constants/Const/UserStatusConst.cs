using NeDersinV2.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersinV2.Constants.Const
{
    static public class UserStatusConst
    {
        public static string Admin { get => nameof(UserStatusEnum.Admin); }
        public static string Pollster { get => nameof(UserStatusEnum.Pollster); }
        public static string Member { get => nameof(UserStatusEnum.Member); }
        public static string Anonim { get => nameof(UserStatusEnum.Anonim); }
    }
}
