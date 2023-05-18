import { performOperation } from '@/services/calculator-service'
import type { Button, CalculatorResponse } from '@/types/types'
import { ref } from 'vue'



const display = ref('0')
const expression = ref('')
const history = ref<string[]>([])

export const useCalculator = () => {
  const unaryOperators = ['negate', 'sqr', '√', '1/']
  const binaryOperators = ['+', '-', '*', '/', '^']

  type buttonTypes = 'operator' | 'number' | 'equal'
  let lastClicked: buttonTypes

  const number1 = ref('')
  const number2 = ref('')
  const operator = ref('')
  // const result = ref('')


  const handleNumberClick = (buttonValue: string) => {
    resetIfError()

    if (display.value === '0' && buttonValue !== '.') {
      display.value = buttonValue
    } else if (lastClicked === 'operator') {
      display.value = buttonValue
    } else {
      display.value += buttonValue
    }
    lastClicked = 'number'
  }

  const handleButtonClick = async (buttonValue: string) => {
    resetIfError();

    if (unaryOperators.includes(buttonValue)) {

      console.log('is unary')
      console.log('buttonValue ' + buttonValue)
      console.log('operatorValue ' + operator.value)

      // Calculate result if previous input is a valid binary operation
      if (binaryOperators.includes(operator.value)) {

        if (number1.value !== '' && lastClicked !== 'operator') {
          number2.value = display.value
          if (isValidOperation()) {
            await calculate().then(response => {
              handleResponse(response)
              number2.value = ''
            })
          }
          // console.log('1st is valid')
          // await calculate().then(response => {
          //   console.log('1st response ', response)
          //   // handleResponse(response)
          //   // if (response.isSuccess) {
          //   //   expression.value += response.operation
          //   // }
          //   if (response.isSuccess) {
          //     display.value = response.result.toString()
          //   }
          // })
        }
      } else {
        console.log('1st not valid')
      }

      number1.value = display.value
      operator.value = buttonValue

      console.log('operatorValue ' + operator.value)
      if (isValidOperation()) {
        console.log('2nd is valid')
        await calculate().then(response => {
          console.log('2st response ', response)
          handleUnaryResult(response)


        })
      }
    } else if (lastClicked === 'equal' && number2.value !== '') {
      number2.value = ''
      expression.value = `${number1.value} ${buttonValue}`
    } else if (binaryOperators.includes(buttonValue)) {
      if (number1.value === '') {
        number1.value = display.value
      } else if (lastClicked !== 'operator') {
        number2.value = display.value
        if (isValidOperation()) {
          await calculate().then(response => {
            handleResponse(response)
            number2.value = ''
          })
        }
      }
      expression.value = `${number1.value} ${buttonValue}`
    }
    operator.value = buttonValue
    lastClicked = 'operator'
  }

  async function calculate(): Promise<CalculatorResponse> {
    try {
      const request = {
        operand1: +number1.value,
        operator: operator.value,
        operand2: +number2.value
      }

      const response = await performOperation(request)

      return response
    } catch (error) {
      console.error(error)
      throw new Error('Failed to perform operation')
    }
  }

  const isUnaryOperation = () => unaryOperators.includes(operator.value);
  const isBinaryOperation = () => binaryOperators.includes(operator.value);

  const isValidOperation = () => {
    if (number1.value !== '' && isUnaryOperation()) {
      return true;
    } else if (number1.value !== '' && isBinaryOperation() && number2.value !== '') {
      return true;
    } else {
      return false;
    }
  }

  function handleResponse(response: CalculatorResponse) {
    if (response.isSuccess) {
      console.log(response.result)
      number1.value = response.result.toString()
      display.value = number1.value
      history.value.push(`${response.operation} = ${response.result}`)
    } else {
      resetOperationParams()
      expression.value = response.errorMessage
      display.value = 'ERROR'
    }
  }

  function handleUnaryResult(response: CalculatorResponse) {
    if (response.isSuccess) {
      console.log(response.result)
      expression.value = `${response.operation}`
      history.value.push(`${response.operation} = ${response.result}`)
      number1.value = response.result.toString()
      display.value = number1.value

    } else {
      resetOperationParams()
      expression.value = response.errorMessage
      display.value = 'ERROR'
    }
  }

  async function handleEqual(): Promise<void> {


    if (!operator.value) {
      number1.value = display.value
      operator.value = '='
      updateExpressionValue()
    } else if (isValidOperation()) {
      await calculate().then(response => handleEqualResult(response))
    } else if (binaryOperators.includes(operator.value) && number1.value !== '') {

      number2.value = display.value
      if (isValidOperation()) {
        await calculate().then(response => handleEqualResult(response))
      }
    }
    lastClicked = 'equal'
  }

  const handleEqualResult = (response: CalculatorResponse) => {
    handleResponse(response)

    if (response.isSuccess) {
      expression.value = `${response.operation} =`
    }
  }

  function resetIfError() {
    if (display.value === 'ERROR' || display.value === 'Infinity') {
      handleClear()
      return true
    } else {
      return false
    }
  }

  const handleClear = () => {
    resetOperationParams()
    resetDisplayValue()
    resetExpressionValue()

    history.value = []
  }

  const resetDisplayValue = () => display.value = '0'

  const resetExpressionValue = () => expression.value = ''

  const handleBackspace = () => {
    const displayCleared = resetIfError()

    if (!displayCleared) {
      if (lastClicked === 'number') {
        display.value = display.value.slice(0, -1)

        if (display.value === '') {
          resetDisplayValue()
        }
      } else if (lastClicked === 'equal') {
        resetExpressionValue()
      }
    }


  }

  const resetOperationParams = () => {
    number1.value = ''
    number2.value = ''
    operator.value = ''
  }

  const updateExpressionValue = () => {
    expression.value = `${number1.value} ${operator.value}`
  }

  const buttons: Button[] = [
    { label: 'xʸ', value: '^', class: 'operator', function: handleButtonClick },
    { label: 'CE', value: 'clear-entry', class: 'clear', function: resetDisplayValue },
    { label: 'C', value: 'clear', class: 'clear', function: handleClear },
    { label: '⌫', value: 'backspace', class: 'clear', function: handleBackspace },

    { label: '1/x', value: '1/', function: handleButtonClick },
    { label: 'x²', value: 'sqr', class: 'operator', function: handleButtonClick },
    { label: '²√x', value: '√', class: 'operator', function: handleButtonClick },
    { label: '/', value: '/', class: 'operator', function: handleButtonClick },

    { label: '7', value: '7', class: 'number', function: handleNumberClick },
    { label: '8', value: '8', class: 'number', function: handleNumberClick },
    { label: '9', value: '9', class: 'number', function: handleNumberClick },
    { label: 'x', value: '*', class: 'operator', function: handleButtonClick },

    { label: '4', value: '4', class: 'number', function: handleNumberClick },
    { label: '5', value: '5', class: 'number', function: handleNumberClick },
    { label: '6', value: '6', class: 'number', function: handleNumberClick },
    { label: '-', value: '-', class: 'operator', function: handleButtonClick },

    { label: '1', value: '1', class: 'number', function: handleNumberClick },
    { label: '2', value: '2', class: 'number', function: handleNumberClick },
    { label: '3', value: '3', class: 'number', function: handleNumberClick },
    { label: '+', value: '+', class: 'operator', function: handleButtonClick },

    { label: '±', value: 'negate', class: 'operator', function: handleButtonClick },
    { label: '0', value: '0', class: 'number', function: handleNumberClick },
    { label: '.', value: '.', class: 'operator', function: handleNumberClick },
    { label: '=', value: '=', class: 'equal', function: handleEqual }
  ]

  return {
    display,
    expression,
    history,
    buttons,
    handleButtonClick
  }
}


