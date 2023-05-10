<template>
  <div class="display">{{ display }}</div>
  <!-- <div class="display">{{ calculatorDisplay }}</div> -->
</template>

<script setup lang="ts">
  import { useCalculator } from '@/composables/calculator'

  const { display } = useCalculator()
</script>

<style scoped>
  .display {
    /* font-family: 'Space Mono', serif; */
    background: black;
    color: white;
    font-size: 2em;
    border: 0;
    padding: 0.3em;
    text-align: right;
    width: 100%;
    border-radius: 10px;
    /* height: 100px; */
  }
</style>
