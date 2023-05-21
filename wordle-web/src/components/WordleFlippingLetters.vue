<template>
  <div>
    <div class="square num1" style="animation-delay: 0s">W</div>
    <div class="square num2" style="animation-delay: 0.1s">O</div>
    <div class="square num3" style="animation-delay: 0.2s">R</div>
    <div class="square num4" style="animation-delay: 0.3s">D</div>
    <div class="square num5" style="animation-delay: 0.4s">L</div>
    <div class="square num6" style="animation-delay: 0.5s">E</div>
  </div>
</template>

<script lang="ts" setup>
import { onBeforeUnmount } from 'vue'
import { onMounted } from 'vue'

onMounted(() => {
  for (let i = 1; i <= 6; i++) {
    setTimeout(() => {
      document.querySelector(`.num${i}`)!.classList.add('square2')
    }, i * 100)
  }

  console.log('mounted')
})

onBeforeUnmount(() => {
  for (let i = 1; i <= 6; i++) {
    document.querySelector(`.num${i}`)!.classList.remove('square2')
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
}

.square2 {
  background-color: green;
  transform: rotateY(0deg);
  border: 1px solid darkgreen;
  margin: 0px 3px;
  color: white;
  border-radius: 5px;
  opacity: 1;
  transition: background-color 2s ease-out, transform 1s ease-out, boarder 1s ease-out,
    margin 0.5s ease-out, color 1s ease-out, border-radius 2s linear, opacity 1s linear;
}
</style>
