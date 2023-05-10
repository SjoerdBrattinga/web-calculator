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
  /* .container {
    width: 100%;
    height: 100vh;
    background-color: rgb(59, 65, 65);
    display: flex;
    align-items: center;
    justify-content: center;
  } */

  .calculator {
    width: 100%;
    max-width: 500px;
    height: 100%;
    max-height: 500px;
    background: #eee;
    padding: 20px;
    border-radius: 10px;
  }
</style>
