using Scheduler.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler.Controller
{
    public class ScheduleMaker
    {
        public static SchedulerContext DB;
        public static int weeks = 2;
        public static int days = 7;
        public static int lessonsInADay = 10;

        public ScheduleMaker(SchedulerContext db)
        {
            DB = db;
        }


        public Lesson[,,,] CreateSchedule()
        {
            int GroupsCount = DB.Groups.Count();
            Lesson[,,,] Schedule = new Lesson[weeks, days, lessonsInADay, GroupsCount];
            Lesson[] Lessons = DB.Lessons.ToArray();
            Lessons = MergeSort(Lessons);
            int[] Hours = new int[Lessons.Count()];
            
            for(int i = 0; i< Lessons.Count(); i++)
            {
                //Hours[i] = Lessons[i].HoursPlan;
            }

            for(int i = 0; i < lessonsInADay; i++)
            {
                for (int j = 0; j < days; j++)
                {

                }
            }

            return Schedule;
        }

        static void Merge(Lesson[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new Lesson[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                //if (array[left].HoursPlan > array[right].HoursPlan)
                //{
                //    tempArray[index] = array[left];
                //    left++;
                //}
                //else
                //{
                //    tempArray[index] = array[right];
                //    right++;
                //}

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

        
        static Lesson[] MergeSort(Lesson[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        static Lesson[] MergeSort(Lesson[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }




    }
}
