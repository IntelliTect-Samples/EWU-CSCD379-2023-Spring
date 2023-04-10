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
        gap: 2rem;
        width: 100%;
    }

    .neon-button {
        color: hsl(317, 100%, 55%);

        font-size: 1.5rem;
        font-weight: 700;

        text-shadow: 
            0 0 0.1em white, 
            0 0 .55em currentColor;

        box-shadow: 
            inset 0 0 0.5em 0 hsl(317, 100%, 55%),
            0 0 0.5em 0 hsl(317, 100%, 55%);

        border: hsl(317, 100%, 55%) 3px solid;
        border-radius: .5rem;
        width: 8rem;
        position: relative;
    }

    .neon-button::before {
        pointer-events: none;
        content: '';
        position: absolute;

        top: 105%;
        left: 0;
        height: 100%;
        width: 100%;
        background: hsl(317, 100%, 55%);

        transform: perspective(1em) rotateX(40deg);
        filter: blur(1em);
        opacity: 0.7;
    }

    .neon-button::after {
        content: '';
        position: absolute;
        top: 0;
        bottom: 0;
        left: 0;
        right: 0;
        box-shadow: 0 0 1em 1em hsl(317, 100%, 55%);
    }

    .neon-button:hover, 
    .neon-button:focus{
        color: rgb(0, 178, 228);
        background: hsl(317, 100%, 55%);
        border-color: black;

        box-shadow: 0 0 2em .2em hsl(317, 100%, 55%);
        text-shadow: none;
    }

    .neon-button:hover::after {
        opacity: 1;
    }
</style>
