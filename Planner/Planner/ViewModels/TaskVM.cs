using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Planner.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Planner.ViewModels
{

    [Table("Tasks")]
    public class TaskVM : VMBase
    {
        private Task task;

        /*public Task Task
        {
            get { return task; }
            private set { task = value; }
        }*/

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

        [Key]
        public int Id
        {
            get { return task.Id; }
            set { task.Id = value; }
        }

        /*private bool isEdited;

        public bool IsEdited
        {
            get { return isEdited; }
            set
            {
                isEdited = value;
                OnPropertyChanged("isEdited");
            }
        }*/

        public TaskVM() : this(new Task()) {}

        public TaskVM(Task task/*, bool isEdited = false*/)
        {
            this.task = task;
            //IsEdited = isEdited;
        }

    }
}
