using NeDersinV2.API.HateoasModels;
using NeDersinV2.Returns.Abstract;

namespace NeDersinV2.API.Models
{
    public sealed record ActionReturnModel<T>
    {
        public ActionReturnModel(string? apiMessage, IReturnModel<T> data, HateoasModel hateoas)
        {
            ApiMessage = apiMessage;
            Data = data;
            Hateoas = hateoas;
        }

        public string? ApiMessage { get; set; }
        public IReturnModel<T> Data { get; set; }
        public HateoasModel Hateoas { get; set; }



    }
    public sealed record ActionReturnModel
    {
        public ActionReturnModel(string? apiMessage, HateoasModel hateoas)
        {
            ApiMessage = apiMessage;
            Hateoas = hateoas;
        }

        public string? ApiMessage { get; set; }
        public HateoasModel Hateoas { get; set; }
    }

}
