using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager
{
    public class Variable
    {
        public string Name { get; set; }

        public dynamic Value { get; set; }

        public Variable() { }
        public Variable(string name)
        {
            Name = name;
        }
    }
}
