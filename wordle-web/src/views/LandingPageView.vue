<template>
  <v-container fluid class="fill-height">
    <v-row align="center" justify="center">
      <transition name="fade">
        <v-col cols="12" sm="8" md="6" lg="4" xl="3" v-if="showContent">
          <h1 :class="[{ 'fade-in': fadeIn, 'fade-out': fadeOut }, 'h1', 'text-center']">
            Welcome to a Wordle Clone Website
          </h1>
          <img
            src="../assets/eastern-washington-eagles-logo@logotyp.us.svg"
            alt="Logo"
            :class="[{ 'fade-in': fadeIn, 'fade-out': fadeOut }, 'logo', 'mx-auto']"
          />
          <a href="/howToPlay">
            <v-btn
              v-if="showContent"
              color="primary"
              :class="[{ 'fade-in': fadeIn, 'fade-out': fadeOut }, 'fade-in']"
              >How to Play</v-btn
            >
          </a>
        </v-col>
      </transition>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { ref, onMounted } from 'vue'

export default {
  setup() {
    const showContent = ref(false)
    const fadeIn = ref(false)
    const fadeOut = ref(false)

    onMounted(() => {
      setTimeout(() => {
        showContent.value = true
        fadeIn.value = true
        setTimeout(() => {
          fadeOut.value = true
          setTimeout(() => {
            window.location.href = '/wordle'
          }, 2000)
        }, 7000)
      })
    })

    return {
      showContent,
      fadeIn,
      fadeOut
    }
  }
}
</script>

<style scoped>
.fade-in {
  animation: fadeIn 2.5s;
}

@keyframes fadeIn {
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}

.fade-out {
  animation: fadeOut 2.5s;
}

@keyframes fadeOut {
  from {
    opacity: 1;
  }
  to {
    opacity: 0;
  }
}

.fade {
  transition: opacity 2s;
}

.logo {
  width: 100%;
  max-width: 100%; /* Set maximum width for the logo */
  margin-top: 20px;
}

.h1 {
  font-size: 3em;
}

@media (max-width: 600px) {
  .h1 {
    font-size: 1.3em;
  }
}
.v-btn {
  width: 100%;
}
</style>
