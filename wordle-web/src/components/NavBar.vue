<template>
   <v-layout>
     <v-app-bar color="grey" density="compact" primary>
       <v-app-bar-title to="../wordle">
         <v-btn :ripple="false" variant="plain" to="../wordle">
           <v-icon>mdi-file-word-box</v-icon>
           Wurdle
         </v-btn>
       </v-app-bar-title>

       <TutorialCard></TutorialCard>
       <SettingsTab></SettingsTab>
       <template v-slot:append>
         <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
       </template>
     </v-app-bar>

     <v-navigation-drawer v-model="drawer" temporary location="right">
       <v-list density="compact" nav>
        <v-list-item prepend-icon="mdi-controller" title="Game" value="game" to="/wordle"></v-list-item>
         <v-list-item prepend-icon="mdi-forum" title="About" value="about" to="/about"></v-list-item>
         <v-list-item prepend-icon="mdi-file-word-box" title="Home" value="Home" to="/"></v-list-item>
         
       </v-list>
     </v-navigation-drawer>
   </v-layout>
 </template>

 <script setup lang="ts">

 import { ref } from 'vue'
 let drawer = ref(false)
 </script>