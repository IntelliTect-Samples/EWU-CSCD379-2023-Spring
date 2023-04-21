<script setup lang="ts">
import name_and_logo from '@/assets/Xela_Games.png'
import 'animate.css'
</script>

<script lang="ts">
  export default {
    data: () => ({
      showImage: false,
    })
  }
</script>

<template id="body">
  <br/> <br/>
  <h1 id='h1'>Welcome to . . . <v-btn color="#27AE6A" @click="showImage = !showImage">CLICK ME</v-btn></h1>
  <br/> <br/>
  <div>
  </div>
  <transition
  enter-active-class="animate__animated animate__fadeInDown"
  leave-active-class="animate__animated animate__fadeOutUp"
  >
    <img id="XelaFullLogo" alt="Xela Games Logo" class="logo" :src="name_and_logo" v-if="showImage"/>
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

</style>
