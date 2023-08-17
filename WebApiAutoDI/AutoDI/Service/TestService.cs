namespace AutoDI.Service
{
    public class TestService : ITestService
    {
        public int Sum(int x, int y)
        {
            return x + y;
        }
    }
}
