<template>
    <v-toolbar>
      <template v-slot:prepend>
        <v-btn icon to="/" >
          <v-icon color="deep-orange-accent-3" size="x-large" icon="mdi-check-circle"></v-icon>   
        </v-btn>
      </template>

        <v-app-bar-title @click="$router.push('/')" class="font-weight-bold">
      Wordle But Better
    </v-app-bar-title>


      <template v-slot:append>
        <v-app-bar-nav-icon
          size="x-large"
          color="deep-orange-accent-3"
          @click="drawer = !drawer"
        ></v-app-bar-nav-icon>

          <v-btn
            color="light-green-accent-3"
            size="medium"
            class="pa-4 text-end"
            icon="mdi-cog-outline"
            
            @click="dialog = true"
          ></v-btn>
          <v-dialog v-model="dialog" width="40%">
            <v-card>
              <v-card-title> Settings </v-card-title>
              <v-select
                label="Select Theme Color"
                v-model="selectedTheme"
                :items="myThemes"
                @update:modelValue="setTheme()"
                variant="solo"
                hide-selected
                class="mx-10"
              ></v-select>
              <v-card-actions>
                <v-btn color="info" text @click="dialog = false">Close</v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>

      </template>
      
  
      <v-navigation-drawer app v-model="drawer" rail rail-width="30px" location="right" temporary>
        
        <v-list class="mt-2">
          <v-list-item>
            <v-btn color="deep-orange-accent-3" variant="outlined" class="nav-btn" @click="$router.push('/')">
              Home
            </v-btn>
          </v-list-item>
          <v-list-item>
            <v-btn color="deep-orange-accent-3" variant="outlined" class="nav-btn" @click="$router.push('/wordle')">
              Game
            </v-btn>
          </v-list-item>
          <v-list-item>
            <v-btn
              color="deep-orange-accent-3"
              variant="outlined"
              class="nav-btn"
              @click="$router.push('/about')"
            >
              About
            </v-btn>
          </v-list-item>
              <v-list-item>
            <v-btn
              color="deep-orange-accent-3"
              variant="outlined"
              class="nav-btn"
              @click="$router.push('/game')"
            >
            Working on Game
            </v-btn>
            <v-list-item>
               <v-btn
            color="deep-orange-accent-3"
            size="medium"
            class="ml-4 mt-1"
            icon="mdi-close-circle-outline"
            @click="drawer = !drawer"
          ></v-btn>
        </v-list-item>
          </v-list-item>
        </v-list>
      </v-navigation-drawer>
    </v-toolbar>
  </template>
  <script setup lang="ts">
  import { ref } from 'vue'
  import { useTheme } from 'vuetify'
  import { RouterView } from 'vue-router'

  
  let drawer = ref(false)
  let dialog = ref(false)
  
  const theme = useTheme()
  const myThemes = ['dark', 'light']
  const selectedTheme = ref(myThemes[1])
  
  const setTheme = () => {
    theme.global.name.value = selectedTheme.value
    console.log(`Current theme is ${theme.global.current.value}`)
  }
  </script>
  

  