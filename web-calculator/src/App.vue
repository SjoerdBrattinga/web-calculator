<template>
  <!-- <header> -->
  <!-- </header> -->
  <main>
    <BasicCalculator />
  </main>
</template>

<script setup lang="ts">
  import BasicCalculator from './components/BasicCalculator.vue'
</script>

<style scoped>
  main {
    width: 100%;
    height: 100vh;
    background-color: rgb(59, 65, 65);
    display: flex;
    align-items: center;
    justify-content: center;
  }
</style>
