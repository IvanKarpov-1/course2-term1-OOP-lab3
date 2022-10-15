using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class Students : IPersons
    {
        private readonly List<CurrentStudent> _students = new List<CurrentStudent>();

        public void Add(CurrentPerson student)
        {
            _students.Add((CurrentStudent)student);
        }

        public CurrentPerson Find(SearchOptions options)
        {
            return _students.Find(x => x.FirstName.Contains(options.FirstName) &&
                                       x.LastName.Contains(options.LastName) &&
                                       x.StudentId.Contains(options.StudentId) &&
                                       x.NumberOfScorebook.Contains(options.NumberOfScorebook) &&
                                       x.Course.Contains(options.Course) && 
                                       x.Country.Contains(options.Country));
        }

        public List<CurrentPerson> FindAll(SearchOptions options)
        {
            return _students.FindAll(x => x.FirstName.Contains(options.FirstName) &&
                                          x.LastName.Contains(options.LastName) &&
                                          x.StudentId.Contains(options.StudentId) &&
                                          x.NumberOfScorebook.Contains(options.NumberOfScorebook) &&
                                          x.Course.Contains(options.Course) &&
                                          x.Country.Contains(options.Country)).Cast<CurrentPerson>().ToList();
        }


        public void Remove(CurrentPerson student)
        {
            _students.Remove((CurrentStudent)student);
        }

        public void Clear()
        {
            _students.Clear();
        }

        public List<CurrentPerson> GetData()
        {
            return _students.Cast<CurrentPerson>().ToList();
        }
    }
}
