<template>
  <v-col class="px-16 py-10 my-10" align="center">
    <v-row>
      <v-col> Clip ID: {{ clipId }} </v-col>
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
        <v-btn @click="guessSide(-1)" class="my-8">NO It Won't Kill</v-btn>
        <v-col>
          <v-text-field class="px-8"></v-text-field>
        </v-col>
        <v-btn @click="guessSide(1)" class="my-8">YES It Will Kill</v-btn>
      </v-row>

      <v-row class="center px-16" style="max-width: 300px">
        <v-btn @click="submit">Test test test test</v-btn>
      </v-row>
      <v-row class="center px-16" style="max-width: 300px">
        <v-btn id="nextButton" v-if="showNext" @click="nextClip">Test test test test</v-btn>
      </v-row>

      <v-text-field label="Example"></v-text-field>
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
let points = 100
let tracker = setInterval(myTimer, 1000)
let clipId = ''
let clipUrl = ''
let clipStart = ''
let clipEnd = ''
let willItKill = ''
let clip = ref(clipUrl)
let videoId = '_nEOGOC9FPk'
let videoURL =
  'https://www.youtube.com/embed/_nEOGOC9FPk?end=15&controls=0&rel=0&autoplay=1&enablejsapi=1'
let showNext = false

var nextBtn = document.getElementById('nextButton')

onMounted(async () => {
  Axios.get('/Clip')
    .then((response) => {
      console.log(response.data)
      getClipInfo(response.data)
    })
    .catch((error) => {
      console.log(error.data)
    })
})

function myTimer() {
  timer.value = timer.value + 1
}
function guessSide(side: number) {
  console.log(side)
  sideGuess = side
  //enable submit button
}
function submit() {
  var video = document.querySelector('iframe')

  //set start time to current end time
  //remove end time
  //disable all buttons
  video?.contentWindow?.postMessage('{"event":"command", "func":"playVideo", "args":""}', '*')

  // if betValue > points
  // betValue = points
  // easiest way i can think of to get around """cheating"""
  // if guessSide == correctSide
  // points += betValue
  // else
  // points -= betValue
  // if points <= 0, points = 100
}

function getClipInfo(response: string) {
  var data = response.split(',')
  clipId = data[0]
  clipUrl = data[1]
  clipStart = data[2]
  clipEnd = data[3]
  willItKill = data[4]

  var clipParts = clipUrl.split('/watch?v=')
  clipUrl =
    clipParts[0] +
    '/embed/' +
    clipParts[1] +
    '?controls=0&rel=0&autoplay=1&enablejsapi=1&start=' +
    clipStart
  if (clipEnd !== '0') {
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
function nextClip() {}
</script>
