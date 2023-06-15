<template>
  <audio id="audioPlayer" autoplay>
    <source type="audio/mpeg" />
  </audio>
  <audio id="audioPlayer1" autoplay>
    <source type="audio/mpeg" />
  </audio>
  <audio id="audioPlayer2" autoplay>
    <source type="audio/mpeg" />
  </audio>
  <v-col class="px-16 py-5 my-5" align="center" style="max-height: 90%">
    <v-row>
      <v-col id="clipIdText">Clip ID: {{ clipId }} </v-col>
      <v-col id="streakText">Streak: {{ streak }} </v-col>
    </v-row>
    <v-container id="element" class="px-4 py-10 my-10" style="max-width: 1000px">
      <iframe id="player" width="100%" height="500" src=""> </iframe>

      <v-row class="py-4 my-4" style="max-width: 600px">
        <v-btn
          style="min-width: 150px; min-height: 100px"
          v-show="!showNext"
          @click="submit(-1)"
          class="mx-4 px-16"
          >NO - It Won't Kill</v-btn
        >
        <v-btn
          style="min-width: 150px; min-height: 100px"
          v-show="!showNext"
          @click="submit(1)"
          class="mx-4 px-16"
          >YES - It Will Kill</v-btn
        >
      </v-row>

      <v-row class="px-16 py-4 d-flex justify-center">
        <div>
          <h2 v-show="showNext">{{ result }}</h2>
          <br />
          <v-btn
            style="min-width: 200px; min-height: 125px"
            id="nextButton"
            v-show="showNext"
            @click="nextClip"
            >Next</v-btn
          >
        </div>
      </v-row>
    </v-container>
  </v-col>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import Axios from 'axios'
import goodSound from '@/assets/sound/good.mp3'
import failSound from '@/assets/sound/fail.mp3'

const clipId = ref('')
const timer = ref(0)
let showNext = ref(false)
let streak = ref(0)
let clipUrl = ''
let clipStart = ''
let clipEnd = ''
let willItKill = ''
let result = ref('')
let pastMid = true

onMounted(async () => {
  nextClip()
})

function nextClip() {
  Axios.get('/Clip')
    .then((response) => {
      console.log(response.data)
      getClipInfo(response.data)
      startGame()
    })
    .catch((error) => {
      console.log(error.data)
    })
  timer.value = 0
  showNext.value = false
}

function getClipInfo(response: string) {
  var data = response.split(',')
  clipId.value = data[0]
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
}

function startGame() {
  var video = document.querySelector('iframe')
  video?.setAttribute('src', clipUrl)
  showNext.value = false
  pastMid = false
  playVideo()
}

function submit(side: number) {
  var success = (willItKill == 'True' && side > 0) || (willItKill == 'False' && side < 0)
  var audioPlayer = document.getElementById('audioPlayer')

  playVideo()
  showNext.value = true
  pastMid = true

  if (success) {
    var res = "You're correct -"
    audioPlayer?.setAttribute('src', goodSound)

    if (side > 0) {
      res += " That's a Kill!"
    } else {
      res += ' No Kill here!'
    }

    result.value = res

    streak.value += 1
    console.log(streak)
  } else {
    result.value = 'Sorry, you guessed wrong.'
    qtimer.value = 0
    streak.value = 0
  }

  Axios.post('/User/UpdateUser?username=' + localStorage.getItem('username') + '&win=' + success)
  Axios.post('/Clip/UpdateClip?clipid=' + clipId.value + '&correct=' + success)
}
var qtimer = ref(3)
setInterval(qPingTimer, 250)
function qPingTimer() {
  if (qtimer.value > 3) {
  } else {
    qtimer.value += 1
    var audioPlayer
    if (qtimer.value == 0) {
      audioPlayer = document.getElementById('audioPlayer')
    } else if (qtimer.value == 1) {
      audioPlayer = document.getElementById('audioPlayer1')
    } else if (qtimer.value == 2) {
      audioPlayer = document.getElementById('audioPlayer2')
    }
    audioPlayer?.setAttribute('src', failSound)
  }
}

setInterval(myTimer, 1000)
function myTimer() {
  if (timer.value == 1) {
    playVideo()
  }
  if (timer.value > 2) {
    console.log(timer.value)
    pauseVideo()
    timer.value = 0
    pastMid = true
  }
  if (pastMid == false) {
    console.log(timer.value)
    playVideo()
    timer.value += 1
  }
}

function playVideo() {
  var video = document.querySelector('iframe')
  video?.contentWindow?.postMessage('{"event":"command", "func":"playVideo", "args":""}', '*')
}

function pauseVideo() {
  var video = document.querySelector('iframe')
  video?.contentWindow?.postMessage('{"event":"command", "func":"pauseVideo", "args":""}', '*')
}
</script>
