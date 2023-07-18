
using NeDersinV2.Abstracts.Repository;
using NeDersinV2.Entities.Concrete;
using NeDersinV2.Infrasructure.Contexts;
using NeDersinV2.Infrasructure.Repository.EfCore.Base;

namespace NeDersinV2.Infrasructure.Repository.EfCore
{

    public sealed class EfUserRepository : EfEntityRepositoryBase<User, NeDersinV2Context>, IUserRepository
    {
        public EfUserRepository(NeDersinV2Context context) : base(context) { }
    }
}
