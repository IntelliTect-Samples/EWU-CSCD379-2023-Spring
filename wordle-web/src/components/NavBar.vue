<template>
    <v-layout>
        <v-app-bar color="primary">
        <v-app-bar-title to="/">
            <v-btn :ripple="false" variant="plain" to="/">
                <v-icon>mdi-file-word-box-outline</v-icon>
                Wordle
            </v-btn>
        </v-app-bar-title>

        <Settings></Settings>
        <template v-slot:append>
        <v-app-bar-nav-icon @click.stop="dialog = !dialog"></v-app-bar-nav-icon>
      </template>
        </v-app-bar>
         <v-navigation-drawer v-model="dialog" temporary location="right">
      <v-list density="compact" nav>
        <v-list-item
          prepend-icon="mdi-file-word-box-outline"
          title="Home"
          value="home"
          to="/"
        ></v-list-item>
        <v-list-item 
          prepend-icon="mdi-information-variant" 
          title="About" 
          value="about" 
          to="/about">
        </v-list-item>
        <v-list-item
        prepend-icon="mdi-numeric-1-box"
        title="Leaderboard"
        value="leaderboard"
        to="/leaderboard">
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    </v-layout>
</template>

<script setup lang="ts">
import Settings from '@/components/Settings.vue'
import { ref } from 'vue'

let dialog = ref(false)
</script>