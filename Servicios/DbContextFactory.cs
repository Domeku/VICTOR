namespace REPORTES.Services
{
    public static class DbContextFactory
    {
        public static PrestamosDBEntities Create()
        {
            return new PrestamosDBEntities();
        }
    }
}
