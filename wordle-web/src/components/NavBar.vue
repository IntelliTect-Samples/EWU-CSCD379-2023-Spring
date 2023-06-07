<template>
  <nav>
    <v-toolbar color="primary" flat app>
      <v-toolbar-title @click="$router.push('/')"
        ><v-icon>mdi-diamond-stone</v-icon> Wordle Redux</v-toolbar-title
      >
      <v-spacer></v-spacer>
      <v-toolbar-items v-if="display.mdAndUp">
        <v-btn to="/">Home</v-btn>
        <v-btn to="/wordle">Wordle</v-btn>
        <v-btn to="/leaderboard">Leader Board</v-btn>
        <v-btn to="/about">About</v-btn>
        <v-btn to="/worldoftheday">Wordle of the Day</v-btn>
      </v-toolbar-items>
      <v-toolbar-items>
        <GameInstruction/>
        <v-app-bar-nav-icon @click="setTheme('default')" icon="mdi-theme-light-dark"> </v-app-bar-nav-icon>
        <v-app-bar-nav-icon @click.stop="setting = true" icon="mdi-cog"></v-app-bar-nav-icon>
        <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      </v-toolbar-items>
    </v-toolbar>  

    <v-navigation-drawer location="right" @click.stop="drawer = !drawer" v-model="drawer" temporary>
      <v-list-item >
        <v-list-item-content>
          <v-list-item-title class="title">Wordle Redux</v-list-item-title>
          <v-list-item-subtitle>Wordle Redux</v-list-item-subtitle>
          <v-list-item prepend-icon="mdi-home" to="/">
            Home
          </v-list-item>
          <v-list-item prepend-icon="mdi-star" to="/wordle">
            Wordle
          </v-list-item>
          <v-list-item prepend-icon="mdi-calendar-today" to="/worldoftheday" >
            Wordle Of the Day
          </v-list-item>
          <v-list-item prepend-icon="mdi-star-box" to="/leaderboard">
            Leader Board
          </v-list-item>
          <v-list-item prepend-icon="mdi-table-clock" to="/lasttenwords">
            Last 10 Wordle of the day
          </v-list-item>
          <v-list-item prepend-icon="mdi-playlist-edit" to="/wordeditor">
            Word Editor
          </v-list-item>
          <v-list-item prepend-icon="mdi-cog" @click.stop="setting = true" @click="drawer = !drawer">
            Setting
          </v-list-item>
          <v-list-item v-if="!signInService.isSignedIn" prepend-icon="mdi-account-cancel" @click="showSignInDialog = true">
            Sign In
          </v-list-item>
          <v-list-item prepend-icon="mdi-account-check" v-if="signInService.isSignedIn" @click="signInService.signOut()">
            Sign Out
          </v-list-item>
          <v-list-item prepend-icon="mdi-information" to="/about" v-if="signInService.isSignedIn">
            About 
          </v-list-item>
        </v-list-item-content>
      </v-list-item>
    </v-navigation-drawer>
  </nav>

  <v-dialog v-model="setting" width="auto">
    <v-card>
      <v-list-item>
        <v-list-item-content>
          <v-list-item-title class="title">Wordle Redux</v-list-item-title>
          <v-list-item-subtitle>Wordle Redux</v-list-item-subtitle>
          <v-list-item @click="setTheme('default')" prepend-icon="mdi-theme-light-dark">
            Light/Dark Mode
          </v-list-item>
          <p>Dark Mode Color Blind Theme</p>
          <v-list-item @click="setTheme('Protanopia_Deuteranopia')" prepend-icon="mdi-eye-plus">
            Protanopia/Deuteranopia Dark Mode
          </v-list-item>
          <v-list-item @click="setTheme('Tritanopia')" prepend-icon="mdi-eye-plus">
            Tritanopia Dark Mode
          </v-list-item>
          <p>Light Mode Color Blind Theme</p>
          <v-list-item @click="setTheme('Protanopia_DeuteranopiaLight')" prepend-icon="mdi-eye-plus-outline">
            Protanopia/Deuteranopia Light Mode
          </v-list-item>
          <v-list-item @click="setTheme('TritanopiaLight')" prepend-icon="mdi-eye-plus-outline">
            Tritanopia Light Mode
          </v-list-item>
        </v-list-item-content>
      </v-list-item>
    </v-card>
  </v-dialog>

  <SignInDialog v-model="showSignInDialog"> </SignInDialog>

</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import { ref } from 'vue'
import GameInstruction from './GameInstruction.vue'
import { inject, reactive } from 'vue'
import { useDisplay } from 'vuetify'
import { Services } from '@/scripts/services'
import SignInDialog from './SignInDialog.vue'
import type { SignInService } from '@/scripts/signInService'

const display = inject(Services.Display, () => reactive(useDisplay())) as unknown as ReturnType<
  typeof useDisplay
>

const signInService = inject(Services.SignInService) as SignInService


const showSignInDialog = ref(false)
const theme = useTheme()
const drawer = ref (false)
const setting = ref (false)


function setTheme(themecolor: string){
  if(themecolor === "light" )
    theme.global.name.value = 'light'
  else if(themecolor === "dark")
    theme.global.name.value = 'dark'
  else if(themecolor === "Protanopia_Deuteranopia")
    theme.global.name.value = 'Protanopia_Deuteranopia'
  else if(themecolor === "Tritanopia")
    theme.global.name.value = 'Tritanopia'
  else if(themecolor === "Protanopia_DeuteranopiaLight")
    theme.global.name.value = 'Protanopia_DeuteranopiaLight'
  else if(themecolor === "TritanopiaLight")
    theme.global.name.value = 'TritanopiaLight'
  else if(themecolor === "default")
    if (theme.global.name.value == 'light') {
      theme.global.name.value = 'dark'
    } else if (theme.global.name.value == 'dark') {
      theme.global.name.value = 'light'
    } else theme.global.name.value = 'light'
    }  


  
</script>



