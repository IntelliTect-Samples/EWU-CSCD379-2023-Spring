<template>
    <v-card
      class="mx-auto"
      max-width="448">
      <v-layout>
        <v-app-bar
          density="compact">
          <template v-slot:prepend>
            <v-app-bar-nav-icon></v-app-bar-nav-icon>
          </template>
          <v-icon icon="mdi-head-cog" size="x-large"></v-icon>
          <v-app-bar-title>Wordle</v-app-bar-title>
          <template v-slot:append>
            <v-btn icon= "mdi-cog" @click.stop="drawer = !drawer">
            </v-btn>
          </template>
        </v-app-bar>

        <v-navigation-drawer v-model="drawer" location="right">
        <v-list>
          <v-btn @click="setInverseTheme"> Inverse Theme </v-btn>
          <v-btn @click="setDarkTheme"> Dark Theme </v-btn>
        </v-list>
      </v-navigation-drawer>
        <v-main>
            
        </v-main>
      </v-layout>
    </v-card>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { useTheme } from 'vuetify/lib/framework.mjs';

const theme = useTheme()

function setInverseTheme() {
  theme.global.name.value = 'inverse'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}

const drawer = ref(false);
</script>