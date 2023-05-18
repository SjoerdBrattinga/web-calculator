// import type { Button, CalculatorInput } from '@/types/types'
// import axios from 'axios'
// import { ref, computed } from 'vue'
// // import { computed } from 'vue'
// interface CalculatorRequest {
//   operand1: number;
//   operand2?: number;
//   operatorType: string;
// }

// const displayValue = ref('0')
// // const display = ref('0')
// const expression = ref('')



// export const useCalculator2 = () => {
//   const unaryOperators = ['negate', 'sqr', 'sqrt', 'power']
//   const binaryOperators = ['+', '-', '*', '/', '^']
//   const calculatorInput = ref<any>([])
//   const num1 = ref();
//   const num2 = ref();
//   const op = ref();
//   const previousValue = ref();
//   const currentOperator = ref();
//   const performOperarion = async (operand1: string, operand2: string, operator: string) => {
//     try {
//       // const response = await axios(`https://localhost:7114/api/perform-operation/${num1.value}/${op.value}/${num2.value}`)
//       const response = await axios.get(`https://localhost:7114/api/perform-operation`, {
//         params: {
//           Operand1: +operand1,
//           Operand2: +operand2,
//           Operator: operator

//           // Operand1: +num1.value,
//           // Operand2: +num2.value,
//           // Operator: op.value
//         }
//       })

//       handleResponse(response.data)

//     } catch (error) {
//       console.error(error);
//     }
//   }
//   function handleNumberButtonClick(buttonValue: string): void {
//     debugger

//     if (displayValue.value === '0' && buttonValue !== '.') {
//       displayValue.value = buttonValue
//       expression.value
//     } else if (expression.value !== undefined) {
//       expression.value = buttonValue
//     } else {
//       displayValue.value += buttonValue

//       const currentDisplayValue = displayValue.value;
//       const newDisplayValue = currentDisplayValue + buttonValue;
//       expression.value = newDisplayValue;
//     }
//   }

//   function handleButtonClick(buttonValue: string): void {

//     if (Number(buttonValue) || buttonValue === '.') {
//       console.log(`${buttonValue} is number`)
//     } else if (unaryOperators.includes(buttonValue)) {
//       console.log(`${buttonValue} is unary operator`)
//     } else if (binaryOperators.includes(buttonValue)) {
//       console.log(`${buttonValue} is binary operator`)
//     }
//   }

//   function resetDisplayValue(): void {
//     displayValue.value = '0';
//   }

//   function handleClear(): void {
//     resetDisplayValue();
//     previousValue.value = null;
//     currentOperator.value = null;
//   }

//   function handleBackspace(): void {
//     const currentDisplayValue = displayValue.value;
//     const newDisplayValue = currentDisplayValue.slice(0, -1);
//     displayValue.value = newDisplayValue || '0';
//   }

//   function handleNegate(): void {
//     const currentDisplayValue = displayValue.value;
//     const newValue = Number(currentDisplayValue) * -1;
//     displayValue.value = String(newValue);
//   }

//   function handlePower(): void {
//     const { operand1 } = parseDisplayValue();
//     displayValue.value = `${operand1}^`;
//     previousValue.value = operand1;
//     currentOperator.value = 'power';
//   }

//   function handleSquare(): void {
//     const { operand1 } = parseDisplayValue();
//     const newValue = Math.pow(operand1, 2);
//     displayValue.value = String(newValue);
//   }

//   function handleSqrt(): void {
//     const { operand1 } = parseDisplayValue();
//     const newValue = Math.sqrt(operand1);
//     displayValue.value = String(newValue);
//   }

//   function handleEqual(): void {
//     if (!currentOperator.value || !previousValue.value) {
//       return;
//     }

//     const { operand1, operand2, operator } = parseDisplayValue();
//     const newValue = performOperarion(operand1, operator, operand2);
//     displayValue.value = String(newValue);
//     previousValue.value = null;
//     currentOperator.value = null;
//   }

//   // function getCalculationParameters(displayValue: string): [number, string, number | undefined] {
//   //   let [operand1, operator, operand2] = ['', '', undefined];

//   //   // Split the display value into operands and operator
//   //   const parts = displayValue.split(/([+\-*/])/);

//   //   if (parts.length >= 1) {
//   //     operand1 = parts[0].trim();
//   //   }

//   //   if (parts.length >= 2) {
//   //     operator = parts[1].trim();
//   //   }

