using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersinV2.DTOs.DTOs.GetModels
{
    public record class GetSurveyWithQuestionAndAnswers
    {
        public GetSurveyWithQuestionAndAnswers(GetSurveyDTO survey, IEnumerable<(GetQuestionDTO, IEnumerable<GetAnswerDTO>)> questionAndAnswer)
        {
            Survey = survey;
            QuestionAndAnswer = questionAndAnswer;
        }

        GetSurveyDTO Survey { get; init; }
        IEnumerable<(GetQuestionDTO, IEnumerable<GetAnswerDTO>)> QuestionAndAnswer { get; init; } 

    }
}
