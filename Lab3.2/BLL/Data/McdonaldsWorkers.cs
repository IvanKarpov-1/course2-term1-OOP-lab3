using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class McdonaldsWorkers : IPersons
    {
        private readonly List<CurrentMcdonaldsWorker> _mcdonaldsWorkers = new List<CurrentMcdonaldsWorker>();

        public void Add(CurrentPerson mcdonaldsWorker)
        {
            _mcdonaldsWorkers.Add((CurrentMcdonaldsWorker)mcdonaldsWorker);
        }

        public CurrentPerson Find(SearchOptions options)
        {
            return _mcdonaldsWorkers.Find(x => x.FirstName.Contains(options.FirstName) &&
                                               x.LastName.Contains(options.LastName) &&
                                               x.Salary.Contains(options.Salary) &&
                                               x.Diploma.ToString().Contains(options.Diploma.ToString()));
        }

        public List<CurrentPerson> FindAll(SearchOptions options)
        {
            return _mcdonaldsWorkers.FindAll(x => x.FirstName.Contains(options.FirstName) &&
                                                  x.LastName.Contains(options.LastName) &&
                                                  x.Salary.Contains(options.Salary) &&
                                                  x.Diploma.ToString().Contains(options.Diploma.ToString()))
                .Cast<CurrentPerson>().ToList();
        }

        public void Remove(CurrentPerson mcdonaldsWorker)
        {
            _mcdonaldsWorkers.Remove((CurrentMcdonaldsWorker)mcdonaldsWorker);
        }

        public void Clear()
        {
            _mcdonaldsWorkers.Clear();
        }

        public List<CurrentPerson> GetData()
        {
            return _mcdonaldsWorkers.Cast<CurrentPerson>().ToList();
        }
    }
}