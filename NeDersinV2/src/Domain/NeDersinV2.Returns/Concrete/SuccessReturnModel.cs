using NeDersinV2.Returns.Base;

namespace NeDersinV2.Returns.Concrete
{
    public sealed record class SuccessReturnModel<T> : ReturnModelBase<T>
    {
        public SuccessReturnModel() : base(true, null, default, null) { }
        public SuccessReturnModel(string? Message) : base(true, Message, default, null) { }
        public SuccessReturnModel(T? Data) : base(true, null, Data, null) { }
        public SuccessReturnModel(string? Message, T? Data) : base(true, Message, Data, null) { }
    }
}
