using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Interfaces;

public interface IOperation
{
    string OperatorType { get; }
    int Precedence { get; }

    double Calculate();    
}

