<script lang="ts">
  export default {
    data () {
      return {
        dialog: false,
        themeselect: useTheme().global.current.value.dark ? useTheme().global.name.value.substring(0, useTheme().global.name.value.length - 4) : useTheme().global.name.value.substring(0, useTheme().global.name.value.length - 5),
        themedark: useTheme().global.current.value.dark ? "Dark" : "Light",
        //guesses: 6,
        //guessLabels: ['3', '6', '9', '12'],
        colors: [useTheme().global.current.value.colors.unknown, useTheme().global.current.value.colors.correct, useTheme().global.current.value.colors.misplaced, useTheme().global.current.value.colors.wrong],
      }
    },
    setup () {
      const theme = useTheme()
      return {
        theme,
        toggleTheme: () => {
          const r = document.querySelector('html');
          let t = ''
          if(theme.global.current.value.dark){
            t = theme.global.name.value.substring(0, theme.global.name.value.length - 4)
        } else {
          t = theme.global.name.value.substring(0, theme.global.name.value.length - 5)
        }
        theme.global.name.value = theme.global.current.value.dark ? (t.concat('Light')) : (t.concat('Dark'))
        if(theme.global.current.value.dark){
          r!.style.setProperty('--v-sett-text', 'antiquewhite')
          r!.style.setProperty('--v-sett-back', '#323232')
          r!.style.setProperty('--v-menu-bottom', 'white')
          r!.style.setProperty('--v-back', '#141414')
        } else {
          r!.style.setProperty('--v-sett-text', '#323232')
          r!.style.setProperty('--v-sett-back', 'antiquewhite')
          r!.style.setProperty('--v-menu-bottom', 'black')
          r!.style.setProperty('--v-back', '#d9d9d9')
        }
      }, 
      toggleScheme: (rad:string, tog:string) => {
        theme.global.name.value = rad.concat(tog)
      }
    }
  }
}

import { useTheme } from 'vuetify'
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <v-layout>
    <v-app-bar>
      <v-btn prepend-icon="mdi-castle" variant="plain" to="/" color="primary" style="font-size: 1.5rem;"><strong> Wordle </strong></v-btn>

      <v-spacer></v-spacer>

      <v-dialog v-model="dialog" width="auto">
        <template v-slot:activator="{ props }">
          <v-btn icon="mdi-cog" variant="plain" class="right" v-bind="props"  color="primary"></v-btn>
        </template>

        <v-card id="sett">
          <v-card-text>
            <h1><strong>Settings</strong></h1>
            
            <h2>Theme/Appearance</h2>
            <p> <v-icon icon="mdi-theme-light-dark"></v-icon> Light Mode/Dark Mode </p>
            <v-radio-group v-model="themedark" column @change="toggleTheme" style="margin-left: 25px;">
              <v-radio label="Dark" color="primary" value="Dark"></v-radio>
              <v-radio label="Light" color="primary" value="Light"></v-radio>
            </v-radio-group>

            <p> <v-icon icon="mdi-water-opacity"></v-icon> Color Scheme: </p>
            <v-radio-group v-model="themeselect" column @change="toggleScheme(themeselect, themedark)" style="margin-left: 25px;">
              <v-radio label="Default" color="primary" value="default"></v-radio>
              <v-radio label="Autumn" color="primary" value="autumn"></v-radio>
              <v-radio label="Coffee" color="primary" value="coffee"></v-radio>
              <v-radio label="Unicorn Vomit" color="primary" value="unicornVomit"></v-radio>
            </v-radio-group>
            <br>
            <h2>Gameplay</h2>
            <p># of Guesses</p>
            <!-- <v-slider :ticks="guessLabels" v-model="guesses" :min="3" :max="12" :step="1" show-ticks="always" class="slide"></v-slider> -->
          </v-card-text>
          <v-card-actions>
            <v-btn block @click="dialog = false" color="primary">Close Dialog</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>

      <div class="text-center">
        <v-menu open-on-hover>
          <template v-slot:activator="{ props }">
            <v-btn icon="mdi-menu" variant="plain" class="right"  color="primary" v-bind="props"></v-btn>
          </template>

          <v-list>
            <v-list-item to="/about"><v-list-item-title>About</v-list-item-title></v-list-item>
          </v-list>
        </v-menu>
      </div>
        
    </v-app-bar>

    <v-main>
      <RouterView />
    </v-main>
  </v-layout>
</template>


<style scoped>
  .slide {
    min-width: 250px;
  }
  #sett h1 {
    text-align: center;
    margin-bottom: 1.5rem;
    border-bottom: 5px double var(--v-sett-text);
  }
  #sett h2 {
    border-bottom: 1px dotted var(--v-sett-text);
    margin-bottom: .5rem;
  }
  #sett {
    background-color: var(--v-sett-back);
    border: 1px solid black;
    color: var(--v-sett-text);
    padding: 15px 25px;
  }
</style>
