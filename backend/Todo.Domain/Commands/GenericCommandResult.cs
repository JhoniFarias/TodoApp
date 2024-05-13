﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult() { }
        public GenericCommandResult(bool success, string message, object date)
        {
            Success = success;
            Message = message;
            Date = date;
        }

        public bool Success { get; set; }
        public string Message { get; set; }

        public object Date { get; set; }
    }
}
