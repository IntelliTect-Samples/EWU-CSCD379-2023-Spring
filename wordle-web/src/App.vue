<template>

  <header>
    <NavigationBar />
  <div class="wrapper"></div>
   
      <!-- <v-btn @click="setInverseTheme"> Inverse Theme </v-btn>
      <v-btn @click="setDarkTheme"> Dark Theme </v-btn>--> 
  </header>

  <RouterView />
</template>

<s setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import NavigationBar from './components/NavigationBar.vue'
import HelloWorld from './components/HelloWorld.vue'
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
