<template>
  <div class="calculator-container">
    <div class="calculator">
      <CalculatorDisplay />
      <CalculatorButtons />
    </div>
    <div class="history">
      <CalculatorHistory />
    </div>
  </div>
</template>

<script setup lang="ts">
  import CalculatorDisplay from './CalculatorDisplay.vue'
  import CalculatorButtons from './CalculatorButtons.vue'
  import CalculatorHistory from './CalculatorHistory.vue'
</script>

<style>
  .calculator-container {
    display: flex;
    flex-direction: row;
    min-height: 590px;
    height: 70%;
    min-width: 500px;
    width: 60%;
    gap: 10px;
    padding: 10px;
    border-radius: 10px;
    background-color: var(--color-complement-4);
  }
  .calculator {
    min-height: 100%;
    min-width: 60%;
  }
  .history {
    display: flex;
    min-width: 40%;
  }
</style>
