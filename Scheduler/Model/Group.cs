using Scheduler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Model
{
    public class Group : IGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public Group(string name, int year)
        {
            this.Name = name;
            this.Year = year;
        }

        public Group()
        {
        }

        public Group Get(List<Group> Groups, int ind)
        {
            return Groups.ElementAt(ind);
        }

        public void Add(List<Group> Groups, string name, int year)
        {
            Groups.Add(new Group(name, year));
        }

        public void Edit(List<Group> Groups, string name, int year, int ind)
        {
            Groups.Insert(ind, new Group(name, year));
        }

        public void DeleteByIndex(List<Group> Groups, int index)
        {
            Groups.RemoveAt(index);
        }

        public void DeleteLast(List<Group> Groups)
        {
            Groups.RemoveAt(Groups.Count - 1);
        }
    }
}
