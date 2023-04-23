<script setup lang="ts">
    import Gameboard from '../components/GameBoard.vue'
    import { useTheme } from 'vuetify'
    const letterColor = [useTheme().global.current.value.colors.unknown, useTheme().global.current.value.colors.correct, useTheme().global.current.value.colors.misplaced, useTheme().global.current.value.colors.wrong]
</script>

<template>
    <Gameboard :colors="letterColor"/>
</template>

<style>
</style>