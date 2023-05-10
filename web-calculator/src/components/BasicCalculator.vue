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
    width: 40%;
    /* padding-bottom: 50%; */
    /* width: 100%;
    max-width: 500px; */
    /* height: 100%;
    max-height: 500px; */
    /* background: #eee; */
    padding: 10px;
    border-radius: 10px;
  }
</style>
