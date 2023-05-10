import type { Button } from '@/types/Button'
import { ref } from 'vue'
// import { computed } from 'vue'


const display = ref('0')

export const useCalculator = () => {


  const handleButtonClick = (button: Button) => {
    switch (button.value) {
      case 'clear':
        handleClear()
        break
      case 'backspace':
        handleBackspace()
        break
      case 'equal':
        handleEqual()
        break
      default:
        if (display.value === '0' && button.value !== '.') {
          display.value = button.value
        } else {
          display.value += button.value
        }
        break
    }
  }

  const handleClear = () => {
    display.value = '0'
  }

  const handleBackspace = () => {
    display.value = display.value.slice(0, -1)
    if (display.value === '') {
      display.value = '0'
    }
  }

  const handleEqual = () => {
    add()
    try {
      display.value = eval(display.value)
    } catch (error) {
      display.value = 'Error'
    }
  }

  const add = async () => {

    try {
      const response = await fetch('https://localhost:7114/api/add/1/2')
      const result = await response.json();
      console.log(result);
    } catch (error) {
      console.error(error);
    }
  }

  // const calculatorDisplay = computed(() => display.value, {
  //   onTrigger(e) {
  //     // triggered when count.value is mutated
  //     debugger
  //   }
  // })

  return {
    display,
    handleButtonClick
  }

}