using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Interfaces;

public interface IOperation
{
    string OperatorType { get; }
    int Precedence { get; }

    OperationResult Calculate();    
}

