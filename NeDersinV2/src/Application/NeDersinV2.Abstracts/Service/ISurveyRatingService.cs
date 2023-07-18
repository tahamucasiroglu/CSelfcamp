
using NeDersinV2.DTOs.Abstract;
using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels.SurveyRating;
using NeDersinV2.Abstracts.Service.Base;
using NeDersinV2.Returns.Abstract;

namespace NeDersinV2.Abstracts.Service
{
    public interface ISurveyRatingService : IService<GetSurveyRatingDTO, VM_Create_SurveyRating>
    {
        public IReturnModel<IEnumerable<GetSurveyRatingDTO>> GetsBySurveyId(int id);
        public Task<IReturnModel<IEnumerable<GetSurveyRatingDTO>>> GetsBySurveyIdAsync(int id);
        public IReturnModel<IEnumerable<GetSurveyRatingDTO>> GetsByUserId(int id);
        public Task<IReturnModel<IEnumerable<GetSurveyRatingDTO>>> GetsByUserIdAsync(int id);
        public IReturnModel<IEnumerable<GetSurveyRatingDTO>> GetsByRating(int rate);
        public Task<IReturnModel<IEnumerable<GetSurveyRatingDTO>>> GetsByRatingAsync(int rate);
        public IReturnModel<IEnumerable<GetSurveyRatingDTO>> GetsByRating(Range range);
        public Task<IReturnModel<IEnumerable<GetSurveyRatingDTO>>> GetsByRatingAsync(Range range);
        public IReturnModel<IEnumerable<GetSurveyRatingDTO>> GetByUserIdAndSurveyId(int userId, int surveyId);
        public Task<IReturnModel<IEnumerable<GetSurveyRatingDTO>>> GetByUserIdAndSurveyIdAsync(int userId, int surveyId);
    }
}
