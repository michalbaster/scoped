namespace Scoped
{
    public class Repo : IRepo
    {
        private string _id;

        public void Set(string id)
        {
            _id = id;
        }

        public string Get()
        {
            return _id;
        }
    }
}