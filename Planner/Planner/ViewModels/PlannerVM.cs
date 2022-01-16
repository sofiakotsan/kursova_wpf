using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Planner.Models;

using System.Windows;


namespace Planner.ViewModels
{
    class PlannerVM : VMBase
    {
        // private TodoList taskList;

        /*public TodoList TaskList
        {
            get { return taskList; }
            set { taskList = value; }
        }*/

        private ObservableCollection<TaskVM> taskList;

        public ObservableCollection<TaskVM> TaskList
        {
            get { return taskList; }
            set { taskList = value; }
        }

        private Dictionary<string, TaskPriority> priorities;

        public IEnumerable<TaskPriority> Priorities
        {
            get
            {
                return Enum.GetValues(typeof(TaskPriority)).Cast<TaskPriority>();
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand;/*??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Phone phone = new Phone();
                      Phones.Insert(0, phone);
                      SelectedPhone = phone;
                  }));*/
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }

        public PlannerVM()
        {

            priorities = new Dictionary<string, TaskPriority>()
            {
                {"Low", TaskPriority.Low },
                {"Medium", TaskPriority.Medium },
                {"High", TaskPriority.High }
            };

            addCommand = new RelayCommand(obj =>
            {
                TaskList.Add(new TaskVM(new Task()));
                /*TaskVM phone = new Phone();
                Phones.Insert(0, phone);
                SelectedPhone = phone;*/
            });

            deleteCommand = new RelayCommand(obj =>
            {
                if (MessageBox.Show("Are you sure you want to delete this task?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    taskList.Remove((TaskVM)obj);
                }
            });

            TaskList = new ObservableCollection<TaskVM>()
            {
                new TaskVM(new Task("task 1")),
                new TaskVM(new Task("task 2")),
                new TaskVM(new Task("task 3")),
                new TaskVM(new Task("task 4")),
                new TaskVM(new Task("task 5")),
                new TaskVM(new Task("task 6")),
            };

            

        }


    }
}
