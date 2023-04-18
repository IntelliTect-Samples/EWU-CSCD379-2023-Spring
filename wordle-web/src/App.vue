<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import logo from '@/assets/Xela_Games_Logo.png'
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

<template>
  <header>
    <div class="wrapper">
      <v-card>
        <v-layout>
          <v-app-bar color="#5439AA">
            <RouterLink to="/"
              ><img id="XelaLogo" alt="Xela Games Logo" class="logo" :src="logo" width="60"
            /></RouterLink>
            <v-app-bar-title
              ><RouterLink color="#ffffff" to="/">Xela Games</RouterLink></v-app-bar-title
            >

            <v-btn>
              <v-icon size="25px" icon="mdi:mdi-cog" />
            </v-btn>

            <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
          </v-app-bar>

          <v-navigation-drawer v-model="drawer" temporary location="end">
            <v-list density="compact" nav>
              <v-list-item title="Home" value="home" to="/"></v-list-item>
              <v-list-item title="About" value="about" to="/about"></v-list-item>
              <v-list-item title="Game" value="game" to="/game"></v-list-item>
              <v-list-item title="Wordle" value="wordle" to="/wordle"></v-list-item>
            </v-list>
          </v-navigation-drawer>
        </v-layout>
      </v-card>
      <!-- 
      <nav>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/about">About</RouterLink>
        <RouterLink to="/game">Game</RouterLink>
        <RouterLink to="/wordle">Wordle</RouterLink>
      </nav> -->
    </div>
  </header>

  <RouterView />
</template>

<!-- <style scoped>
header {
  line-height: 1.5;
  max-height: 100vh;
}

.logo {
  place-content: space-around start;
  display: block;
  margin: 0 auto 2rem;
}

/* nav {
  width: 100%;
  font-size: 12px;
  text-align: center;
  margin-top: 2rem;
}

nav a.router-link-exact-active {
  color: var(--color-text);
} */
/* 
nav a.router-link-exact-active:hover {
  background-color: transparent;
} */

/* nav a {
  display: inline-block;
  padding: 0 1rem;
  border-left: 1px solid var(--color-border);
}

nav a:first-of-type {
  border: 0;
} */

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: fle;
    place-items: flex-start;
    flex-wrap: wrap;
  }

  /* nav {
    text-align: left;
    margin-left: -1rem;
    font-size: 1rem;

    padding: 1rem 0;
    margin-top: 1rem;
  } */
}
</style> -->
