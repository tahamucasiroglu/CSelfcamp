using NeDersinV2.Abstracts.Repository.Base;
using NeDersinV2.Entities.Abstract;
using NeDersinV2.Entities.Concrete;
using NeDersinV2.Returns.Abstract;
using System.Linq.Expressions;

namespace NeDersinV2.Abstracts.Repository
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        public IReturnModel<Survey> GetByIncludeQuestions(Expression<Func<Survey, bool>> filter);
        public Task<IReturnModel<Survey>> GetByIncludeQuestionsAsync(Expression<Func<Survey, bool>> filter);
        public IReturnModel<Survey> GetByIncludeQuestionsAndAnswers(Expression<Func<Survey, bool>> filter);
        public Task<IReturnModel<Survey>> GetByIncludeQuestionsAndAnswersAsync(Expression<Func<Survey, bool>> filter);
        public IReturnModel<Survey> GetByIncludeQuestionsAndAnswersValue(Expression<Func<Survey, bool>> filter);
        public Task<IReturnModel<Survey>> GetByIncludeQuestionsAndAnswersValueAsync(Expression<Func<Survey, bool>> filter);
        public IReturnModel<Survey> GetSurveyWithUser(Expression<Func<Survey, bool>> filter);
        public Task<IReturnModel<Survey>> GetSurveyWithUserAsync(Expression<Func<Survey, bool>> filter);
        public IReturnModel<IEnumerable<Survey>> GetAllSurveyWithUser(Expression<Func<Survey, bool>>? filter = null, Range Take = new());
        public IReturnModel<IEnumerable<Survey>> GetAllSurveyWithUser<Tout>(Expression<Func<Survey, bool>>? filter, Expression<Func<Survey, Tout>> order, Range Take = new());
        public Task<IReturnModel<IEnumerable<Survey>>> GetAllSurveyWithUserAsync(Expression<Func<Survey, bool>>? filter = null, Range Take = new());
        public Task<IReturnModel<IEnumerable<Survey>>> GetAllSurveyWithUserAsync<Tout>(Expression<Func<Survey, bool>>? filter, Expression<Func<Survey, Tout>> order, Range Take = new());
        public IReturnModel<IEnumerable<TSelect>> GetByPagination<TOrder, TSelect>(Func<Survey, TSelect> select, Func<Survey, bool>? filter = null, Func<Survey, TOrder>? order = null, bool Reserve = false, Range? TakeRange = null, Expression<Func<Survey, IEntity>>? include = null);
        public Task<IReturnModel<IEnumerable<TSelect>>> GetByPaginationAsync<TOrder, TSelect>(Func<Survey, TSelect> select, Func<Survey, bool>? filter = null, Func<Survey, TOrder>? order = null, bool Reserve = false, Range? TakeRange = null, Expression<Func<Survey, IEntity>>? include = null);

    }
}
