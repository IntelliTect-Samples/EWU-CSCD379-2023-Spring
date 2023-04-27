<script setup lang="ts">
import Para from '../components/MainPara.vue'
</script>

<template>
    <Para title="About" body="This is a neat little project for CSCD 379 - .NET Web Application Development. It's meant to emulate the Wordle browser game, and in some instances perhaps even exceed it in expectations. Made with Vue/Vuetify, primarily Typescript and a little CSS/HTML."></Para>
    <v-btn to="/" prepend-icon="mdi-chevron-left" append-icon="mdi-chevron-right" block size="large" elevation="12" variant="outlined" color="primary" class="button"> Back to Home </v-btn>
    <v-btn to="/game" prepend-icon="mdi-chevron-left" append-icon="mdi-chevron-right" block size="x-large" elevation="12" variant="outlined" color="primary" class="button"> Start Game </v-btn>
</template>

<style>
    .button {
        margin: 25px;
    }
</style>