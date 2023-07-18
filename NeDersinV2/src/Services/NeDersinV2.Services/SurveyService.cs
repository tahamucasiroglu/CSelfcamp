using AutoMapper;
using NeDersinV2.Abstracts.Repository;
using NeDersinV2.Abstracts.Service;
using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels.Survey;
using NeDersinV2.Entities.Concrete;
using NeDersinV2.Returns.Abstract;
using NeDersinV2.Returns.Concrete;
using NeDersinV2.Services.Base;
using NeDersinV2.Mapper;
using NeDersinV2.Constants.Const;
using System.Linq.Expressions;
using NeDersinV2.Constants.Enums;

namespace NeDersinV2.Services
{
    public sealed class SurveyService : ServiceBase<Survey, GetSurveyDTO, VM_Create_Survey, VM_Update_Survey>, ISurveyService
    {
        private new readonly ISurveyRepository repository; //tip IRepository<IEntity> kaldığı için survey özel fonsiyonlarını bu sayede kullanabilirim
        public SurveyService(ISurveyRepository repository, IMapper mapper) : base(repository, mapper) { this.repository = repository; }

        public IReturnModel<GetSurveyDTO> GetById(int id)
        {
            IReturnModel<Survey> result = repository.Get(r => r.Id == id);
            return ConvertToReturn<GetSurveyDTO, Survey>(result, mapper);
        }

