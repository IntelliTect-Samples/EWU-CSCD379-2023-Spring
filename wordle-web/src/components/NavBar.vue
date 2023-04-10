<script setup lang="ts">
 import { RouterLink } from 'vue-router'
</script>

<template>
    <v-toolbar class="navBar">
        <v-toolbar-items>
            <RouterLink to="/"> 
                <v-btn>Home</v-btn>
            </RouterLink>

            <RouterLink to="/about"> 
                <v-btn>About</v-btn> 
            </RouterLink>

            <RouterLink to="/game"> 
                <v-btn>Game<v-icon icon="mdi:mdi-controller" class="icon"/></v-btn>
            </RouterLink>
        </v-toolbar-items>
    </v-toolbar>
</template>

<style scoped>
    .v-toolbar-items {
        display: flex;
        justify-content: center;
        align-items: center;
        gap: 1rem;
        width: 100%;
    }
</style>
