using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersinV2.DTOs.DTOs.GetModels
{
    public sealed record GetSurveyPaginationDTO
    {
        public GetSurveyPaginationDTO(IEnumerable<GetSurveyPaginationListDTO> surveyList, string order, string @short)
        {
            SurveyList = surveyList;
            Order = order;
            Short = @short;
        }

        IEnumerable<GetSurveyPaginationListDTO> SurveyList { get; init; }
        public string Order { get; init; }
        public string Short { get; init; }
    }

    public sealed record GetSurveyPaginationListDTO
    {
        public GetSurveyPaginationListDTO(Guid adress, int userId, string userName, string title)
        {
            Adress = adress;
            UserId = userId;
            UserName = userName;
            Title = title;
        }

        public Guid Adress { get; init; }
        public int UserId { get; init; }
        public string UserName { get; init; } = null!;
        public string Title { get; init; } = null!;
    }


}
