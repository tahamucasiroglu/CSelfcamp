using NeDersinV2.Constants.Enums;
using System.Text.Json;

namespace NeDersinV2.Constants.Const
{
    static public class AnswerTypeConst
    {
        static public string Rating10 { get => JsonSerializer.Serialize(new Dictionary<string, string>() { { "Name", nameof(AnswerTypeEnum.Rating) }, { "Min", "0" }, { "Max", "10" } }); }
        static public string Rating5 { get => JsonSerializer.Serialize(new Dictionary<string, string>() { { "Name", nameof(AnswerTypeEnum.Rating) }, { "Min", "0" }, { "Max", "5" } }); }
        static public string LongText { get => JsonSerializer.Serialize(new Dictionary<string, string>() { { "Name", nameof(AnswerTypeEnum.LongText) }, { "Length", "1000"}}); }
        static public string ShortText { get => JsonSerializer.Serialize(new Dictionary<string, string>() { { "Name", nameof(AnswerTypeEnum.ShortText) }, { "Length", "100" } }); }
        static public string SingleSelect { get => JsonSerializer.Serialize(new Dictionary<string, string>() { { "Name", nameof(AnswerTypeEnum.SingleSelect) } }); }
        static public string MultiSelect { get => JsonSerializer.Serialize(new Dictionary<string, string>() { { "Name", nameof(AnswerTypeEnum.MultiSelect) } }); }
    }
}
