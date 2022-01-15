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

        private TaskPriority priority;

        public TaskPriority Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        Task() : this ("empty", DateTime.Now, TaskPriority.Low) { }

        public Task(string text, DateTime date, TaskPriority priority)
        {
            Text = text;
            Date = date;
            Priority = priority;
        }

    }
}
