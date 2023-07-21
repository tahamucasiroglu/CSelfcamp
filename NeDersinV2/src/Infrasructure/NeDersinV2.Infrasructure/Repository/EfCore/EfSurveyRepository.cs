
using Microsoft.EntityFrameworkCore;
using NeDersinV2.Abstracts.Repository;
using NeDersinV2.Entities.Abstract;
using NeDersinV2.Entities.Concrete;
using NeDersinV2.Infrasructure.Contexts;
using NeDersinV2.Infrasructure.Repository.EfCore.Base;
using NeDersinV2.Returns.Abstract;
using NeDersinV2.Returns.Concrete;
using System.Linq;
using System.Linq.Expressions;

namespace NeDersinV2.Infrasructure.Repository.EfCore
{
    public sealed class EfSurveyRepository : EfEntityRepositoryBase<Survey, NeDersinV2Context>, ISurveyRepository
    {
        public EfSurveyRepository(NeDersinV2Context context) : base(context) { }

        public IReturnModel<Survey> GetByIncludeQuestions(Expression<Func<Survey, bool>> filter)
        {
            Survey? result = context.Surveys.Include(s => s.Questions).AsNoTracking().FirstOrDefault(filter);
            return CheckIsNull(result);
        }

        public async Task<IReturnModel<Survey>> GetByIncludeQuestionsAsync(Expression<Func<Survey, bool>> filter)
        {
            Survey? result = await context.Surveys.Include(s => s.Questions).AsNoTracking().FirstOrDefaultAsync(filter);
            return CheckIsNull(result);
        }
        public IReturnModel<Survey> GetByIncludeQuestionsAndAnswers(Expression<Func<Survey, bool>> filter)
        {
            Survey? result = context.Surveys.Include(s => s.Questions).ThenInclude(s => s.Answers).AsNoTracking().FirstOrDefault(filter);
            return CheckIsNull(result);
        }
        public async Task<IReturnModel<Survey>> GetByIncludeQuestionsAndAnswersAsync(Expression<Func<Survey, bool>> filter)
        {
            Survey? result = await context.Surveys.Include(s => s.Questions).ThenInclude(s => s.Answers).AsNoTracking().FirstOrDefaultAsync(filter);
            return CheckIsNull(result);
        }
        public IReturnModel<Survey> GetSurveyWithUser(Expression<Func<Survey, bool>> filter)
        {
            Survey? result = context.Surveys.Include(s => s.User).AsNoTracking().FirstOrDefault(filter);
            return CheckIsNull(result);
        }

        public async Task<IReturnModel<Survey>> GetSurveyWithUserAsync(Expression<Func<Survey, bool>> filter)
        {
            Survey? result = await context.Surveys.Include(s => s.User).AsNoTracking().FirstOrDefaultAsync(filter);
            return CheckIsNull(result);
        }

        public IReturnModel<IEnumerable<Survey>> GetAllSurveyWithUser<Tout>(Expression<Func<Survey, bool>>? filter, Expression<Func<Survey, Tout>> order, Range Take = default)
        {
            IEnumerable<Survey>? result = (filter == null ? context.Surveys.Include(s => s.User).AsNoTracking().OrderBy(order) : context.Surveys.Include(s => s.User).AsNoTracking().Where(filter).OrderBy(order)).Take(Take);
            return CheckIsNull(result);
        }

        public async Task<IReturnModel<IEnumerable<Survey>>> GetAllSurveyWithUserAsync<Tout>(Expression<Func<Survey, bool>>? filter, Expression<Func<Survey, Tout>> order, Range Take)
        {
            IEnumerable<Survey>? result = await Task.FromResult<IEnumerable<Survey>>((filter == null ? context.Surveys.Include(s => s.User).AsNoTracking().OrderBy(order) : context.Surveys.Include(s => s.User).AsNoTracking().Where(filter).OrderBy(order)).Take(Take));
            return CheckIsNull(result);
        }

        public IReturnModel<IEnumerable<Survey>> GetAllSurveyWithUser(Expression<Func<Survey, bool>>? filter = null, Range Take = default)
        {
            IEnumerable<Survey>? result = (filter == null ? context.Surveys.Include(s => s.User).AsNoTracking() : context.Surveys.Include(s => s.User).AsNoTracking().Where(filter)).Take(Take);
            return CheckIsNull(result);
        }

        public async Task<IReturnModel<IEnumerable<Survey>>> GetAllSurveyWithUserAsync(Expression<Func<Survey, bool>>? filter = null, Range Take = default)
        {
            IEnumerable<Survey>? result = await Task.FromResult<IEnumerable<Survey>>((filter == null ? context.Surveys.Include(s => s.User).AsNoTracking() : context.Surveys.Include(s => s.User).AsNoTracking().Where(filter)).Take(Take));
            return CheckIsNull(result);
        }

        public IReturnModel<Survey> GetByIncludeQuestionsAndAnswersValue(Expression<Func<Survey, bool>> filter)
        {
            Survey? result = context.Surveys.Include(s => s.Questions).ThenInclude(s => s.Answers).ThenInclude(s => s.AnswerValue).AsNoTracking().FirstOrDefault(filter);
            return CheckIsNull(result);
        }

        public async Task<IReturnModel<Survey>> GetByIncludeQuestionsAndAnswersValueAsync(Expression<Func<Survey, bool>> filter)
        {
            Survey? result = await context.Surveys.Include(s => s.Questions).ThenInclude(s => s.Answers).ThenInclude(s => s.AnswerValue).AsNoTracking().FirstOrDefaultAsync(filter);
            return CheckIsNull(result);
        }

        public IReturnModel<IEnumerable<TSelect>> GetByPagination<TOrder, TSelect>(
            Func<Survey, TSelect> select,
            Func<Survey, bool>? filter = null, 
            Func<Survey, TOrder>? order = null, 
            bool Reserve = false, Range? TakeRange = null, 
            Expression<Func<Survey, IEntity>>? include = null)
        {
            IEnumerable<Survey> result = (include == null) ? context.Surveys.AsNoTracking() : context.Surveys.Include(include).AsNoTracking();
            if (filter != null) result = result.Where(filter);
            if (order != null) result = result.OrderBy(order);
            if (TakeRange != null) result = result.Take(TakeRange.Value);
            if (Reserve) result = result.Reverse();
            return CheckIsNull(result.Select(select));
        }

        public async Task<IReturnModel<IEnumerable<TSelect>>> GetByPaginationAsync<TOrder, TSelect>(
            Func<Survey, TSelect> select,
            Func<Survey, bool>? filter = null,
            Func<Survey, TOrder>? order = null,
            bool Reserve = false, Range? TakeRange = null,
            Expression<Func<Survey, IEntity>>? include = null)
        {
            IEnumerable<Survey> result = (include == null) ? context.Surveys.AsQueryable() : context.Surveys.Include(include);
            if (filter != null) result = result.Where(filter);
            if (order != null) result = result.OrderBy(order);
            if (TakeRange != null) result = result.Take(TakeRange.Value);
            if (Reserve) result = result.Reverse();
            return await Task.FromResult(CheckIsNull<IEnumerable<TSelect>>(result.Select(select)));
        }
    }
}
