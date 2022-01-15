using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Models
{
    public enum TaskPriority
    {
        Low,
        Medium,
        High
    }
    public class Task
    {
        private string text;
        private DateTime date;
        private TaskPriority priority;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public TaskPriority Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        private bool isDone;

        public bool IsDone
        {
            get { return isDone; }
            set { isDone = value; }
        }


        public Task() : this ("empty", DateTime.Now, TaskPriority.Low, false) { }

        public Task(string text, DateTime date, TaskPriority priority, bool isDone)
        {
            Text = text;
            Date = date;
            Priority = priority;
            IsDone = isDone;
        }

    }
}
