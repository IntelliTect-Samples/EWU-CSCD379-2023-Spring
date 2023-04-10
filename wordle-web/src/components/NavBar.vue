<script setup lang="ts">
 import { RouterLink } from 'vue-router'
</script>

<template>
    <v-toolbar :elevation="4">
        <v-toolbar-items>
            <RouterLink to="/"> 
                <v-btn class="neon-button">Home</v-btn>
            </RouterLink>

            <RouterLink to="/about"> 
                <v-btn class="neon-button">About</v-btn> 
            </RouterLink>

            <RouterLink to="/game"> 
                <v-btn class="neon-button">Game<v-icon icon="mdi:mdi-controller" class="icon"/></v-btn>
            </RouterLink>
        </v-toolbar-items>
    </v-toolbar>
</template>

<style scoped>
    .v-toolbar {
        background-image: url('@/assets/brick-background.jpg');
    }
    .v-toolbar-items {
        display: flex;
        justify-content: center;
        align-items: center;
        gap: 1rem;
        width: 100%;
    }

    .neon-button {
        color: hsl(317, 100%, 55%);

        font-size: 1.5rem;
        font-weight: 700;
        text-shadow: 0 0 .3em hsl(317, 87%, 12%);

        border: hsl(317, 100%, 55%) 3px solid;
        border-radius: .5rem;
        width: 8rem;
    }
</style>
