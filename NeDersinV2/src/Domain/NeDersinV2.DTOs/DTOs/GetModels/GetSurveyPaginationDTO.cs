using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NeDersinV2.DTOs.DTOs.GetModels
{
    public sealed record GetSurveyPaginationDTO
    {
        public GetSurveyPaginationDTO(IEnumerable<GetSurveyPaginationListDTO> surveyList, string order, string @short, int maxPage, int pageSize)
        {
            SurveyList = surveyList;
            Order = order;
            Short = @short;
            MaxPage = maxPage;
            PageSize = pageSize;
        }

        public IEnumerable<GetSurveyPaginationListDTO> SurveyList { get; init; }
        public string Order { get; init; }
        public string Short { get; init; }
        public int MaxPage { get; init; }
        public int PageSize { get; init; }
    }

    public sealed record GetSurveyPaginationListDTO
    {
        public GetSurveyPaginationListDTO(Guid address, int userId, string userName, string title, double rating)
        {
            Address = address;
            UserId = userId;
            UserName = userName;
            Title = title;
            Rating = rating;
        }

        public Guid Address { get; init; }
        public int UserId { get; init; }
        public string UserName { get; init; } = null!;
        public string Title { get; init; } = null!;
        public double Rating { get; init; }
    }


}
