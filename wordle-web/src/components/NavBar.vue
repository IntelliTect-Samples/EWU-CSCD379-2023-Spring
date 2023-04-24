
<template>
    <v-layout>
        <v-app-bar class="custom-app-bar" color="primary" density="compact">
            <template v-slot:prepend>
                <RouterLink to="/wordle">
                    <h1 class="titleClass">Wordle Web</h1>
                </RouterLink>
                <RouterLink to="/">
                    <v-icon color="hsla(160, 100%, 37%, 1)" icon="mdi-alpha-w-box" size="large" />
                </RouterLink>


                <v-btn @click="setDarkTheme"> Dark Theme </v-btn>
                <v-btn @click="setInverseTheme"> Inverse Theme </v-btn>
                <v-btn @click="setKhorneTheme"> Khorne Theme </v-btn>
                <v-btn @click="setCornTheme"> Corn Theme </v-btn>






            </template>

            <SettingsTab/>
            <template v-slot:append>
                <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
            </template>
        </v-app-bar>

        <v-navigation-drawer v-model="drawer" temporary location="right">
            <v-list density="compact" nav>
                <v-list-item prepend-icon="mdi-trophy" title="About" value="about" to="/about"></v-list-item>
            </v-list>
        </v-navigation-drawer>
    </v-layout>
</template> 

<script setup lang="ts">

import SettingsTab from '@/components/SettingsPopout.vue'
import { ref } from 'vue'
import { useTheme } from 'vuetify/lib/framework.mjs'

const theme = useTheme()

let drawer = ref(false)
function setInverseTheme() {
  theme.global.name.value = 'inverse'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}
function setKhorneTheme() {
  theme.global.name.value = 'khorne'
}
function setCornTheme() {
  theme.global.name.value = 'corn'
}

</script>