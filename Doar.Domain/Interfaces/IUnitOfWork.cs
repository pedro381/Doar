namespace Doar.Domain.Interface {
    public interface IUnitOfWork {

        void BeginTransaction();
        int Commit();

    }
}
