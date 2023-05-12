import type { Button, CalculatorInput } from '@/types/types'
import axios from 'axios'
import { ref } from 'vue'
// import { computed } from 'vue'
interface CalculatorRequest {
  operand1: number;
  operand2?: number;
  operatorType: string;
}

const display = ref('0')
const expression = ref('')

export const useCalculator = () => {
  const unaryOperators = ['negate', 'sqr', 'sqrt']
  //const binaryOperators = ['+', '-', '*', '/', '^']
  const num1 = ref();
  const num2 = ref();
  const op = ref();

  const performOperarion = async () => {
    try {
      // const response = await axios(`https://localhost:7114/api/perform-operation/${num1.value}/${op.value}/${num2.value}`)
      const response = await axios.get(`https://localhost:7114/api/perform-operation`, {
        params: {
          Operand1: +num1.value,
          Operand2: +num2.value,
          Operator: op.value
        }
      })

      handleResponse(response.data)

    } catch (error) {
      console.error(error);
    }
  }

  function handleResponse(response) {
    if (response.isSuccess) {
      display.value = response.result
      updateExpressionValue(response.operation)
      resetOperationParams()
    } else {
      console.log(response.errorMessage)
    }

  }

  const resetOperationParams = () => {
    num1.value = undefined
    num2.value = undefined
    op.value = undefined
  }

  const handleButtonClick = (button: Button) => {
    if (button.class === 'number') {

      if (display.value === '0' && button.value !== '.') {
        display.value = button.value
      } else {
        display.value += button.value
      }
    } else if (button.class === 'operator') {
      num1.value = display.value
      op.value = button.value

      if (expression.value === '') {
        //expression.value = display.value
      } else {
        //expression.value += '' + display.value
      }
      if (num1.value !== undefined && unaryOperators.includes(button.value)) {
        performOperarion()
      }
      //parseDisplayValue()

      // if (unaryOperators.includes(button.value) && num1.value !== '') {
      //   num1.value = display.value
      //   performOperarion()
      // } else {
      //   display.value = button.value
      //   // num2.value += button.value;
      // }
      // if(num1.value === ''){
      //   num1.value += button.value;
      // } else if
      // if (display.value === '0' && button.value !== '.') {
      //   display.value = button.value
      // } else {
      //   display.value += button.value



    }
  }

  function parseDisplayValue() {
    const regex = /^(-?\d+\.?\d*)(\D)(-?\d+\.?\d*)?$/;
    const matches = display.value.match(regex);

    if (!matches) {
      throw new Error('Invalid display value');
    }

    num1.value = Number(matches[1]);
    op.value = matches[2];
    num2.value = matches[3] ? Number(matches[3]) : null;

    console.log(`num1: ${num1.value} op: ${op.value} num1: ${num2.value}`)
    const request = {
      operand1: Number(matches[1]),
      operatorType: matches[2],
      operand2: matches[3] ? Number(matches[3]) : null
    }
    //performOperarion(request);
    //return { operand1, operator, operand2 };
  }
  const updateExpressionValue = (value: string) => expression.value += value

  const handleClear = () => {
    resetDisplayValue()
    resetExpressionValue()
  }

  const resetDisplayValue = () => display.value = '0'

  const resetExpressionValue = () => expression.value = ''

  const handleBackspace = () => {
    if (display.value === 'error') {
      resetDisplayValue()
    } else {
      display.value = display.value.slice(0, -1)
      if (display.value === '') {
        resetDisplayValue()
      }
    }
  }




  const handleEqual = () => {

    try {
      //performOperarion()
      display.value = eval(expression.value)
    } catch (error) {
      display.value = 'Error'
    }
  }


  const buttons: Button[] = [
    { label: 'xʸ', value: 'power', class: 'operator', function: handleButtonClick },
    { label: 'CE', value: 'clear-entry', class: 'clear', function: resetDisplayValue },
    { label: 'C', value: 'clear', class: 'clear', function: handleClear },
    { label: '⌫', value: 'backspace', class: 'clear', function: handleBackspace },

    { label: '1/x', value: '', function: handleButtonClick },
    { label: 'x²', value: 'sqr', class: 'operator', function: handleButtonClick },
    { label: '²√x', value: 'sqrt', class: 'operator', function: handleButtonClick },
    { label: '÷', value: '/', class: 'operator', function: handleButtonClick },

    { label: '7', value: '7', class: 'number', function: handleButtonClick },
    { label: '8', value: '8', class: 'number', function: handleButtonClick },
    { label: '9', value: '9', class: 'number', function: handleButtonClick },
    { label: 'x', value: '*', class: 'operator', function: handleButtonClick },

    { label: '4', value: '4', class: 'number', function: handleButtonClick },
    { label: '5', value: '5', class: 'number', function: handleButtonClick },
    { label: '6', value: '6', class: 'number', function: handleButtonClick },
    { label: '-', value: '-', class: 'operator', function: handleButtonClick },

    { label: '1', value: '1', class: 'number', function: handleButtonClick },
    { label: '2', value: '2', class: 'number', function: handleButtonClick },
    { label: '3', value: '3', class: 'number', function: handleButtonClick },
    { label: '+', value: '+', class: 'operator', function: handleButtonClick },

    { label: '±', value: 'negate', class: 'operator', function: handleButtonClick },
    { label: '0', value: '0', class: 'number', function: handleButtonClick },
    { label: '.', value: '.', class: 'number', function: handleButtonClick },
    { label: '=', value: 'equal', class: 'equal', function: performOperarion }
  ]

  // const calculatorDisplay = computed(() => display.value, {
  //   onTrigger(e) {
  //     // triggered when count.value is mutated
  //     debugger
  //   }
  // })

  return {
    display,
    expression,
    buttons,
    handleButtonClick
  }

}