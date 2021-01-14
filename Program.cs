using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Commands;

namespace TaskManager
{
    internal static class Program
    {
        private static void Main()
        {
            GroupController.CreateGroup("name1");
            GroupController.CreateGroup("name2");
            GroupController.CreateGroup("name3");
            GroupController.ShowGroups();
            
            GroupController.UseGroup("name2");
            GroupController.CurrentGroup.Create("namegr1");
            GroupController.CurrentGroup.Create("namegr2");
            GroupController.CurrentGroup.Create("namegr3");
            GroupController.CurrentGroup.Remove("namege1");
            
            GroupController.ShowGroup("name2");
            
            GroupController.SetTimer(DateTime.Now.AddSeconds(3).ToString(), "00:00:02", "0");


            Console.ReadLine();
        }
    }
}
