namespace Scoped
{
    public class Screen : IScreen
    {
        private readonly IRepo _repo;

        public Screen(IRepo repo)
        {
            _repo = repo;
        }

        public string Show()
        {
            return _repo.Get();
        }
    }
}