//   //   if (parts.length >= 3) {
//   //     operand2 = parseFloat(parts[2].trim());
//   //   }

//   //   return [parseFloat(operand1), operator, operand2];
//   // }

//   function handleResponse(response) {
//     if (response.isSuccess) {
//       displayValue.value = response.result
//       updateExpressionValue(response.operation)
//       //resetOperationParams()
//       //num1.value = display.value
//     } else {
//       console.log(response.errorMessage)
//     }
//   }

//   // const resetOperationParams = () => {
//   //   //num1.value = undefined
//   //   num2.value = undefined
//   //   op.value = undefined
//   // }

//   // const handleButtonClick = (button: Button) => {
//   //   debugger;
//   //   if (button.class === 'number') {

//   //     if (display.value === '0' && button.value !== '.') {
//   //       display.value = button.value
//   //     } else if (expression.value !== undefined) {

//   //     } else {
//   //       display.value += button.value
//   //     }
//   //   } else if (button.class === 'operator') {
//   //     num1.value = display.value
//   //     calculatorInput.value.push(num1.value)
//   //     //updateExpressionValue(num1.value)
//   //     op.value = button.value
//   //     updateExpressionValue(op.value)
//   //     calculatorInput.value.push(op.value)
//   //     console.log(calculatorInput)

//   //     if (expression.value === '') {
//   //       //expression.value = display.value
//   //     } else {
//   //       //expression.value += '' + display.value
//   //     }
//   //     if (num1.value !== undefined && unaryOperators.includes(button.value)) {
//   //       performOperarion()
//   //     } else if (binaryOperators.includes(button.value) && num1.value !== undefined) {

//   //       if (op.value === undefined) {
//   //         op.value = button.value
//   //       } else if (num2.value !== undefined) {
//   //         performOperarion()
//   //       }
//   //     }
//   //     //parseDisplayValue()

//   //     // if (unaryOperators.includes(button.value) && num1.value !== '') {
//   //     //   num1.value = display.value
//   //     //   performOperarion()
//   //     // } else {
//   //     //   display.value = button.value
//   //     //   // num2.value += button.value;
//   //     // }
//   //     // if(num1.value === ''){
//   //     //   num1.value += button.value;
//   //     // } else if
//   //     // if (display.value === '0' && button.value !== '.') {
//   //     //   display.value = button.value
//   //     // } else {
//   //     //   display.value += button.value



//   //   }
//   // }

//   function parseDisplayValue() {
//     const regex = /^(-?\d+\.?\d*)(\D)(-?\d+\.?\d*)?$/;
//     const matches = displayValue.value.match(regex);

//     if (!matches) {
//       throw new Error('Invalid display value');
//     }

//     // num1.value = Number(matches[1]);
//     // op.value = matches[2];
//     // num2.value = matches[3] ? Number(matches[3]) : null;

//     console.log(`num1: ${num1.value} op: ${op.value} num1: ${num2.value}`)
//     // const request = {
//     //   operand1: Number(matches[1]),
//     //   operatorType: matches[2],
//     //   operand2: matches[3] ? Number(matches[3]) : null
//     // }
//     const operand1 = Number(matches[1]);
//     const operator = matches[2];
//     const operand2 = matches[3] ? Number(matches[3]) : null;
//     //performOperarion(request);
//     return { operand1, operator, operand2 };
//   }
//   // const updateExpressionValue = (value: string) => expression.value += value
//   const updateExpressionValue = (value: string) => expression.value = num1.value + " " + op.value
//   // const expression2 = computed(() => {
//   //   return expression.value = num1.value + " " + op.value
//   // })

//   // const handleClear = () => {
//   //   resetDisplayValue()
//   //   resetExpressionValue()
//   // }

//   // const resetDisplayValue = () => display.value = '0'

//   // const resetExpressionValue = () => expression.value = ''

//   // const handleBackspace = () => {
//   //   if (display.value === 'error') {
//   //     resetDisplayValue()
//   //   } else {
//   //     display.value = display.value.slice(0, -1)
//   //     if (display.value === '') {
//   //       resetDisplayValue()
//   //     }
//   //   }
//   // }



//   // const handleEqual = () => {

