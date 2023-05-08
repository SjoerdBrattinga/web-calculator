using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCalculator.Domain.Interfaces;

public interface IOperationFactory
{
    IOperation Create(string operatorType);
}
