<template>
  <div class="container">

    <div class="calculator">


      <div class="display">{{ display }}</div>

      <div class="calculator-buttons">
        <button class="btn" :class="button.class" v-for="button in state.buttons" :key="button.value"
          @click="handleClick(button)">
          {{ button.label }}
        </button>
      </div>
      <!-- <button class="btn is-clear span-2 orange operator">C</button>
        <button class="btn orange operator">&larr;</button>
        <button class="btn orange operator">&divide;</button>
        <button class="btn">7</button>
        <button class="btn">8</button>
        <button class="btn">9</button>
        <button class="btn orange operator">x</button>
        <button class="btn">4</button>
        <button class="btn">5</button>
        <button class="btn">6</button>
        <button class="btn orange">-</button>
        <button class="btn">1</button>
        <button class="btn">2</button>
        <button class="btn">3</button>
        <button class="btn orange operator">+</button>
        <button class="btn span-3">0</button>
        <button class="btn orange operator">=</button> -->



    </div>

  </div>
</template>

<script setup lang="ts">
import { reactive, computed } from 'vue';

interface Button {
  label: string;
  value: string;
  class?: string;
}

interface State {
  display: string;
  buttons: Button[];
}


const state = reactive<State>({
  display: '0',
  buttons: [
    { label: 'AC', value: 'clear', class: 'operator' },
    { label: 'CE', value: 'backspace', class: 'operator' },
    { label: '%', value: '%', class: 'operator' },
    { label: '/', value: '/', class: 'operator' },
    { label: '7', value: '7', },
    { label: '8', value: '8' },
    { label: '9', value: '9' },
    { label: '*', value: '*', class: 'operator' },
    { label: '4', value: '4' },
    { label: '5', value: '5' },
    { label: '6', value: '6' },
    { label: '-', value: '-', class: 'operator' },
    { label: '1', value: '1' },
    { label: '2', value: '2' },
    { label: '3', value: '3' },
    { label: '+', value: '+', class: 'operator' },
    { label: '0', value: '0' },
    { label: '.', value: '.' },
    { label: '=', value: 'equal', class: 'operator span-2' }
  ]
});

const handleClear = () => {
  state.display = '0';
};

const handleBackspace = () => {
  state.display = state.display.slice(0, -1);
  if (state.display === '') {
    state.display = '0';
  }
};

const handleEqual = () => {
  try {
    state.display = eval(state.display);
  } catch (error) {
    state.display = 'Error';
  }
};

const handleClick = (button: Button) => {
  switch (button.value) {
    case 'clear':
      handleClear();
      break;
    case 'backspace':
      handleBackspace();
      break;
    case 'equal':
      handleEqual();
      break;
    default:
      if (state.display === '0' && button.value !== '.') {
        state.display = button.value;
      } else {
        state.display += button.value;
      }
      break;
  }
};

const display = computed(() => state.display);

// const handleClick = (button: Button) => {

//   handleButtonClick(button);
// };

</script>

<style>
.container {
  width: 100%;
  height: 100vh;
  background-color: rgb(59, 65, 65);
  display: flex;
  align-items: center;
  justify-content: center;
}


.calculator {

  background: #eee;
  padding: 20px;
  border-radius: 10px;


}

.calculator-buttons {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  border: 0;
}

.display {
  /* font-family: 'Space Mono', serif; */
  background: black;
  color: white;
  font-size: 2em;
  border: 0;
  padding: 0.3em;
  text-align: right;
  width: 100%;
  /* height: 100px; */
}

.span-2 {
  grid-column: span 2;
  width: 100% !important;
}

.span-3 {
  grid-column: span 3;
}

.btn {
  font-size: 1em;

  /* border: 1px solid black; */
  width: 50px;
  height: 50px;
}

.btn:hover {
  background: #fff;
}

.operator {
  background-color: rgb(98, 169, 211);
}
</style>