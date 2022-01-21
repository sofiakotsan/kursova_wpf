using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Planner.Models
{
    public static class DataStorage
    {
        static private List<Task> tasks;

        public static List<Task> Tasks { 
            get { return tasks; }
            private set
            {
                tasks = value;
            }
        }

        static DataStorage ()
        {
            ReadTasks();

            List<Task> tasks = new List<Task>()
            {
                new Task("task 1", DateTime.Today, TaskPriority.High),
                new Task("task 2", DateTime.Today, TaskPriority.Low),
                new Task("task 3", DateTime.Today, TaskPriority.Medium),
                new Task("task 4", DateTime.Today, TaskPriority.High),
                new Task("task 5", DateTime.Today, TaskPriority.Medium),
                new Task("task 6", DateTime.Today, TaskPriority.High),
                new Task("task 7", DateTime.Today, TaskPriority.Low),
                new Task("task 8", DateTime.Today, TaskPriority.Low),
            };
        }

        private static void ReadTasks()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("tasks.dat", FileMode.OpenOrCreate))
            {
                

                List<Task> tasks = (List<Task>)formatter.Deserialize(fs);
            }
        }

        public static void SaveTasks()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("tasks.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, tasks);
            }
        }
    }
}
