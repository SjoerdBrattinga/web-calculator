export type ButtonTypes = 'operator' | 'number' | 'equal'

export interface Button {
    label: string
    value: string
    class?: string
    function: Function
}

// For calculating expressions, not implemented
export interface CalculatorInput {
    values: number[]
    operators: string[]
}

export interface CalculatorRequest {
    operand1: number;
    operand2?: number | null;
    operator: string;
}

export interface CalculatorResponse {
    isSuccess: boolean;
    result: number;
    operation: string;
    errorMessage: string;
}