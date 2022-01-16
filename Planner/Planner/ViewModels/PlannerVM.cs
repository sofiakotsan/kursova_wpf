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
        private ObservableCollection<TaskVM> taskList;
        private ObservableCollection<TaskVM> currentTaskList;
        private RelayCommand addCommand;
        private RelayCommand deleteCommand;
        private DateTime selectedDate;

        public ObservableCollection<TaskVM> TaskList
        {
            get { return taskList; }
            set { taskList = value; }
        }
        public ObservableCollection<TaskVM> CurrentTaskList
        {
            get { return currentTaskList; }
            set { currentTaskList = value; }
        }
        public IEnumerable<TaskPriority> Priorities
        {
            get
            {
                return Enum.GetValues(typeof(TaskPriority)).Cast<TaskPriority>();
            }
        }
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand;
            }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set 
            { 
                selectedDate = value;
                OnPropertyChanged("isEdited");
                SetTasksByDate(value);
            }
        }
        public PlannerVM()
        {
            TaskList = new ObservableCollection<TaskVM>()
            {
                new TaskVM(new Task("task 1")),
                new TaskVM(new Task("task 2")),
                new TaskVM(new Task("task 3")),
                new TaskVM(new Task("task 4")),
                new TaskVM(new Task("task 5")),
                new TaskVM(new Task("task 6")),
            };

            CurrentTaskList = new ObservableCollection<TaskVM>();

            SelectedDate = DateTime.Today;
            SetTasksByDate(SelectedDate);

            addCommand = new RelayCommand(AddTask);
            deleteCommand = new RelayCommand(DeleteTask);
        }

        private void AddTask(object obj)
        {
            TaskVM newTask = new TaskVM(new Task("New Task"));
            TaskList.Add(newTask);
            CurrentTaskList.Add(newTask);
        }
        private void DeleteTask(object obj)
        {
            if (MessageBox.Show("Are you sure you want to delete this task?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CurrentTaskList.Remove((TaskVM)obj);
                TaskList.Remove((TaskVM)obj);
            }
        }
        private void SetTasksByDate(DateTime date)
        {
            CurrentTaskList.Clear();

            foreach (var task in TaskList)
            {
                if (task.Date == date)
                {
                    CurrentTaskList.Add(task);
                }
            }

        }


    }
}