//   //   try {
//   //     performOperarion()
//   //     //display.value = eval(expression.value)
//   //   } catch (error) {
//   //     display.value = 'Error'
//   //   }
//   // }
//   // const buttons: Button[] = [
//   //   { label: 'xʸ', value: 'power', class: 'operator', function: handleOperatorButtonClick },
//   //   { label: 'CE', value: 'clear-entry', class: 'clear', function: resetDisplayValue },
//   //   { label: 'C', value: 'clear', class: 'clear', function: handleClear },
//   //   { label: '⌫', value: 'backspace', class: 'clear', function: handleBackspace },

//   //   { label: '1/x', value: 'reciprocal', class: 'operator', function: handleOperatorButtonClick },
//   //   { label: 'x²', value: 'sqr', class: 'operator', function: handleOperatorButtonClick },
//   //   { label: '²√x', value: 'sqrt', class: 'operator', function: handleOperatorButtonClick },
//   //   { label: '÷', value: '/', class: 'operator', function: handleOperatorButtonClick },

//   //   { label: '7', value: '7', class: 'number', function: handleNumberButtonClick },
//   //   { label: '8', value: '8', class: 'number', function: handleNumberButtonClick },
//   //   { label: '9', value: '9', class: 'number', function: handleNumberButtonClick },
//   //   { label: 'x', value: '*', class: 'operator', function: handleNumberButtonClick },

//   //   { label: '4', value: '4', class: 'number', function: handleNumberButtonClick },
//   //   { label: '5', value: '5', class: 'number', function: handleNumberButtonClick },
//   //   { label: '6', value: '6', class: 'number', function: handleNumberButtonClick },
//   //   { label: '-', value: '-', class: 'operator', function: handleNumberButtonClick },

//   //   { label: '1', value: '1', class: 'number', function: handleNumberButtonClick },
//   //   { label: '2', value: '2', class: 'number', function: handleNumberButtonClick },
//   //   { label: '3', value: '3', class: 'number', function: handleNumberButtonClick },
//   //   { label: '+', value: '+', class: 'operator', function: handleNumberButtonClick },

//   //   { label: '±', value: 'plusminus', class: 'operator', function: handleOperatorButtonClick },
//   //   { label: '0', value: '0', class: 'number', function: handleNumberButtonClick },
//   //   { label: '.', value: '.', class: 'number', function: handleNumberButtonClick },
//   //   { label: '=', value: 'equal', class: 'equal', function: handleEqual }
//   // ];


//   const buttons: Button[] = [
//     { label: 'xʸ', value: 'power', class: 'operator', function: handleButtonClick },
//     { label: 'CE', value: 'clear-entry', class: 'clear', function: resetDisplayValue },
//     { label: 'C', value: 'clear', class: 'clear', function: handleClear },
//     { label: '⌫', value: 'backspace', class: 'clear', function: handleBackspace },

//     { label: '1/x', value: '', function: handleButtonClick },
//     { label: 'x²', value: 'sqr', class: 'operator', function: handleButtonClick },
//     { label: '²√x', value: 'sqrt', class: 'operator', function: handleButtonClick },
//     { label: '÷', value: '/', class: 'operator', function: handleButtonClick },

//     { label: '7', value: '7', class: 'number', function: handleButtonClick },
//     { label: '8', value: '8', class: 'number', function: handleButtonClick },
//     { label: '9', value: '9', class: 'number', function: handleButtonClick },
//     { label: 'x', value: '*', class: 'operator', function: handleButtonClick },

//     { label: '4', value: '4', class: 'number', function: handleButtonClick },
//     { label: '5', value: '5', class: 'number', function: handleButtonClick },
//     { label: '6', value: '6', class: 'number', function: handleButtonClick },
//     { label: '-', value: '-', class: 'operator', function: handleButtonClick },

//     { label: '1', value: '1', class: 'number', function: handleButtonClick },
//     { label: '2', value: '2', class: 'number', function: handleButtonClick },
//     { label: '3', value: '3', class: 'number', function: handleButtonClick },
//     { label: '+', value: '+', class: 'operator', function: handleButtonClick },

//     { label: '±', value: 'negate', class: 'operator', function: handleButtonClick },
//     { label: '0', value: '0', class: 'number', function: handleButtonClick },
//     { label: '.', value: '.', class: 'number', function: handleButtonClick },
//     { label: '=', value: 'equal', class: 'equal', function: handleEqual }
//   ]

//   // const calculatorDisplay = computed(() => display.value, {
//   //   onTrigger(e) {
//   //     // triggered when count.value is mutated
//   //     debugger
//   //   }
//   // })

//   return {
//     displayValue,
//     expression,
//     buttons,
//     handleButtonClick
//   }

// }

