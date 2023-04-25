<script setup lang="ts">
import name_and_logo from '@/assets/Xela_Games.png'
import 'animate.css'
</script>

<script lang="ts">
export default {
  data: () => ({
    showContent: false
  })
}
</script>

<template id="body">
  <h1 id="h1">
    Welcome to . . . <v-btn color="secondary" @click="showContent = !showContent">CLICK ME</v-btn>
  </h1>
  <br />
  <br />
  <div></div>
  <transition
    enter-active-class="animate__animated animate__fadeInDown"
    leave-active-class="animate__animated animate__fadeOutUp"
  >
    <img
      id="XelaFullLogo"
      alt="Xela Games Logo"
      class="logo"
      :src="name_and_logo"
      v-if="showContent"
    />
  </transition>
  <transition
    enter-active-class="animate__animated animate__fadeIn"
    leave-active-class="animate__animated animate__fadeOut"
  >
    <v-card-text class="flex text-center text-h5 pa-15" v-if="showContent">
      Try our newest game:
      <v-btn to="/wordle" variant="outlined" color="secondary">WORDLE MIND BENDER</v-btn>
    </v-card-text>
  </transition>
</template>

<style>
#h1 {
  font-family: sans-serif;
  font-size: 45px;
  text-align: center;
}

#XelaFullLogo {
  display: block;
  margin-left: auto;
  margin-right: auto;
  width: 450px;
}

#body {
  max-width: 500px;
}

.animate__animated.animate__fadeIn {
  animation-delay: 1s;
}
</style>
