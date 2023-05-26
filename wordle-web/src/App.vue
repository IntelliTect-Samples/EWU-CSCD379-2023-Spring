<template>
  <v-app :class="setImageTheme(theme.global.name.value)">
    <Navbar />
    <v-content>
      <RouterView></RouterView>
    </v-content>
  </v-app>
</template>

<script setup lang="ts">
import Navbar from './components/NavBar.vue'
import { useTheme } from 'vuetify/lib/framework.mjs'

const theme = useTheme()

function setImageTheme(themecolor: string){
  if(themecolor === "light" )
    return 'lightThemeBackground'
  else if(themecolor === "dark")
    return 'darkThemeBackground'
  else if(themecolor === "Protanopia_Deuteranopia")
    return 'Protanopia_DeuteranopiaBackground'
  else if(themecolor === "Tritanopia")
    return 'TritanopiaBackground'
  else if(themecolor === "Protanopia_DeuteranopiaLight")
    return 'Protanopia_DeuteranopiaLightBackground'
  else if(themecolor === "TritanopiaLight")
    return 'TritanopiaLightBackground'
    }  
</script>

<style>
.darkThemeBackground {
  background: url('@/assets/dark-low-poly.svg') no-repeat center center fixed !important;
  background-size: 100% 100%;
}
.lightThemeBackground {
  background: url('@/assets/light-low-poly.svg') no-repeat center center fixed !important;
  background-size: 100% 100%;
}
.Protanopia_DeuteranopiaBackground {
  background: url('@/assets/pro-dark-low-poly.svg') no-repeat center center fixed !important;
  background-size: 100% 100%;
}
.TritanopiaBackground{
  background: url('@/assets/tri-dark-low-poly.svg') no-repeat center center fixed !important;
  background-size: 100% 100%;
}
.Protanopia_DeuteranopiaLightBackground {
  background: url('@/assets/pro-light-low-poly.svg') no-repeat center center fixed !important;
  background-size: 100% 100%;
}
.TritanopiaLightBackground{
  background: url('@/assets/tri-light-low-poly.svg') no-repeat center center fixed !important;
  background-size: 100% 100%;
}
</style>