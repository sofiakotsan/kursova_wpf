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

        public TodoList()
        {
            ReadTasks();
        }

        private void ReadTasks()
        {
            Tasks = new List<Task>()
            {
                new Task("task 1", DateTime.Now, TaskPriority.Low),
                new Task("task 2", DateTime.Now, TaskPriority.Low),
                new Task("task 3", DateTime.Now, TaskPriority.Low),
                new Task("task 4", DateTime.Now, TaskPriority.Low),
                new Task("task 5", DateTime.Now, TaskPriority.Low),
                new Task("task 6", DateTime.Now, TaskPriority.Low),
                new Task("task 7", DateTime.Now, TaskPriority.Low)
            };
        }

    }
}
