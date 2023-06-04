<template>
  <header>
    <div class="wrapper"></div>
  </header>
  <div class="ma-8"><NavigationBar /></div>
  <div><RouterView /></div>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router'
import NavigationBar from './components/NavigationBar.vue'
import { Services } from './scripts/services'
import { SignInService } from './scripts/signInService'
import { reactive, provide } from 'vue'

const signInService = reactive(new SignInService())
provide(Services.SignInService, signInService)
/*
setTimeout(() => {
  signInService.signIn('admin@intellitect.com', 'P@ssw0rd123')
}, 1000)
*/
</script>

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

nav a.router-link-exact-active:hover {
}

nav a {
  display: inline-block;
  padding: 0 1rem;
}
</style>
