<template>
  <v-col class="px-16 py-10 my-10" align="center">
    <v-row>
      <v-col> Clip name </v-col>
      <v-col> Points: {{ points }} </v-col>
    </v-row>
    <v-container id="element" class="px-4 py-10 my-10" style="max-width: 1000px">
      <iframe
        id="player"
        width="100%"
        height="500"
        src=''
      >
      </iframe>
      <!-- 
        Actual WIK clips 
        https://www.youtube.com/watch?v=_nEOGOC9FPk // kill
        https://www.youtube.com/watch?v=5G2A7WKsCRg // doesnt
        https://www.youtube.com/watch?v=7XjUpd99s18 // faust wins if we wanna do WHO will it kill
      -->

      <v-row class="px-16" style="max-width: 600px">
        <v-btn @click="guessSide(-1)" class="my-8">leftist</v-btn>
        <v-col>
          <h3>{{ points }}</h3>
          <v-text-field class="px-8"></v-text-field>
          <v-text-field label="Example"></v-text-field>
        </v-col>
        <v-btn @click="guessSide(1)" class="my-8">rightist</v-btn>
      </v-row>
      <v-row class="center px-16" style="max-width: 300px">
        <v-btn @click="submit">Test test test test</v-btn>
      </v-row>
    </v-container>
  </v-col>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import { useRoute } from 'vue-router'
import Axios from 'axios'
import { WordsService } from '@/scripts/wordsService'

const titleRef = ref('')
const guess = ref('')
const game = reactive(new WordleGame())
const route = useRoute()
const timer = ref(0)
let sideGuess = 0
let points = ref(0)
let tracker = setInterval(myTimer, 1000)
let clipId = ''
let clipUrl = ''
let clipStart = ''
let clipEnd = ''
let willItKill = ''
let clip = ref(clipUrl)
onMounted(async () => {
  Axios.get('/Clip')
  .then((response) => {
    console.log(response.data)
    getClipInfo(response.data)
  })
  .catch((error) =>{
    console.log(error.data)
  })
  
  
})

function myTimer() {
  timer.value = timer.value + 1
}
function guessSide(side: number) {
  sideGuess = side
  //enable submit button
}
function submit() {
  var video = document.querySelector('iframe')
  video?.contentWindow?.postMessage('{"event":"command", "func":"pauseVideo", "args":""}', '*')
  console.log('click')
  // if betValue > points
  // betValue = points
  // easiest way i can think of to get around """cheating"""
  // if guessSide == correctSide
  // points += betValue
  // else
  // points -= betValue
}

function getClipInfo(response : string){
  var data = response.split(',')
  clipId = data[0]
  clipUrl = data[1]
  clipStart = data[2]
  clipEnd = data[3]
  willItKill = data[4]

  var clipParts = clipUrl.split('/watch?v=')
  clipUrl = clipParts[0] + '/embed/' + clipParts[1] + '?controls=0&rel=0&autoplay=1&enablejsapi=1&start=' + clipStart
  if(clipEnd !== '0'){
    clipUrl = clipUrl + '&end=' + clipEnd
  }

  console.log(clipId)
  console.log(clipUrl)
  console.log(clipStart)
  console.log(clipEnd)
  console.log(willItKill)
  var video = document.querySelector('iframe')
  video?.setAttribute('src', clipUrl)
}
</script>
