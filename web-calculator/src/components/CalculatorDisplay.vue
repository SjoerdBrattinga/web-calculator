<template>
  <!-- <div class="display-container"> -->
  <div class="display">{{ display }}</div>
  <!-- </div> -->

  <!-- <div class="display">{{ calculatorDisplay }}</div> -->
</template>

<script setup lang="ts">
  import { useCalculator } from '@/composables/calculator'

  const { display } = useCalculator()
</script>

<style scoped>
  .display {
    display: flex;
    justify-content: flex-end;
    white-space: nowrap;
    overflow: hidden;
    font-size: 2em;
    border: 0;
    padding: 0.3em;
    /* text-align: right; */
    margin-bottom: 10px;
    /* width: 100%; */
    border-radius: 10px;
    height: 80px;
    background-color: black;

    color: var(--color-primary-1);
  }
</style>
