using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Planner.Models;

namespace Planner.ViewModels
{
    class TaskVM : VMBase
    {
        private Task task;

        public Task Task
        {
            get { return task; }
            private set { task = value; }
        }

        public string Text
        {
            get { return task.Text; }
            set 
            {
                task.Text = value;
                OnPropertyChanged("Text");
            }
        }

        public DateTime Date
        {
            get { return task.Date; }
            set
            {
                task.Date = value;
                OnPropertyChanged("Date");
            }
        }

        public TaskPriority Priority
        {
            get { return task.Priority; }
            set
            {
                task.Priority = value;
                OnPropertyChanged("Priority");
            }
        }

        public bool IsDone
        {
            get { return task.IsDone; }
            set
            {
                task.IsDone = value;
                OnPropertyChanged("IsDone");
            }
        }

        public string Id
        {
            get { return task.Id; }
        }

        private bool isEdited;

        public bool IsEdited
        {
            get { return isEdited; }
            set 
            { 
                isEdited = value;
                OnPropertyChanged("isEdited");
            }
        }


        public TaskVM(Task task, bool isEdited = false)
        {
            Task = task;
            IsEdited = isEdited;
        }

    }
}
