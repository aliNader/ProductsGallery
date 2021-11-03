//using DataAccessLayer.Interfaces;

//namespace DataAccessLayer.Repositories
//{
//    /// <summary>
//    /// I Never Use It Till Now
//    /// </summary>
//    public class UnitOfWork : IUnitOfWork
//    {

//        public SuperMarketDbContext SuperMarketDbContext { get; set; }

//        public UnitOfWork(SuperMarketDbContext superMarketDbContext)
//        {
//            SuperMarketDbContext = superMarketDbContext;
//        }

//        public int Complete()
//        {
//            return SuperMarketDbContext.SaveChanges();
//        }
//    }
//}
