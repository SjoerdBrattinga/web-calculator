<template>
  <div>
    <!-- <div class="calculator-buttons">
      <button
        class="btn"
        v-for="button in advancedButtons"
        :key="button.value"
        @click="handleButtonClick(button)"
      >
        {{ button.label }}
      </button>
    </div> -->
    <div class="calculator-buttons">
      <button
        class="btn"
        :class="button.class"
        v-for="button in buttons"
        :key="button.value"
        @click="button.function(button)"
      >
        <!-- handleButtonClick(button) -->
        {{ button.label }}
        <!-- <span v-if="button.parseHTML" v-html="button.label"></span> -->
        <!-- <span v-else>{{ button.label }}</span> -->
      </button>
    </div>
  </div>
</template>

<script setup lang="ts">
  import { useCalculator } from '@/composables/calculator'
  import type { Button } from '@/types/types'
  // import { type } from 'os'

  const { handleButtonClick, buttons } = useCalculator()
  //   type buttonType = { numberBtn | operatorBtn | clearBtn }
  //   type numberBtn = {
  //   /**
  //    * The full name of the Programmer
  //    */
  //   label: string;
  //   value:string;
  //   class:string;
  //   /**
  //    * This Programmer is known for what?
  //    */
  //   knownFor: string[];
  // };
  // type numberBtn = {

  // }
  // const buttons: Button[] = [
  //   { label: 'xʸ', value: 'power' },
  //   { label: 'CE', value: 'clear-entry', class: 'clear', func:  },
  //   { label: 'C', value: 'clear', class: 'clear' },
  //   { label: '⌫', value: 'backspace', class: 'clear' },

  //   { label: '1/x', value: '' },
  //   { label: 'x²', value: 'sqr' },
  //   { label: '²√x', value: 'sqrt' },
  //   { label: '÷', value: '/', class: 'operator' },

  //   { label: '7', value: '7', class: 'number' },
  //   { label: '8', value: '8', class: 'number' },
  //   { label: '9', value: '9', class: 'number' },
  //   { label: 'x', value: '*', class: 'operator' },

  //   { label: '4', value: '4', class: 'number' },
  //   { label: '5', value: '5', class: 'number' },
  //   { label: '6', value: '6', class: 'number' },
  //   { label: '-', value: '-', class: 'operator' },

  //   { label: '1', value: '1', class: 'number' },
  //   { label: '2', value: '2', class: 'number' },
  //   { label: '3', value: '3', class: 'number' },
  //   { label: '+', value: '+', class: 'operator' },

  //   { label: '±', value: 'negate', class: '' },
  //   { label: '0', value: '0', class: 'number' },
  //   { label: '.', value: '.' },
  //   { label: '=', value: 'equal', class: 'equal' }
  // ]
</script>

<style scoped>
  .calculator-buttons {
    display: grid;
    grid-template-columns: repeat(4, 1fr);
    grid-gap: 10px;
  }
  .btn {
    background-color: var(--btn-background);
    color: var(--btn-color);
    height: 60px;
    font-size: 1.5em;
    border: 1px solid black;
    border-radius: 10px;

    transition: background-color 0.1s ease-in-out, color 0.3s ease-in-out;
  }
  .btn:hover {
    background: var(--btn-hover);
    color: var(--color-primary-5);
  }

  .operator:hover {
    /* color: var(--color-primary-5) !important; */
  }
  .clear:hover {
    color: var(--color-primary-6) !important;
  }
  /* .equal:hover {
    color: var(--color-complement-1) !important;
  } */
  .number {
    background-color: var(--btn-number-background) !important;
  }
  .number:hover {
    background-color: var(--color-complement-2) !important;
    color: var(--color-primary-0);
  }
</style>
