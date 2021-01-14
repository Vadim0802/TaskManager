using System.Collections.Generic;

namespace TaskManager.Commands
{
    public class RemoveValueCommand
    {
        public string Name { get; set; }
        
        private readonly List<Variable> _variables;

        public RemoveValueCommand(string name, List<Variable> currentVariables)
        {
            Name = name;
            _variables = currentVariables;
        }

        public void RemoveValue()
        {
            var variable = _variables.Find(item => item.Name == Name);

            if (variable != null)
            {
                _variables.Remove(variable);
            }
        }
    }
}