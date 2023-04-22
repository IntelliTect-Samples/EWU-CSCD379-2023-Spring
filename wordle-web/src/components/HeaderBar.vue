<template>
    <div class = 'headerBar'>
      <v-card>
        <v-layout>
          <v-app-bar elevation = '2'>

            <v-btn to = '/' icon = 'mdi-axis'></v-btn>

            <v-app-bar-title>
              <RouterLink to = '/'>
                A Play on Wordle
              </RouterLink>
            </v-app-bar-title>

            <template v-slot:append>
              <v-app-bar-nav-icon @click.stop = "drawer = !drawer"></v-app-bar-nav-icon>
              <v-app-bar-nav-icon @click.stop = "settings = !settings">
                <v-icon>mdi-cog</v-icon>
              </v-app-bar-nav-icon>
            </template>

          </v-app-bar>

          <v-navigation-drawer location = 'right' v-model = "drawer" elevation = '1'>
            <v-list-item-group>
                <v-list-item>
                    <RouterLink to = '/' @click = 'drawer = false'>Home</RouterLink>
                </v-list-item>
                <v-list-item>
                    <RouterLink to = '/wordle' @click = 'drawer = false'>Wordle Game</RouterLink>
                </v-list-item>
                <v-list-item>
                    <RouterLink to = '/about' @click = 'drawer = false'>About</RouterLink>
                </v-list-item>
            </v-list-item-group>
          </v-navigation-drawer>

          <v-navigation-drawer location = 'right' v-model = "settings" width = 'fit-content' elevation = '1'>
            <v-list-item-group>
                <v-list-item>
                    <v-btn icon = 'mdi-white-balance-sunny' @click = 'setLightTheme'/>
                </v-list-item>
                <v-list-item>
                    <v-btn icon = 'mdi-moon-waning-crescent' @click = 'setDarkTheme'/>
                </v-list-item>
                <v-list-item>
                  <v-divider/>
                </v-list-item>
                <v-list-item>
                    <v-btn icon = 'mdi-alpha-d-circle' @click = 'setDefaultTheme'/>
                </v-list-item>
                <v-list-item>
                    <v-btn icon = 'mdi-unicorn-variant' @click = 'setUnicornTheme'/>
                </v-list-item>
                <v-list-item>
                    <v-btn icon = 'mdi-halloween' @click = 'setPumpkinTheme'/>
                </v-list-item>
            </v-list-item-group>
          </v-navigation-drawer>

        </v-layout>
      </v-card>
    </div>
</template>

<script lang = 'ts'>
export default {
    data: () => ({
        drawer: false,
        settings: false,
    })
  }

</script>

<script setup lang = 'ts'>
import { ref } from 'vue';

const emits = defineEmits<{
    (event: 'setTheme', value: string): void
}>()

const currentTheme = ref('dark');

const lightTheme = ref(false);

function setLightTheme() {
  lightTheme.value = true;
  if(currentTheme.value === 'dark') {
    setDefaultTheme();
  } else if(currentTheme.value === 'unicornDark') {
    setUnicornTheme();
  } else if(currentTheme.value === 'pumpkinDark') {
    setPumpkinTheme();
  }
}

function setDarkTheme() {
  lightTheme.value = false;
  if(currentTheme.value === 'light') {
    setDefaultTheme();
  } else if(currentTheme.value === 'unicornLight') {
    setUnicornTheme();
  } else if(currentTheme.value === 'pumpkinLight') {
    setPumpkinTheme();
  }
}

function setDefaultTheme() {
  if(lightTheme.value) {
    currentTheme.value = 'light';
    emits('setTheme', 'light')
  } else {
    currentTheme.value = 'dark';
    emits('setTheme', 'dark')
  }
}

function setUnicornTheme() {
  if(lightTheme.value) {
    currentTheme.value = 'unicornLight';
    emits('setTheme', 'unicornLight')
  } else {
    currentTheme.value = 'unicornDark';
    emits('setTheme', 'unicornDark')
  }
}

function setPumpkinTheme() {
  if(lightTheme.value) {
    currentTheme.value = 'pumpkinLight';
    emits('setTheme', 'pumpkinLight')
  } else {
    currentTheme.value = 'pumpkinDark';
    emits('setTheme', 'pumpkinDark')
  }
}
</script>

<style scoped>
nav {
  width: 100%;
  font-size: 12px;
  text-align: center;
  margin-top: 2rem;
}

nav a.router-link-exact-active {
  text-decoration: underline;
}

nav a.router-link-exact-active:hover {
  background-color: transparent;
}

nav a {
  display: inline-block;
  padding: 0 1rem;
  border-left: 1px solid var(--color-border);
}

nav a:first-of-type {
  border: 0;
}

@media (min-width: 1024px) {

  nav {
    text-align: left;
    margin-left: -1rem;
    font-size: 1rem;

    padding: 1rem 0;
    margin-top: 1rem;
  }
}
</style>