﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Operations.Unary;

public class Negate : UnaryOperation
{
    public override string OperatorType => "negate";
    public override int Precedence => 4;

    public override OperationResult Calculate()
    {
        double result = -Operand;

        return OperationResult.Success(result, ToString());
    }
}