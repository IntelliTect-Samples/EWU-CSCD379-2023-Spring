<template>
  <v-card>
    <v-layout>
      <v-app-bar>
        <template v-slot:prepend>
          <router-link to="/"
            ><v-app-bar-nav-icon icon="mdi-domain"></v-app-bar-nav-icon
          ></router-link>
          <router-link to="/"><v-app-bar-title> wordle</v-app-bar-title></router-link>
        </template>
        <template v-slot:append>
          <v-app-bar-nav-icon>
            <v-menu>
              <template v-slot:activator="{ props }">
                <v-btn v-bind="props" icon="mdi-hamburger"> </v-btn>
              </template>

              <v-list>
                <router-link to="/about"
                  ><v-list-item-title>Link To About Page</v-list-item-title></router-link
                >
                <router-link to="/wordle"
                  ><v-list-item-title>Link To Wordle Game</v-list-item-title></router-link
                >
              </v-list>
            </v-menu>
          </v-app-bar-nav-icon>
        </template>
      </v-app-bar>
    </v-layout>
  </v-card>
</template>

<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
</script>
