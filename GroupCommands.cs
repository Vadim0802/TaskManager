using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TaskManager.Commands;

namespace TaskManager
{
    internal class GroupCommands
    {
        private readonly List<Variable> _variables = new List<Variable>();

        public string Name { get; private set; }

        public readonly List<Action> Commands = new List<Action>();
        
        public readonly TimerCallback Callback = new TimerCallback(Run);
        public Timer TimerExecute;
        
        public GroupCommands(string name)
        {
            Name = name;
        }

        public void Create(string name)
        {
            var createCommand = new CreateValueCommand(name, _variables);
            Commands.Add(createCommand.CreateValue);
        }

        public void Remove(string name)
        {
            var removeCommand = new RemoveValueCommand(name, _variables);
            Commands.Add(removeCommand.RemoveValue);
        }

        public void Set(string name, object data)
        {
            var setCommand = new SetValueCommand(name, data, _variables);
            Commands.Add(setCommand.SetValue);
        }
        
        public static void Run(object obj)
        {
            //TODO: Разобраться с тем, как будет происходить подсчет итераций при работе по таймеру.
            foreach (var item in (List<Action>)obj)
            {
                Console.WriteLine("Test");
                item.Invoke();
            }
        }
    }
}
