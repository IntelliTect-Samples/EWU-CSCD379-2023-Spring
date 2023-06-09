<template>
  <div>
    <div v-for="(letter, index) in letters" :class="letter.classes" :key="index">
      {{ letter.letter }}
    </div>
  </div>
</template>

<script lang="ts" setup>
import { onBeforeUnmount, reactive } from 'vue'
import { onMounted } from 'vue'

// Represents the letters
class LogoLetter {
  constructor(public letter: string) {}
  classList = ['square']
  get classes() {
    return this.classList.join(' ')
  }
}

const letters = reactive([
  new LogoLetter('W'),
  new LogoLetter('O'),
  new LogoLetter('R'),
  new LogoLetter('D'),
  new LogoLetter('L'),
  new LogoLetter('E')
])

onMounted(() => {
  for (const [index, letter] of letters.entries()) {
    setTimeout(() => {
      letter.classList.push('square2')
      if (Math.random() > 0.03) {
        letter.classList.push('green')
      } else {
        letter.classList.push('yellow')
        setTimeout(() => {
          letter.classList.pop()
          letter.classList.push('green-switch')
        }, 1300)
      }
    }, index * 100)
  }
})

onBeforeUnmount(() => {
  for (const letter of letters) {
    letter.classList.pop()
  }
})
</script>

<style scoped>
div {
  perspective: 400px;
  display: flex;
  justify-content: center;
  align-items: center;
}

@media (max-width: 500px) {
  .square {
    width: 50px;
    height: 50px;
  }
}

@media (min-width: 500px) and (max-width: 800px) {
  .square {
    width: 70px;
    height: 70px;
  }
}
@media (min-width: 800px) {
  .square {
    width: 100px;
    height: 100px;
  }
}

.square {
  transform: rotateY(180deg);
  background-color: #333;
  border: 1px solid #333;
  color: #333;
  margin: 0px 0px;
  border-radius: 0px;
  opacity: 0.5;
  font-size: 2em;
}

.square2 {
  transform: rotateY(0deg);
  margin: 0px 3px;
  color: white;
  border-radius: 15px;
  opacity: 1;
  transition: transform 1s ease-out, margin 0.5s ease-out, color 1s ease-out,
    border-radius 1s linear, opacity 1s linear, background-color 2s ease-out;
}

.green {
  background-color: green;
}

.yellow {
  background-color: yellow;
}

.green-switch {
  background-color: green;
  transition: background-color 0.2s ease-in-out;
  animation: pulse 0.4s ease-in-out;
}

@keyframes pulse {
  0% {
    transform: scale(1);
  }

  50% {
    transform: scale(0.95);
  }
  100% {
    transform: scale(1);
  }
}
</style>
