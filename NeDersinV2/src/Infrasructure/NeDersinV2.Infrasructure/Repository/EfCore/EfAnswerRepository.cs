using NeDersinV2.Abstracts.Repository;
using NeDersinV2.Entities.Concrete;
using NeDersinV2.Infrasructure.Contexts;
using NeDersinV2.Infrasructure.Repository.EfCore.Base;

namespace NeDersinV2.Infrasructure.Repository.EfCore
{ 
    public sealed class EfAnswerRepository : EfEntityRepositoryBase<Answer, NeDersinV2Context>, IAnswerRepository
    {
        public EfAnswerRepository(NeDersinV2Context context) : base(context) { }
    }
}
