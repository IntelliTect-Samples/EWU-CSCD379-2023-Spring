<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
    
    <v-card>
        <v-card-title>
            Debatably Easier Hangman
        </v-card-title>
        <v-card-item>
            <div class="text-caption"> sample text sample text sample text sample text sample text sample text </div>
        </v-card-item>
        <v-card-actions>
            <v-btn variant="outlined">
                <RouterLink to="/">Home</RouterLink>
            </v-btn>
        </v-card-actions>
    </v-card>
  
</template>


<style scoped>
header {
  line-height: 1.5;
  max-height: 100vh;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

nav {
  width: 100%;
  font-size: 12px;
  text-align: center;
  margin-top: 2rem;
}

nav a.router-link-exact-active {
  color: var(--color-text);
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
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }

  nav {
    text-align: left;
    margin-left: -1rem;
    font-size: 1rem;

    padding: 1rem 0;
    margin-top: 1rem;
  }
}
</style>
