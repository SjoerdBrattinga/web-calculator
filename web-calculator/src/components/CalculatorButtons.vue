<template>
  <div>
    <div class="calculator-buttons">
      <button
        class="btn"
        :class="button.class"
        v-for="button in buttons"
        :key="button.value"
        @click="handleButtonClick(button)"
      >
        <span v-if="button.parseHTML" v-html="button.label"></span>
        <span v-else>{{ button.label }}</span>
      </button>
    </div>
  </div>
</template>

<script setup lang="ts">
  import { useCalculator } from '@/composables/calculator'
  import type { Button } from '@/types/Button'

  const { handleButtonClick } = useCalculator()

  const buttons: Button[] = [
    { label: 'AC', value: 'clear', class: 'operator' },
    { label: 'CE', value: 'backspace', class: 'operator' },
    { label: '%', value: '%', class: 'operator' },
    { label: '/', value: '/', class: 'operator' },
    { label: '7', value: '7' },
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
    { label: '&#177;', value: 'negate', class: 'operator', parseHTML: true },
    { label: '0', value: '0' },
    { label: '.', value: '.' },
    { label: '=', value: 'equal', class: 'operator' }
  ]
</script>

<style scoped>
  .calculator-buttons {
    display: grid;
    grid-template-columns: repeat(4, 1fr);
    border: 0;
  }
  .btn {
    font-size: 1em;
    margin: 5px;
    border: 1px solid black;
    border-radius: 10px;
    /* width: 100%; */
    height: 60px;
  }

  .btn:hover {
    background: #fff;
  }

  .operator {
    background-color: rgb(98, 169, 211);
  }
</style>
