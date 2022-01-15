using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Planner.Models;

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

            TaskList = new ObservableCollection<TaskVM>()
            {
                new TaskVM(new Task()),
                new TaskVM(new Task()),
                new TaskVM(new Task()),
                new TaskVM(new Task()),
                new TaskVM(new Task()),
                new TaskVM(new Task()),
            };

            

        }


    }
}
