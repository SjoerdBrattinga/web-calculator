<template>
  <div class="display">
    <div class="expression">
      {{ expression }}
    </div>
    <div class="value">
      {{ display }}
    </div>
  </div>
</template>

<script setup lang="ts">
  import { useCalculator } from '@/composables/calculator'

  const { display, expression } = useCalculator()
</script>

<style scoped>
  .display {
    display: flex;
    justify-content: flex-end;
    flex-direction: column;
    border: 0;
    padding: 0.3em;
    margin-bottom: 10px;
    border-radius: 10px;
    min-height: calc(20% - 5px);
    background-color: black;
    color: var(--color-primary-1);
  }
  .expression {
    min-height: 20%;
    font-size: 1.5em;
  }
  .value {
    min-height: 80%;
    font-size: 2.5em;
  }

  .expression,
  .value {
    display: flex;
    justify-content: flex-end;
    white-space: nowrap;
    overflow: hidden;
  }
</style>
