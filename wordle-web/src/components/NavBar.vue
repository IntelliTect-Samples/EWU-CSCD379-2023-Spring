<template>
    <v-toolbar :elevation="4">

        <template v-slot:append>
          <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
        </template>

        <template v-slot:prepend >
                <v-btn icon to="/">
                    <v-icon size="x-large">mdi-earth</v-icon>
                </v-btn>
        </template>

        <v-app-bar-title @click="$router.push('/')"> 
            Word War 1
        </v-app-bar-title>
        
        <v-navigation-drawer app v-model="drawer"  rail rail-width="30px" location="right" temporary>
            <v-list>
                <v-list-item>
                <template v-slot:prepend>
                    <v-app-bar-nav-icon class="close-icon" icon="mdi-close-circle-outline" @click="drawer = !drawer"></v-app-bar-nav-icon>
                </template>
                </v-list-item>
                <v-list-item >
                    <RouterLink to="/">
                        <v-btn class="neon-button">Home</v-btn>
                    </RouterLink>
                </v-list-item>
                <v-list-item>
                    <RouterLink to="/about">
                        <v-btn class="neon-button">About</v-btn>
                    </RouterLink>
                </v-list-item>
                <v-list-item>
                    <RouterLink to="/wordle">
                        <v-btn class="neon-button">Game</v-btn>
                    </RouterLink>
                </v-list-item>
            </v-list>

        </v-navigation-drawer>

    </v-toolbar>


</template>

<script lang="ts">
import { RouterLink } from 'vue-router'

export default {
    data() {
        return {
            drawer: false
        }
    }
}
</script>

<style scoped>
    .v-toolbar {
        background-image: url('@/assets/brick-background.jpg');
    }
    .v-app-bar-nav-icon {
        color: hsl(317, 100%, 55%);
        transform: scale(1.5);
    }

    .v-app-bar-title {
        cursor: pointer;
        color: hsl(112, 100%, 49%);
        font-size: 1.7rem;
        text-decoration: underline;
        transform: translateY(-.1rem);
    }

    .v-list{    
        display: flex;
        flex-direction: column;
    }
    
    .neon-button {
        color: hsl(317, 100%, 55%);

        font-size: 1.5rem;
        font-weight: 700;

        text-shadow: 
            0 0 0.1em white, 
            0 0 .55em black;

        box-shadow: 
            inset 0 0 0.5em  hsl(317, 100%, 55%);

        border: hsl(317, 100%, 55%) 3px solid;
        border-radius: .5rem;
        margin-bottom: 2rem;
        width: 8rem;
    }
    .close-icon {
        color: hsl(317, 100%, 55%);
        transform: scale(1.2);
        transform: translate(6.3rem, -1rem);
    }

    .neon-button:hover, 
    .neon-button:focus{
        text-shadow: none;
        color: rgb(0, 178, 228);
        background: hsl(317, 100%, 55%);
        box-shadow:  0 .5em .9rem hsl(317, 100%, 55%);
    }

    .neon-button:hover::after {
        opacity: .9;
    }
</style>
