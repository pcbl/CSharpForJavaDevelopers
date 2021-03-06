﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.officeDay.events
{
    public class Calculator
    {
        public int Value { get; private set; }

        //event keyword meand that all event publishing/subscription is automatically handled
        //Event is a strongly typed Delegate(Pointer to method!)
        public event EventHandler<CalculatorEventArgs> Processed;

        public Calculator()
        {
            Value = 0;
        }

        public void Add(int valueToAdd)
        {
            Value += valueToAdd;
            if (Processed != null)
            {
                Processed(this,new CalculatorEventArgs(Value));
            }
        }

    }
}
