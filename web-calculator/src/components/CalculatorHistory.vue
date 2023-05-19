<template>
  <div class="history-container">
    <div v-for="(calculation, index) in history" :key="index">
      <div class="calculation">
        {{ calculation }}
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
  import { useCalculator } from '@/composables/calculator'

  const { history } = useCalculator()

  //TODO: Clear history
</script>

<style scoped>
  .history-container {
    width: 100%;
    max-height: 100%;
    padding: 1em;
    margin-right: 10px;
    border-radius: 10px;
    background-color: var(--color-complement-3);
    display: flex;
    align-items: flex-end;
    flex-direction: column;
    overflow: auto;
  }
  .calculation {
    font-size: 1.2em;
    text-align: right;
    color: var(--color-primary-1);
  }
</style>
