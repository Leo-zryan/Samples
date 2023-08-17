namespace AutoDI.Service
{
    public class AutoDIService : IAutoDIService,ITransient
    {
        public int Return123()
        {
            return 123;
        }
    }
}
