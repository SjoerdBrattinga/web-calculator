<template>
  <!-- <div class="container"> -->
  <div class="calculator">
    <CalculatorDisplay />
    <CalculatorButtons />
  </div>
  <!-- </div> -->
</template>

<script setup lang="ts">
  import CalculatorDisplay from './CalculatorDisplay.vue'
  import CalculatorButtons from './CalculatorButtons.vue'
</script>

<style>
  .calculator {
    min-width: 250px;
    width: 30%;
    padding: 10px;
    border-radius: 10px;
    background-color: var(--color-complement-4);
  }
</style>
