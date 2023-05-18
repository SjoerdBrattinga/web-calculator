<template>
  <div class="calculator-buttons">
    <button
      class="btn"
      :class="button.class"
      v-for="button in buttons"
      :key="button.value"
      @click="button.function(button.value)"
    >
      <!-- handleButtonClick(button) button.function(button.value)-->
      {{ button.label }}
    </button>
  </div>
</template>

<script setup lang="ts">
  import { useCalculator } from '@/composables/calculator'

  const { buttons } = useCalculator()
</script>

<style scoped>
  .calculator-buttons {
    display: grid;
    min-height: calc(80% - 5px);
    grid-template-columns: repeat(4, 1fr);
    grid-gap: 10px;
    user-select: none;
  }
  .btn {
    background-color: var(--btn-background);
    color: var(--btn-color);
    height: 100%;
    font-size: 1.5em;
    border: 1px solid black;
    border-radius: 10px;

    transition: background-color 0.1s ease-in-out, color 0.3s ease-in-out;
  }
  .btn:hover {
    background: var(--btn-hover);
    color: var(--color-primary-5);
    cursor: pointer;
  }

  .operator:hover {
    /* color: var(--color-primary-5) !important; */
  }
  .clear:hover {
    color: var(--color-primary-6) !important;
  }
  /* .equal:hover {
    color: var(--color-complement-1) !important;
  } */
  .number {
    background-color: var(--btn-number-background) !important;
  }
  .number:hover {
    background-color: var(--color-complement-2) !important;
    color: var(--color-primary-0);
  }
</style>
