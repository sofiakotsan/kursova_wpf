using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Models
{
    class TodoList
    {
        private List<Task> tasks;

        public List<Task> Tasks
        {
            get { return tasks; }
            private set { tasks = value; }
        }

        /*private List<string> tasks;

        public List<string> Tasks
        {
            get { return tasks; }
            private set { tasks = value; }
        }*/

        public TodoList()
        {
            ReadTasks();
        }

        private void ReadTasks()
        {
            Tasks = new List<Task>()
            {
                new Task("task 1", DateTime.Now, TaskPriority.Low, false),
                new Task("task 2", DateTime.Now, TaskPriority.High, true),
                new Task("task 3", DateTime.Now, TaskPriority.Medium, true),
                new Task("task 4", DateTime.Now, TaskPriority.Low, false),
                new Task("task 5", DateTime.Now, TaskPriority.Medium, true),
                new Task("task 6", DateTime.Now, TaskPriority.High, false),
                new Task("task 7", DateTime.Now, TaskPriority.Low, true)
            };

            /*Tasks = new List<string>()
            {
                "dsdsgdsgs",
                "dsdsgd dsfsgs",
                "dsdsgdsgs",
                "dsdsgdsgs",
                "dsdsgdsddfgs",
            };*/
        }

    }
}