        public async Task<IReturnModel<GetSurveyDTO>> GetByIdAsync(int id)
        {
            IReturnModel<Survey> result = await repository.GetAsync(r => r.Id == id);
            return ConvertToReturn<GetSurveyDTO, Survey>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetSurveyDTO>> GetByTitle(string name)
        {
            IReturnModel<IEnumerable<Survey>> result = repository.GetAll(filter:r => r.Title.Contains(name));
            return ConvertToReturn<GetSurveyDTO, Survey>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyDTO>>> GetByTitleAsync(string name)
        {
            IReturnModel<IEnumerable<Survey>> result = await repository.GetAllAsync(r => r.Title.Contains(name));
            return ConvertToReturn<GetSurveyDTO, Survey>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetSurveyDTO>> GetByStartDate(DateTime dateTime, bool isEnd)
        {
            IReturnModel<IEnumerable<Survey>> result = repository.GetAll(r => r.Date > dateTime && r.IsEnd == isEnd);
            return ConvertToReturn<GetSurveyDTO, Survey>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyDTO>>> GetByStartDateAsync(DateTime dateTime, bool isEnd)
        {
            IReturnModel<IEnumerable<Survey>> result = await repository.GetAllAsync(r => r.Date > dateTime && r.IsEnd == isEnd);
            return ConvertToReturn<GetSurveyDTO, Survey>(result, mapper);
        }

        public IReturnModel<GetSurveyDTO> GetByAddress(Guid address)
        {
            IReturnModel<Survey> result = repository.Get(r => r.Address == address);
            return ConvertToReturn<GetSurveyDTO, Survey>(result, mapper);
        }

        public async Task<IReturnModel<GetSurveyDTO>> GetByAddressAsync(Guid address)
        {
            IReturnModel<Survey> result = await repository.GetAsync(r => r.Address == address);
            return ConvertToReturn<GetSurveyDTO, Survey>(result, mapper);
        }

        public IReturnModel<GetSurveyWithQuestions> GetByIdWithQuestions(int id)
        {
            IReturnModel<Survey> result = repository.GetByIncludeQuestions(r => r.Id == id);
            if (result.Status)
            {
                return result.Data == null ?
                    new SuccessReturnModel<GetSurveyWithQuestions>("data is null") :
                    new SuccessReturnModel<GetSurveyWithQuestions>(new GetSurveyWithQuestions(result.Data.ConvertToDto(mapper), result.Data.Questions.ConvertToDto(mapper) ));
            }
            return new ErrorReturnModel<GetSurveyWithQuestions>(result.Message, null, result.Exception);
        }

        public async Task<IReturnModel<GetSurveyWithQuestions>> GetByIdWithQuestionsAsync(int id)
        {
            IReturnModel<Survey> result = await repository.GetByIncludeQuestionsAsync(r => r.Id == id);
            if (result.Status)
            {
                return result.Data == null ?
                    new SuccessReturnModel<GetSurveyWithQuestions>("data is null") :
                    new SuccessReturnModel<GetSurveyWithQuestions>(new GetSurveyWithQuestions(result.Data.ConvertToDto(mapper), result.Data.Questions.ConvertToDto(mapper)));
            }
            return new ErrorReturnModel<GetSurveyWithQuestions>(result.Message, null, result.Exception);
        }

        public IReturnModel<GetSurveyWithQuestions> GetByAddressWithQuestions(Guid address)
        {
            IReturnModel<Survey> result = repository.GetByIncludeQuestions(r => r.Address == address);
            if (result.Status)
            {
                return result.Data == null ?
                    new SuccessReturnModel<GetSurveyWithQuestions>("data is null") :
                    new SuccessReturnModel<GetSurveyWithQuestions>(new GetSurveyWithQuestions(result.Data.ConvertToDto(mapper), result.Data.Questions.ConvertToDto(mapper)));
            }
            return new ErrorReturnModel<GetSurveyWithQuestions>(result.Message, null, result.Exception);
        }

        public async Task<IReturnModel<GetSurveyWithQuestions>> GetByAddressWithQuestionsAsync(Guid address)
        {
            IReturnModel<Survey> result = await repository.GetByIncludeQuestionsAsync(r => r.Address == address);
            if (result.Status)
            {
                return result.Data == null ?
                    new SuccessReturnModel<GetSurveyWithQuestions>("data is null") :
                    new SuccessReturnModel<GetSurveyWithQuestions>(new GetSurveyWithQuestions(result.Data.ConvertToDto(mapper), result.Data.Questions.ConvertToDto(mapper)));
            }
            return new ErrorReturnModel<GetSurveyWithQuestions>(result.Message, null, result.Exception);
        }

        public IReturnModel<GetSurveyWithQuestionAndAnswers> GetByIdWithQuestionsAndAnswers(int id)
        {
            IReturnModel<Survey> result = repository.GetByIncludeQuestionsAndAnswersValue(r => r.Id == id);
            if (result.Status && result.Data != null)
            {
                GetSurveyWithQuestionAndAnswers survey = new GetSurveyWithQuestionAndAnswers(
                    survey: result.Data.ConvertToDto(mapper),
                    questionAndAnswer: result.Data.Questions.Select(question => (question.ConvertToDto(mapper), question.Answers.ConvertToDto(mapper)))
                    );
                return new SuccessReturnModel<GetSurveyWithQuestionAndAnswers>(survey);
            }
            return new ErrorReturnModel<GetSurveyWithQuestionAndAnswers>();
        }

        public async Task<IReturnModel<GetSurveyWithQuestionAndAnswers>> GetByIdWithQuestionsAndAnswersAsync(int id)
        {
            IReturnModel<Survey> result = await repository.GetByIncludeQuestionsAndAnswersValueAsync(r => r.Id == id);
            if (result.Status && result.Data != null)
            {
                GetSurveyWithQuestionAndAnswers survey = new GetSurveyWithQuestionAndAnswers(
                    survey: result.Data.ConvertToDto(mapper),
                    questionAndAnswer: result.Data.Questions.Select(question => (question.ConvertToDto(mapper), question.Answers.ConvertToDto(mapper)))
                    );
                return new SuccessReturnModel<GetSurveyWithQuestionAndAnswers>(survey);
            }
            return new ErrorReturnModel<GetSurveyWithQuestionAndAnswers>();

        }

        public IReturnModel<GetSurveyWithQuestionAndAnswers> GetByAddressWithQuestionsAndAnswers(Guid address)
        {
            IReturnModel<Survey> result = repository.GetByIncludeQuestionsAndAnswersValue(r => r.Address == address);
            if (result.Status && result.Data != null)
            {
                GetSurveyWithQuestionAndAnswers survey = new GetSurveyWithQuestionAndAnswers(
                    survey: result.Data.ConvertToDto(mapper),
                    questionAndAnswer: result.Data.Questions.Select(question => (question.ConvertToDto(mapper), question.Answers.ConvertToDto(mapper)))
                    );
                return new SuccessReturnModel<GetSurveyWithQuestionAndAnswers>(survey);
            }
            return new ErrorReturnModel<GetSurveyWithQuestionAndAnswers>();
        }

        public async Task<IReturnModel<GetSurveyWithQuestionAndAnswers>> GetByAddressWithQuestionAndAnswersAsync(Guid address)
        {
            IReturnModel<Survey> result = await repository.GetByIncludeQuestionsAndAnswersValueAsync(r => r.Address == address);
            if (result.Status && result.Data != null)
            {
                GetSurveyWithQuestionAndAnswers survey = new GetSurveyWithQuestionAndAnswers(
                    survey: result.Data.ConvertToDto(mapper),
                    questionAndAnswer: result.Data.Questions.Select(question => (question.ConvertToDto(mapper), question.Answers.ConvertToDto(mapper)))
                    );
                return new SuccessReturnModel<GetSurveyWithQuestionAndAnswers>(survey);
            }
            return new ErrorReturnModel<GetSurveyWithQuestionAndAnswers>();
        }

        public IReturnModel<GetSurveyPaginationDTO> GetByPagination(int pageNumber, int pageSize, string order, string shortType)
        {
            
            IReturnModel<int> count = repository.Count(r => !r.IsEnd);
            int totalCount = count.Status ? count.Data : 0;
            int totalPage = (int)Math.Ceiling((double)totalCount / pageSize);
            int pageNum = pageNumber;
            if (pageNum < 1) { pageNum = 1; }
            if (pageNum > totalPage) { pageNum = totalPage; }
            int start = (pageNum - 1) * pageSize;
            int end = start + pageSize;
            if (end > totalCount) { end = totalCount; }

            bool reserve = shortType == ShortTypeConst.DESC;

            IReturnModel<IEnumerable<GetSurveyPaginationListDTO>> result = order switch
            {
                nameof(OrderTypeEnum.EndDate) => repository.GetByPagination(
                    select: r => new GetSurveyPaginationListDTO(r.Address, r.UserId, r.User.Name + r.User.Surname, r.Title),
                    order: r => r.EndTime ?? DateTime.MinValue,
                    filter: r => !r.IsEnd,
                    Reserve: reserve,
                    TakeRange: new Range(^start, ^end),
                    include: r => r.User),

                nameof(OrderTypeEnum.ResponseCount) => repository.GetByPagination(
                    select: r => new GetSurveyPaginationListDTO(r.Address, r.UserId, r.User.Name + r.User.Surname, r.Title),
                    order: r => r.ResponseCount,
                    filter: r => !r.IsEnd,
                    Reserve: reserve,
                    TakeRange: new Range(^start, ^end),
                    include: r => r.User),

                nameof(OrderTypeEnum.Rating) => repository.GetByPagination(
                    select: r => new GetSurveyPaginationListDTO(r.Address, r.UserId, r.User.Name + r.User.Surname, r.Title),
                    order: r => r.Rating,
                    filter: r => !r.IsEnd,
                    Reserve: reserve,
                    TakeRange: new Range(^start, ^end),
                    include: r => r.User),

                _ => repository.GetByPagination(
                    select: r => new GetSurveyPaginationListDTO(r.Address, r.UserId, r.User.Name + r.User.Surname, r.Title),
                    order: r => r.Date,
                    filter: r => !r.IsEnd,
                    Reserve: reserve,
                    TakeRange: new Range(^start, ^end),
                    include: r => r.User)
            };
            if (!result.Status) return new ErrorReturnModel<GetSurveyPaginationDTO>();
            return new SuccessReturnModel<GetSurveyPaginationDTO>(new GetSurveyPaginationDTO(result.Data ?? new List<GetSurveyPaginationListDTO>(), order, shortType));
        }

        public async Task<IReturnModel<GetSurveyPaginationDTO>> GetByPaginationAsync(int pageNumber, int pageSize, string order, string shortType)
        {

            IReturnModel<int> count = await repository.CountAsync(r => !r.IsEnd);
            int totalCount = count.Status ? count.Data : 0;
            int totalPage = (int)Math.Ceiling((double)totalCount / pageSize);
            int pageNum = pageNumber;
            if (pageNum < 1) { pageNum = 1; }
            if (pageNum > totalPage) { pageNum = totalPage; }
            int start = (pageNum - 1) * pageSize;
            int end = start + pageSize;
            if (end > totalCount) { end = totalCount; }

            bool reserve = shortType == ShortTypeConst.DESC;

            IReturnModel<IEnumerable<GetSurveyPaginationListDTO>> result = order switch
            {
                nameof(OrderTypeEnum.EndDate) => await repository.GetByPaginationAsync(
                    select: r => new GetSurveyPaginationListDTO(r.Address, r.UserId, r.User.Name + r.User.Surname, r.Title),
                    order: r => r.EndTime ?? DateTime.MinValue,
                    filter: r => !r.IsEnd,
                    Reserve: reserve,
                    TakeRange: new Range(^start, ^end),
                    include: r => r.User),

                nameof(OrderTypeEnum.ResponseCount) => await repository.GetByPaginationAsync(
                    select: r => new GetSurveyPaginationListDTO(r.Address, r.UserId, r.User.Name + r.User.Surname, r.Title),
                    order: r => r.ResponseCount,
                    filter: r => !r.IsEnd,
                    Reserve: reserve,
                    TakeRange: new Range(^start, ^end),
                    include: r => r.User),

                nameof(OrderTypeEnum.Rating) => await repository.GetByPaginationAsync(
                    select: r => new GetSurveyPaginationListDTO(r.Address, r.UserId, r.User.Name + r.User.Surname, r.Title),
                    order: r => r.Rating,
                    filter: r => !r.IsEnd,
                    Reserve: reserve,
                    TakeRange: new Range(^start, ^end),
                    include: r => r.User),

                _ => await repository.GetByPaginationAsync(
                    select: r => new GetSurveyPaginationListDTO(r.Address, r.UserId, r.User.Name + r.User.Surname, r.Title),
                    order: r => r.Date,
                    filter: r => !r.IsEnd,
                    Reserve: reserve,
                    TakeRange: new Range(^start, ^end),
                    include: r => r.User)
            };
            if (!result.Status) return new ErrorReturnModel<GetSurveyPaginationDTO>();
            return new SuccessReturnModel<GetSurveyPaginationDTO>(new GetSurveyPaginationDTO(result.Data ?? new List<GetSurveyPaginationListDTO>(), order, shortType));
        }
    }
}