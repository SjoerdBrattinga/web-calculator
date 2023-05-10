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
    background-color: rgb(59, 65, 65);
    display: flex;
    align-items: center;
    justify-content: center;
  }
</style>
