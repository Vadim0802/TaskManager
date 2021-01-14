using System.Collections.Generic;

namespace TaskManager.Commands
{
    public class CreateValueCommand
    {
        public string Name { get; set; }

        private readonly List<Variable> _variables;

        public CreateValueCommand() { }
        public CreateValueCommand(string name, List<Variable> currentVariables)
        {
            Name = name;
            _variables = currentVariables;
        }

        public void CreateValue()
        {
            var variable = _variables.Find(item => item.Name == Name);

            if (variable == null)
            {
                variable = new Variable(Name);
                _variables.Add(variable);
            }
        }
    }
}