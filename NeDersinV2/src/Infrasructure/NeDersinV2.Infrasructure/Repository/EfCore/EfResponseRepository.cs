
using NeDersinV2.Abstracts.Repository;
using NeDersinV2.Entities.Concrete;
using NeDersinV2.Infrasructure.Contexts;
using NeDersinV2.Infrasructure.Repository.EfCore.Base;

namespace NeDersinV2.Infrasructure.Repository.EfCore
{
    public sealed class EfResponseRepository : EfEntityRepositoryBase<Response, NeDersinV2Context>, IResponseRepository
    {
        public EfResponseRepository(NeDersinV2Context context) : base(context) { }
    }
}
