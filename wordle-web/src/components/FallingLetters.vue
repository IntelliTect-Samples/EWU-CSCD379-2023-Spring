<template>
  <div class="falling-letters-background">
    <!-- Falling letters code goes here -->
    <div v-for="letter in letters" :key="letter.id" class="falling-letter" :style="letter.style">
      {{ letter.text }}
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'

const letters = ref<Array<{ id: number; text: string; style: Record<string, string> }>>([])

onMounted(() => {
  createLetters()
})

function createLetters() {
  const alphabet = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'

  setInterval(() => {
    const randomLetter = alphabet[Math.floor(Math.random() * alphabet.length)]

    const letter = {
      id: Date.now(),
      text: randomLetter,
      style: {
        left: `${Math.random() * 369}%`,
        top: '-10vh',
        transform: `
            translate3d(${Math.random() * 360}px, -10vh, ${Math.random() * -500}px)
            rotateX(${Math.random() * 360}deg)
            rotateY(${Math.random() * 360}deg)
            rotateZ(${Math.random() * 360}deg)
          `
      }
    }

    letters.value.push(letter)

    setTimeout(() => {
      removeLetter(letter.id)
    }, 8000)
  }, 400)
}

function removeLetter(id: number) {
  const index = letters.value.findIndex((letter) => letter.id === id)
  if (index !== -1) {
    letters.value.splice(index, 1)
  }
}
</script>

<style scoped>
.falling-letters-background {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  overflow: hidden;
  z-index: -1;
  perspective: 3rem; /* Adjust the perspective value as needed */
}

.falling-letter {
  position: absolute;
  color: #00ff00;
  font-size: 5rem;
  animation: cascade 15s infinite;
  transform-style: preserve-3d;
}

@keyframes cascade {
  0% {
    transform: translateY(-10vh) rotateX(0deg) rotateY(0deg);
  }
  100% {
    transform: translateY(110vh) rotateX(360deg) rotateY(360deg);
  }
}
</style>
