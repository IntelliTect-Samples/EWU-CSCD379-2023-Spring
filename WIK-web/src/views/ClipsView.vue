<template>
    <v-container>
      <h1 class="text-center">Submit New Clips</h1>
      <LoginPopout />
    </v-container>
  
    <v-container>
      <h2>Submit Clip</h2>
      <v-text-field v-model="url" label="Clip Url (Youtube Only. Ex: https://www.youtube.com/watch?v=z97qLNXeAMQ)" variant="outlined"></v-text-field>
      <v-text-field v-model="startTime" label="Start Time (In Seconds)" variant="outlined"></v-text-field>
      <v-text-field v-model="endTime" label="End Time (In Seconds. 0 If Until End Of Video)" variant="outlined"></v-text-field>
      <v-checkbox v-model="checkbox1" :label="'Will It Kill?'"></v-checkbox>
      <v-btn @click="addWord"> Submit Clip </v-btn>
      <h3>{{ addError }}</h3>
    </v-container>
  
    
  </template>
  
  <script setup lang="ts">
  import LoginPopout from '@/components/LoginPopout.vue'
  import Axios from 'axios'
  import { ref } from 'vue'
  
  
  const addError = ref('')
  const url = ref('')
  const startTime = ref('')
  const endTime = ref('')
  const checkbox1 = ref(false)
  
  
  async function addWord() {
    let newWord = url.value.toLocaleLowerCase()
    if (localStorage.getItem('username') === null) {
      addError.value = 'You need to be logged in.'
    } else if (!newWord.includes('https://www.youtube.com/watch?v=')) {
      addError.value = 'Incorrect format. Must contain \'https://www.youtube.com/watch?v=\' '
    } else {
      Axios.post('/Clip?url='+ url.value +'&kills='+checkbox1.value+'&startTime='+startTime.value+'&endTime='+endTime.value)
        .then(function (response) {
          console.log(response)
        })
        .catch(function (error) {
          console.log(error)
        })
      addError.value = 'Clip Added!'
    }
  }
  </script>
  