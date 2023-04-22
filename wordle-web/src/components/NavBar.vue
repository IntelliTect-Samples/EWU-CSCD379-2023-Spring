<template>
  <v-toolbar :elevation="4">
    <template v-slot:prepend>
      <v-btn icon to="/">
        <v-icon color="success" size="x-large">mdi-earth</v-icon>
      </v-btn>
    </template>

    <v-app-bar-title @click="$router.push('/')" align="center" class="font-weight-bold">
      Word War 1
    </v-app-bar-title>

    <template v-slot:append>
      <v-app-bar-nav-icon
        size="x-large"
        color="success"
        @click="drawer = !drawer"
      ></v-app-bar-nav-icon>
    </template>

    <v-navigation-drawer app v-model="drawer" rail rail-width="30px" location="right" temporary>
      <template v-slot:prepend>
        <v-btn
          color="purple-accent-2"
          size="medium"
          class="ml-4 mt-1"
          icon="mdi-close-circle-outline"
          @click="drawer = !drawer"
        ></v-btn>
        <v-btn
          color="purple-accent-2"
          size="medium"
          class="ml-3 mt-1"
          icon="mdi-cog-outline"
          @click="dialog = true"
        ></v-btn>
        <v-dialog v-model="dialog" width="40%">
          <v-card>
            <!-- -----------------------------FOR TESTING CUSTOM THEMES------------------------------>
            <v-container class="fill-height">
              <v-responsive class="d-flex align-center text-center fill-height">
                <h3 class="text-h2 font-weight-bold">Theme Demo</h3>

                <div class="py-5" />

                <v-row class="d-flex align-center justify-center">
                  <v-col cols="auto">
                    <v-btn color="primary"> Primary </v-btn>
                  </v-col>
                  <v-col cols="auto">
                    <v-btn color="secondary"> Secondary </v-btn>
                  </v-col>
                  <v-col cols="auto"> <v-btn color="error"> Error </v-btn> </v-col>
                </v-row>

                <v-row class="d-flex align-center justify-center">
                  <v-col cols="auto">
                    <v-btn color="info"> Info </v-btn>
                  </v-col>
                  <v-col cols="auto">
                    <v-btn color="success"> Success </v-btn>
                  </v-col>
                  <v-col cols="auto">
                    <v-btn color="warning"> Warning </v-btn>
                  </v-col>
                </v-row>
              </v-responsive>
            </v-container>
            <!---------------------------------------------------------------------------------------------------------------->
            <v-card-title> Display </v-card-title>
            <v-select
              label="Select Theme"
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
      <v-list class="mt-2">
        <v-list-item>
          <v-btn class="neon-button" @click="$router.push('/')"> Home </v-btn>
        </v-list-item>
        <v-list-item>
          <v-btn class="neon-button" @click="$router.push('/about')"> About </v-btn>
        </v-list-item>
        <v-list-item>
          <v-btn class="neon-button" @click="$router.push('/wordle')"> Game </v-btn>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
  </v-toolbar>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useTheme } from 'vuetify'

const theme = useTheme()
const myThemes = ['dark', 'light', 'ChristmasSweater', 'Easter', 'Neon']
const selectedTheme = ref(myThemes[4])

const setTheme = () => {
  theme.global.name.value = selectedTheme.value
  // Optional: Get value of current theme
  console.log(`Current theme is ${theme.global.current.value}`)
}
</script>

<script lang="ts">
export default {
  data() {
    return {
      drawer: false,
      dialog: false
    }
  }
}
</script>

<style scoped>
.v-toolbar {
  background-image: url('@/assets/brick-background.jpg');
}

.v-app-bar-title {
  cursor: pointer;
  color: rgb(118, 255, 3);
  font-size: 1.7rem;
  text-decoration: underline;
  transform: translateY(-0.1rem);
}

.neon-button {
  color: hsl(317, 100%, 55%);

  font-size: 1.5rem;
  font-weight: 700;

  text-shadow: 0 0 0.1em white, 0 0 0.55em black;

  box-shadow: inset 0 0 0.5em hsl(317, 100%, 55%);

  border: hsl(317, 100%, 55%) 3px solid;
  border-radius: 0.5rem;
  margin-bottom: 2rem;
  width: 8rem;
}

.neon-button:hover,
.neon-button:focus {
  text-shadow: none;
  color: rgb(0, 178, 228);
  background: hsl(317, 100%, 55%);
  box-shadow: 0 0.5em 0.9rem hsl(317, 100%, 55%);
}

.neon-button:hover::after {
  opacity: 0.9;
}
</style>
