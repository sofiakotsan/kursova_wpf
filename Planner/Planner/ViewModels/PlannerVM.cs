﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planner.Models;

namespace Planner.ViewModels
{
    class PlannerVM : VMBase
    {
        private TodoList taskList;

        public TodoList TaskList
        {
            get { return taskList; }
            set { taskList = value; }
        }

        private string[] myVar;

        public string[] MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        public PlannerVM()
        {

            TaskList = new TodoList();

            MyProperty = new string[]
            {
                "testdsfdsfds",
                "tesrrgfgftdsfdsfds",
                "testdsfdsfg fdfds",
                "testdsf dfg dsfds",
                "testdsfddfg sfds",
                "testdsfdsfds"
            };
        }


    }
}