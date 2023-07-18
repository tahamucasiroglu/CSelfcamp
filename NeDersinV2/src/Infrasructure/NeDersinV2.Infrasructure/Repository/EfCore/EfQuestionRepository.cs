
using NeDersinV2.Abstracts.Repository;
using NeDersinV2.Entities.Concrete;
using NeDersinV2.Infrasructure.Contexts;
using NeDersinV2.Infrasructure.Repository.EfCore.Base;

namespace NeDersinV2.Infrasructure.Repository.EfCore
{

    public sealed class EfQuestionRepository : EfEntityRepositoryBase<Question, NeDersinV2Context>, IQuestionRepository
    {
        public EfQuestionRepository(NeDersinV2Context context) : base(context) { }
    }
}
