<script setup lang="ts">
    import Gameboard from '../components/GameBoard.vue'
</script>

<template>
    <Gameboard :guess="6" :colors="['grey', 'green', 'yellow', 'red']"></Gameboard>
</template>

<style>
</style>