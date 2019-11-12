using Scheduler.Controller;
using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Infrastructure
{
    class Individuum
    {
        Random rnd = new Random();
        public Lesson[,,,] Chromosome { get; set; }
        int GroupsCount = 0;

        public Individuum(Lesson[,,,] chromosome, int groupsCount)
        {
            Chromosome = chromosome;
            GroupsCount = groupsCount;
        }

        public Individuum Crossing(Individuum SecondIndividuum)
        {
            int mid = this.Chromosome.GetLength(1);
            Lesson[,,,] NewChromosome = new Lesson[ScheduleMaker.weeks, ScheduleMaker.days, ScheduleMaker.lessonsInADay, GroupsCount];
            for (int w = 0; w < mid; w++)
            {
                for (int d = 0; d < ScheduleMaker.days; d++)
                {
                    for (int l = 0; l < ScheduleMaker.lessonsInADay; l++)
                    {
                        for (int g = 0; g < GroupsCount; g++)
                        {
                            NewChromosome[w, d, l, g] = this.Chromosome[w, d, l, g];
                            NewChromosome[mid + w, d, l, g] = SecondIndividuum.Chromosome[mid + w, d, l, g];
                        }
                    }
                }
            }
            
            Individuum ResultInd = new Individuum(NewChromosome, GroupsCount);
            ResultInd.Mutation(rnd.Next(0, ScheduleMaker.weeks), 
                               rnd.Next(0, ScheduleMaker.days), 
                               rnd.Next(0, ScheduleMaker.lessonsInADay), 
                               rnd.Next(0, GroupsCount));
            return ResultInd;
        }

        public void Mutation(int indexWeeks, int indexDays, int indexLessons, int indexGroups)
        {
            if (rnd.Next(0, 101) <= 60)
            {
                for (int g = 0; g < GroupsCount; g++)
                {
                    if ()
                }
            }   
        }
    }
}
