namespace ProductKata.Domain.Repository
{
    public class UnitOfWork
    {
        public ISellHistoryRepository SellHistory { get; }
        public IPriceRepository Price { get; }
        public IProductCatalogRepository ProductCatalog { get; }
        public IUserRepository User { get; }

        public UnitOfWork(
            ISellHistoryRepository sellHistory,
            IPriceRepository price,
            IProductCatalogRepository productCatalog,
            IUserRepository user)
        {
            this.SellHistory = sellHistory;
            this.Price = price;
            this.ProductCatalog = productCatalog;
            this.User = user;
        }
    }
}
