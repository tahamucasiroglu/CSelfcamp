using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersinV2.DTOs.DTOs.GetModels
{
    public sealed record class GetSurveyWithQuestions
    {
        public GetSurveyWithQuestions(GetSurveyDTO survey, IEnumerable<GetQuestionDTO> questions)
        {
            Survey = survey;
            Questions = questions;
        }

        GetSurveyDTO Survey { get; init; }
        IEnumerable<GetQuestionDTO> Questions { get; init; }
    }
}
