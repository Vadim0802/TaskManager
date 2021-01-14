using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TaskManager
{
    internal static class GroupController
    {
        public static GroupCommands CurrentGroup;
        
        private static readonly List<GroupCommands> Groups = new List<GroupCommands>();

        public static void CreateGroup(string name)
        {
            var group = new GroupCommands(name);
            Groups.Add(group);
        }

        public static void RemoveGroup(string name)
        {
            var group = Groups.Find((item => item.Name == name));

            if (group != null)
            {
                Groups.Remove(group);
            }
        }

        public static void UseGroup(string name)
        {
            var group = Groups.Find((item => item.Name == name));
            CurrentGroup = group;
        }

        public static void ShowGroup(string name)
        {
            var group = Groups.Find((item => item.Name == name));

            if (group != null)
            {
                for (var i = 0; i < group.Commands.Count; i++)
                {
                    Console.WriteLine($"{i}. {group.Commands[i].Target}");
                }
            }
        }

        public static void ShowGroups()
        {
            for (var i = 0; i < Groups.Count; i++)
            {
                Console.WriteLine($"{i}. {Groups[i].Name}");
            }
        }

        public static void SetTimer(string startTime, string period, string count)
        {
            var currentDate = DateTime.Now;
            var start = DateTime.Parse(startTime);

            var interval = start.Subtract(currentDate);
            var periodExecute = TimeSpan.Parse(period);
            
            CurrentGroup.TimerExecute = new Timer(CurrentGroup.Callback, CurrentGroup.Commands, 
                Convert.ToInt32(interval.TotalMilliseconds), Convert.ToInt32(periodExecute.TotalMilliseconds));
            
        }
    }
}
