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
    border: 0;
    padding: 0.3em;
    /* text-align: right; */
    margin-bottom: 10px;
    /* width: 100%; */
    border-radius: 10px;
    height: 100px;
    background-color: black;

    color: var(--color-primary-1);
  }
  .expression {
    min-height: 1em;
    font-size: 1em;
  }
  .value {
    min-height: 2em;
    font-size: 2em;
  }

  .expression,
  .value {
    display: flex;
    justify-content: flex-end;
    white-space: nowrap;
    overflow: hidden;
  }
</style>
