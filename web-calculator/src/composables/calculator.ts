import type { Button } from '@/types/types'
import axios from 'axios'
import { ref } from 'vue'



const display = ref('0')
const expression = ref('')
const number1 = ref('')
const number2 = ref('')
const operator = ref('')
const result = ref('')

const history = ref<string[]>([])

interface CalculatorRequest {
  operand1: number;
  operand2?: number | null;
  operator: string;
}
interface CalculatorResponse {
  isSuccess: boolean
  result: number
  operation: string
  errorMessage: string
}


export const useCalculator = () => {
  const unaryOperators = ['negate', 'sqr', 'sqrt', 'power']
  const binaryOperators = ['+', '-', '*', '/', '^']

  const operatorSelected = ref(false)


  const handleButtonClick = (buttonValue: string) => {

    if (Number(buttonValue)) {
      if (display.value === '0' && buttonValue !== '.') {
        display.value = buttonValue
      } else if (operatorSelected.value) {
        display.value = buttonValue

      } else {
        display.value += buttonValue
      }
      operatorSelected.value = false
    } else {
      operator.value = buttonValue
      operatorSelected.value = true
      if (number1.value === '') {
        number1.value = display.value
        //updateExpressionValue(buttonValue)
      } else if (number2.value === '') {
        number2.value = display.value
      }

      updateExpressionValue2()

      if (number1.value !== '' && unaryOperators.includes(buttonValue)) {
        performOperarion({ operand1: +number1.value, operator: operator.value })
      } else if (binaryOperators.includes(buttonValue) && number1.value !== '' && number2.value) {
        performOperarion({ operand1: +number1.value, operator: operator.value, operand2: +number2.value })
      }

    }
  }

  const performOperarion = async (request: CalculatorRequest) => {
    try {
      const response = await axios.post<CalculatorResponse>(`https://localhost:7114/api/perform-operation`, request)

      handleResponse(response.data)


    } catch (error) {
      console.error(error);
    }
  }

  function handleResponse(response: CalculatorResponse) {
    if (response.isSuccess && response.result) {
      number1.value = response.result.toString()
      display.value = number1.value
      number2.value = ''
      updateExpressionValue2()
      history.value.push(`${response.operation} = ${response.result}`)

      //expression.value = response.operation
    } else {
      console.log(response.errorMessage)
    }
  }


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


  function handleEqual(): void {
    if (!operator.value || !number1.value) {
      return;
    }
  }



  const resetOperationParams = () => {
    number1.value = ''
    number2.value = ''
    operator.value = ''
  }




  const updateExpressionValue = (value: string) => {

    expression.value += value

  }

  const updateExpressionValue2 = () => {
    // console.log(number1.value, number2.value, operator.value)
    // if (number2.value !== '') {
    //   expression.value = `${number1.value} ${operator.value} ${number2.value} =`
    // } else {
    //   expression.value = `${number1.value} ${operator.value}`
    // }
    expression.value = `${number1.value} ${operator.value}`


  }
  // const expression2 = computed(() => {
  //   return expression.value = num1.value + " " + op.value
  // })





  // const handleEqual = () => {

  //   try {
  //     performOperarion()
  //     //display.value = eval(expression.value)
  //   } catch (error) {
  //     display.value = 'Error'
  //   }
  // }



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
    { label: '=', value: 'equal', class: 'equal', function: handleEqual }
  ]


  return {
    display,
    expression,
    history,
    buttons,
    handleButtonClick
  }

}


