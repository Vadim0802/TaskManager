using System;
using System.Collections.Generic;

namespace TaskManager.Commands
{
    public class SetValueCommand
    {
        private readonly string _name;
        private readonly object _data;
        private readonly List<Variable> _variables;

        public SetValueCommand(string name, object currentData, List<Variable> variables)
        {
            _name = name;
            _data = currentData;
            _variables = variables;
        }

        public void SetValue()
        {
            var variable = _variables.Find((item => item.Name == _name));

            if (variable != null)
            {
                if (_data is Variable dataVariable)
                    variable.Value = dataVariable;
                else
                    variable.Value = (string)_data;
            }
        }
    }
}