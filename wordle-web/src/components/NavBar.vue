<template>
    <v-toolbar :elevation="4">

        <template v-slot:prepend>
          <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
        </template>

        <v-app-bar-title> Word War 1 </v-app-bar-title>
        
        <v-navigation-drawer app v-model="drawer"  rail rail-width="30px" location="left" temporary>
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
            0 0 .55em currentColor;

        box-shadow: 
            inset 0 0 0.5em  hsl(317, 100%, 55%);

        border: hsl(317, 100%, 55%) 3px solid;
        border-radius: .5rem;
        margin-bottom: 2rem;
        width: 8rem;
        position: relative;
    }
    .close-icon {
        color: hsl(317, 100%, 55%);
        transform: scale(1.2);
        transform: translate(6.3rem, -1rem);
    }

    .neon-button:hover, 
    .neon-button:focus{
        color: rgb(0, 178, 228);
        background: hsl(317, 100%, 55%);
        box-shadow:  0 .5em .9rem hsl(317, 100%, 55%);
        text-shadow: none;
    }

    .neon-button:hover::after {
        opacity: 1;
    }
</style>
