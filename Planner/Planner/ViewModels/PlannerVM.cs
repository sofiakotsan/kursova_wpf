using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Planner.Models;
using System.Windows;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;

namespace Planner.ViewModels
{
    class PlannerVM : VMBase
    {
        // private ObservableCollection<TaskVM> taskList;
        private ObservableCollection<TaskVM> currentTaskList;
        private RelayCommand addCommand;
        private RelayCommand deleteCommand;
        private RelayCommand closeWindowCommand;
        private DateTime selectedDate;
        private ApplicationContext db;

        private IEnumerable<TaskVM> tasks;

        public IEnumerable<TaskVM> Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }


        private IEnumerable<TaskVM> currentTasks;

        public IEnumerable<TaskVM> CurrentTasks
        {
            get { return currentTasks; }
            set { currentTasks = value; }
        }


        /*public ObservableCollection<TaskVM> TaskList
        {
            get { return taskList; }
            set { taskList = value; }
        }*/
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
        public RelayCommand CloseWindowCommand
        {
            get
            {
                return closeWindowCommand;
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
            /*TaskList = new ObservableCollection<TaskVM>()
            {
                new TaskVM(new Task("task 1")),
                new TaskVM(new Task("task 2")),
                new TaskVM(new Task("task 3")),
                new TaskVM(new Task("task 4")),
                new TaskVM(new Task("task 5")),
                new TaskVM(new Task("task 6")),
            };*/

            db = new ApplicationContext();
            db.Tasks.Load();
            Tasks = db.Tasks.Local.ToBindingList();

            CurrentTaskList = new ObservableCollection<TaskVM>();

            CurrentTasks = db.Tasks.Where(task => task.Date == SelectedDate).ToList();

            SelectedDate = DateTime.Today;
            SetTasksByDate(SelectedDate);

            addCommand = new RelayCommand(AddTask);
            deleteCommand = new RelayCommand(DeleteTask);
            closeWindowCommand = new RelayCommand(CloseWindow);
        }

        private void AddTask(object obj)
        {
            /*TaskVM newTask = new TaskVM(new Task("New Task"));
            TaskList.Add(newTask);
            CurrentTaskList.Add(newTask);*/

            db.Tasks.Add(new TaskVM(new Task("New Task", SelectedDate)));
            db.SaveChanges();
            SetTasksByDate(SelectedDate);
        }
        private void DeleteTask(object obj)
        {
            if (MessageBox.Show("Are you sure you want to delete this task?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                /*CurrentTaskList.Remove((TaskVM)obj);
                TaskList.Remove((TaskVM)obj);*/

                db.Tasks.Remove((TaskVM)obj);
                db.SaveChanges();
                SetTasksByDate(SelectedDate);
            }
        }
        private void CloseWindow(object obj)
        {
            ((Window)obj).Close();
        }
        private void SetTasksByDate(DateTime date)
        {
            CurrentTaskList.Clear();
            //CurrentTaskList
            //currentTaskList.
            //currentTasks = from task in db.Tasks where task.Date == date select task;
            //CurrentTasks = db.Tasks.Where(task => task.Date == date).ToList();

            foreach (var task in (db.Tasks.Where(task => task.Date == date)))
            {
                CurrentTaskList.Add(task);

            }

             //var val = CurrentTasks;

            //CurrentTaskList = new ObservableCollection<TaskVM>(db.Tasks.Where(task => task.Date == date));
            //CurrentTaskList.CollectionChanged();

            /*foreach (var task in TaskList)
            {
                if (task.Date == date)
                {
                    CurrentTaskList.Add(task);
                }
            }*/
        }


    }
}
