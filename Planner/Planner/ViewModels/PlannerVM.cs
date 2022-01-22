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

using System.Collections.Specialized;


namespace Planner.ViewModels
{
    class PlannerVM : VMBase
    {
        private RelayCommand addCommand;
        private RelayCommand deleteCommand;
        private RelayCommand editCommand;
        private RelayCommand closeWindowCommand;
        private DateTime selectedDate;
        private ApplicationContext db;
        private IEnumerable<TaskVM> tasks;
        private ObservableCollection<TaskVM> currentTasks;

        public IEnumerable<TaskVM> Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }
        public ObservableCollection<TaskVM> CurrentTasks
        {
            get { return currentTasks; }
            set { currentTasks = value; }
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
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand;
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
            db = new ApplicationContext();
            db.Tasks.Load();
            Tasks = db.Tasks.Local.ToBindingList();

            CurrentTasks = new ObservableCollection<TaskVM>();

            SelectedDate = DateTime.Today;
            SetTasksByDate(SelectedDate);

            addCommand = new RelayCommand(AddTask);
            deleteCommand = new RelayCommand(DeleteTask);
            editCommand = new RelayCommand(EditTask);
            closeWindowCommand = new RelayCommand(CloseWindow);
        }

        private void AddTask(object obj)
        {
            var newTask = new TaskVM(new Task("New Task", SelectedDate));
            db.Tasks.Add(newTask);
            currentTasks.Add(newTask);
            db.SaveChanges();
            //SetTasksByDate(SelectedDate);
        }
        private void DeleteTask(object obj)
        {
            if (MessageBox.Show("Are you sure you want to delete this task?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                db.Tasks.Remove((TaskVM)obj);
                currentTasks.Remove((TaskVM)obj);
                db.SaveChanges();
                //SetTasksByDate(SelectedDate);
            }
        }

        private void EditTask(object obj)
        {
            db.SaveChanges();
        }
        private void CloseWindow(object obj)
        {
            ((Window)obj).Close();
        }
        private void SetTasksByDate(DateTime date)
        {
            CurrentTasks.Clear();

            foreach (var task in (db.Tasks.Where(task => task.Date == date)))
            {
                CurrentTasks.Add(task);

            }
        }

    }
}
