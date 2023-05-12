export interface Button {
    label: string
    value: string
    class?: string
    function: Function
    // parseHTML?: true
}

export interface CalculatorInput {
    values: number[]
    operators: string[]
}