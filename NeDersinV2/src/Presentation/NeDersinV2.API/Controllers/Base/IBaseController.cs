using NeDersinV2.Returns.Abstract;

namespace NeDersinV2.API.Controllers.Base
{
    public interface IBaseController
    {
        public void LogModelState<TLog>(TLog value);
        public void LogModelState<TLog>();
        public void LogModelState<TLog>(TLog value, string MethodName);
        public void LogModelState<TLog>(string MethodName);
        public bool LogResultError<TLog>(IReturnModel<TLog> result);
    }
}
