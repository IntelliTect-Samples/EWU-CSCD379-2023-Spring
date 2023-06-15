<template>
  <v-col class="px-16 py-10 my-10" align="center">
    <v-row>
      <v-col id="clipIdText">Clip ID: {{ clipId }} </v-col>
      <v-col id="streakText">Streak: {{ streak }} </v-col>
    </v-row>
    <v-container id="element" class="px-4 py-10 my-10" style="max-width: 1000px">
      <iframe id="player" width="100%" height="500" src=""> </iframe>

      <v-row class="py-4 my-8" style="max-width: 600px">
        <v-btn v-show="!showNext" @click="submit(-1)" class="mx-4 px-16">NO It Won't Kill</v-btn>
        <v-btn v-show="!showNext" @click="submit(1)" class="mx-4 px-16">YES It Will Kill</v-btn>
        <h2 v-show="showNext">{{ result }}</h2>
      </v-row>

      <v-row class="center px-16 py-4" style="max-width: 300px">
        <v-btn id="nextButton" v-show="showNext" @click="nextClip">Next Next Next Next</v-btn>
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

const clipId = ref('')
const guess = ref('')
const game = reactive(new WordleGame())
const route = useRoute()
const timer = ref(0)
let showNext = ref(false)
let streak = ref(0)
let clipUrl = ''
let clipStart = ''
let clipEnd = ''
let willItKill = ''
let result = ref('')

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
}

function submit(side: number) {
  var video = document.querySelector('iframe')
  showNext.value = true
  video?.contentWindow?.postMessage('{"event":"command", "func":"playVideo", "args":""}', '*')

  if ((willItKill == 'True' && side > 0) || (willItKill == 'False' && side < 0)) {
    streak.value += 1
    console.log(streak)
  } else {
    streak.value = 0
  }

  ///User/UpdateUser?username=gamer&win=true
  //you can get the username with localStorage.getItem('username'')
}

let tracker = setInterval(myTimer, 1000)
function myTimer() {
  timer.value = timer.value + 1
}
</script>
