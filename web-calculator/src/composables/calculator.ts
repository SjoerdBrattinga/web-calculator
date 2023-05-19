import { performOperation } from '@/services/calculator-service'
import type { Button, ButtonTypes, CalculatorResponse } from '@/types/types'
import { ref } from 'vue'

// Display shows entry and results
const display = ref('0')
// Expression shows the current or calculated operation
const expression = ref('')
// Shows all performed calculations
const history = ref<string[]>([])

// display, expression and history
// have to be outside of useCalculator otherwise the components wont get the correct state

export const useCalculator = () => {
  // Valid operators
  const unaryOperators = ['negate', 'sqr', '√', '1/']
  const binaryOperators = ['+', '-', '*', '/', '^']

  // Used for deciding what to do based on previous action
  let lastClicked: ButtonTypes

  // Used to make calculation requests on the server
  const number1 = ref('')
  const number2 = ref('')
  const operator = ref('')

  const isUnaryOperation = () => unaryOperators.includes(operator.value)

  const isBinaryOperation = () => binaryOperators.includes(operator.value)

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
    resetIfError()

    if (unaryOperators.includes(buttonValue)) {
      // Calculate result if previous input is a valid binary operation
      if (binaryOperators.includes(operator.value)) {
        if (number1.value !== '' && lastClicked !== 'operator') {
          number2.value = display.value

          if (isValidOperation()) {
            await calculate().then((response) => {
              handleResult(response)
              number2.value = ''
            })
          }
        }
      }

      number1.value = display.value
      //Set current operator value
      operator.value = buttonValue

      // Perform unary operation
      if (isValidOperation()) {
        await calculate().then((response) => {
          handleUnaryResult(response)
        })
      }
    }
    // If last click was equal and number2 is not empty skip binary operation
    else if (lastClicked === 'equal' && number2.value !== '') {
      number2.value = ''
      expression.value = `${number1.value} ${buttonValue}`
    } else if (binaryOperators.includes(buttonValue)) {
      if (number1.value === '') {
        number1.value = display.value
      } else if (lastClicked !== 'operator') {
        number2.value = display.value

        if (isValidOperation()) {
          await calculate().then((response) => {
            handleResult(response)
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

  const isValidOperation = () => {
    if (number1.value !== '' && isUnaryOperation()) {
      return true
    } else if (number1.value !== '' && isBinaryOperation() && number2.value !== '') {
      return true
    } else {
      return false
    }
  }

  function handleResult(response: CalculatorResponse) {
    if (response.isSuccess) {
      number1.value = response.result.toString()
      display.value = number1.value
      history.value.push(`${response.operation} = ${response.result}`)
    } else {
      handleErrorResponse(response.errorMessage)
    }
  }

  function handleUnaryResult(response: CalculatorResponse) {
    if (response.isSuccess) {
      expression.value = `${response.operation}`
      history.value.push(`${response.operation} = ${response.result}`)
      number1.value = response.result.toString()
      display.value = number1.value
    } else {
      handleErrorResponse(response.errorMessage)
    }
  }

  function handleErrorResponse(errorMessage: string) {
    resetOperationParams()
    expression.value = errorMessage
    display.value = 'ERROR'
  }

  async function handleEqual(): Promise<void> {
    if (!operator.value) {
      number1.value = display.value
      operator.value = '='

      updateExpressionValue()
    } else if (isValidOperation()) {
      await calculate().then((response) => handleEqualResult(response))
    } else if (binaryOperators.includes(operator.value) && number1.value !== '') {
      number2.value = display.value

      if (isValidOperation()) {
        await calculate().then((response) => handleEqualResult(response))
      }
    }
    lastClicked = 'equal'
  }

  const handleEqualResult = (response: CalculatorResponse) => {
    handleResult(response)

    if (response.isSuccess) {
      expression.value = `${response.operation} =`
    }
  }

  const resetIfError = () => {
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

  const resetDisplayValue = () => (display.value = '0')

  const resetExpressionValue = () => (expression.value = '')

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

  // This should probably be moved to the calculator buttons component. 
  //
  // Instead of exporting this button array, a function handle buttonClick should be exported
  // Instead of having a function property, a button object should have a property buttonType:ButtonTypes
  // The CalculatorButtons component then calls handleButtonClick and return the button object instead of buttonValue
  // Handle button click would then decide on the buttonType wich method should be called
  // This would make the logic more organised and readable
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
    buttons
  }
}
