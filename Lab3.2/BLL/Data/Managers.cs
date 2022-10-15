using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class Managers : IPersons
    {
        private readonly List<CurrentManager> _managers = new List<CurrentManager>();

        public void Add(CurrentPerson manager)
        {
            _managers.Add((CurrentManager)manager);
        }

        public CurrentPerson Find(SearchOptions options)
        {
            return _managers.Find(x => x.FirstName.Contains(options.FirstName) &&
                                       x.LastName.Contains(options.LastName) &&
                                       x.Salary.Contains(options.Salary) &&
                                       x.CountOfSubordinates.ToString().Contains(options.CountOfSubordinatesntOf));
        }

        public List<CurrentPerson> FindAll(SearchOptions options)
        {
            return _managers.FindAll(x => x.FirstName.Contains(options.FirstName) &&
                                          x.LastName.Contains(options.LastName) &&
                                          x.Salary.Contains(options.Salary) &&
                                          x.CountOfSubordinates.ToString().Contains(options.CountOfSubordinatesntOf))
                .Cast<CurrentPerson>().ToList();
        }

        public void Remove(CurrentPerson manager)
        {
            _managers.Remove((CurrentManager)manager);
        }

        public void Clear()
        {
            _managers.Clear();
        }

        public List<CurrentPerson> GetData()
        {
            return _managers.Cast<CurrentPerson>().ToList();
        }
    }
}