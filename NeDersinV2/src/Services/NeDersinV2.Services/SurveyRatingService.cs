using AutoMapper;
using NeDersinV2.Abstracts.Repository;
using NeDersinV2.Abstracts.Service;
using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels.SurveyRating;
using NeDersinV2.Entities.Concrete;
using NeDersinV2.Returns.Abstract;
using NeDersinV2.Returns.Concrete;
using NeDersinV2.Services.Base;

namespace NeDersinV2.Services
{
    public sealed class SurveyRatingService : ServiceBase<SurveyRating, GetSurveyRatingDTO, VM_Create_SurveyRating>, ISurveyRatingService
    {
        public SurveyRatingService(ISurveyRatingRepository repository, IMapper mapper) : base(repository, mapper) { }

        public IReturnModel<IEnumerable<GetSurveyRatingDTO>> GetByRating(int rate)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = repository.GetAll(r => r.RatingCount == rate);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetSurveyRatingDTO>> GetByRating(Range range)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = repository.GetAll(r => r.RatingCount >= range.Start.Value && r.RatingCount <= range.End.Value);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyRatingDTO>>> GetByRatingAsync(int rate)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = await repository.GetAllAsync(r => r.RatingCount == rate);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyRatingDTO>>> GetByRatingAsync(Range range)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = await repository.GetAllAsync(r => r.RatingCount >= range.Start.Value && r.RatingCount <= range.End.Value);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetSurveyRatingDTO>> GetBySurveyId(int id)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = repository.GetAll(r => r.SurveyId == id);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyRatingDTO>>> GetBySurveyIdAsync(int id)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = await repository.GetAllAsync(r => r.SurveyId == id);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetSurveyRatingDTO>> GetByUserId(int id)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = repository.GetAll(r => r.UserId == id);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyRatingDTO>>> GetByUserIdAsync(int id)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = await repository.GetAllAsync(r => r.UserId == id);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }
        public IReturnModel<IEnumerable<GetSurveyRatingDTO>> GetById(int id)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = repository.GetAll(r => r.Id == id);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyRatingDTO>>> GetByIdAsync(int id)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = await repository.GetAllAsync(r => r.Id == id);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetSurveyRatingDTO>> GetsBySurveyId(int id)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = repository.GetAll(r => r.SurveyId == id);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyRatingDTO>>> GetsBySurveyIdAsync(int id)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = await repository.GetAllAsync(r => r.SurveyId == id);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetSurveyRatingDTO>> GetsByUserId(int id)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = repository.GetAll(r => r.UserId == id);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyRatingDTO>>> GetsByUserIdAsync(int id)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = await repository.GetAllAsync(r => r.UserId == id);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetSurveyRatingDTO>> GetsByRating(int rate)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = repository.GetAll(r => r.RatingCount == rate);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyRatingDTO>>> GetsByRatingAsync(int rate)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = await repository.GetAllAsync(r => r.RatingCount == rate);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetSurveyRatingDTO>> GetsByRating(Range range)
        {
            List<SurveyRating> result = new() { };
            for (int i = range.Start.Value; i < range.End.Value; i++)
            {
                IEnumerable<SurveyRating> rating = repository.GetAll(r => r.RatingCount == i).Data ?? new List<SurveyRating>() { };
                result.AddRange(rating);
                
            }
            IReturnModel<IEnumerable<SurveyRating>> temp = result.Count > 0 ? new SuccessReturnModel<IEnumerable<SurveyRating>>(result) : new ErrorReturnModel<IEnumerable<SurveyRating>>(result);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(temp, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyRatingDTO>>> GetsByRatingAsync(Range range)
        {
            List<SurveyRating> result = new() { };
            for (int i = range.Start.Value; i < range.End.Value; i++)
            {
                IEnumerable<SurveyRating> rating = (await repository.GetAllAsync(r => r.RatingCount == i)).Data ?? new List<SurveyRating>() { };
                result.AddRange(rating);

            }
            IReturnModel<IEnumerable<SurveyRating>> temp = result.Count > 0 ? new SuccessReturnModel<IEnumerable<SurveyRating>>(result) : new ErrorReturnModel<IEnumerable<SurveyRating>>(result);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(temp, mapper);
        }

        public IReturnModel<IEnumerable<GetSurveyRatingDTO>> GetByUserIdAndSurveyId(int userId, int surveyId)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = repository.GetAll(r => r.UserId == userId && r.SurveyId == surveyId);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyRatingDTO>>> GetByUserIdAndSurveyIdAsync(int userId, int surveyId)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = await repository.GetAllAsync(r => r.UserId == userId && r.SurveyId == surveyId);
            return ConvertToReturn<GetSurveyRatingDTO, SurveyRating>(result, mapper);
        }
    }
}
