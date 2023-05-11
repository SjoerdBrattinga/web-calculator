<template>
  <!-- <header> -->
  <!-- </header> -->
  <!-- <main> -->

  <!-- </main> -->
  <div class="container">
    <BasicCalculator />
  </div>
</template>

<script setup lang="ts">
  import BasicCalculator from './components/BasicCalculator.vue'
</script>

<style scoped>
  .container {
    width: 100%;
    height: 100vh;
    /* background-color: var(--color-secondary-1-4); */
    background-color: var(--color-primary-2);
    display: flex;
    align-items: center;
    justify-content: center;
  }
</style>
