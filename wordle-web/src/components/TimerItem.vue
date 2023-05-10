<template>
    <div>
      <v-dialog v-model="GameStart" width="auto" persistent>
        <v-btn @click="startGame"> Start Game! </v-btn>
      </v-dialog>
      <v-chip v-if="timerVisible" variant="text">
        <h1>{{ minute }} : {{ timer }}</h1>
      </v-chip>
    </div>
  </template>
  
<script setup lang="ts">
  import { ref, watch} from 'vue'
  
  const GameStart = ref(true)
  const timerVisible = ref(false)
  const timer = ref(0)
  const minute = ref(0)
  let timerInterval: any
  
  watch (timer, (newVal) => {
    if (timer.value > 50) {
      timer.value = 0
      minute.value += 1
    }
  })
  
  
  function startGame() {
    GameStart.value = false
    timerVisible.value = true
    timer.value = 0
    timerInterval = setInterval(() => {
      timer.value += 1
    }, 1000)
  }
  </script>