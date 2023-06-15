<template>
  <v-col class="px-16 py-10 my-10" align="center">
    <v-row>
      <v-col id="clipIdText">Clip ID: {{ clipId }} </v-col>
      <v-col id="pointText">Points: {{ points }} </v-col>
    </v-row>
    <v-container id="element" class="px-4 py-10 my-10" style="max-width: 1000px">
      <iframe id="player" width="100%" height="500" src=""> </iframe>

      <v-row class="px-16" style="max-width: 600px">
        <v-btn v-show="!showNext" @click="submit(-1)" class="my-8">NO It Won't Kill</v-btn>
        <v-col>
          <v-text-field class="px-8"></v-text-field>
        </v-col>
        <v-btn v-show="!showNext" @click="submit(1)" class="my-8">YES It Will Kill</v-btn>
      </v-row>

      <v-row class="center px-16" style="max-width: 300px">
        <v-btn id="nextButton" v-show="showNext" @click="nextClip">Next Next Next Next</v-btn>
      </v-row>

      <!--<v-text-field label="Example"></v-text-field>-->
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
let points = 100
let tracker = setInterval(myTimer, 1000)
let clipId = ''
let clipUrl = ''
let clipStart = ''
let clipEnd = ''
let willItKill = ''
let clip = ref(clipUrl)
let showNext = false

var nextBtn = document.getElementById('nextButton')

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
  console.log('next no show')
  showNext = false
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
}

function startGame() {
  var clipIdText = document.getElementById('clipIdText')
  var pointText = document.getElementById('pointText')
  var video = document.querySelector('iframe')

  clipIdText?.setAttribute('value', 'Clip ID: Success!')
  pointText?.setAttribute('value', 'Points: Success!')
  video?.setAttribute('src', clipUrl)

  console.log('start noshow')
  showNext = false
}

function myTimer() {
  timer.value = timer.value + 1
}
function submit(side: number) {
  var video = document.querySelector('iframe')
  //disable all buttons
  let betValue = points

  showNext = true
  console.log('submit show')
  console.log(showNext)
  video?.contentWindow?.postMessage('{"event":"command", "func":"playVideo", "args":""}', '*')

  if (betValue > points) {
    betValue = points
  }

  if ((willItKill == 'True' && side > 0) || (willItKill == 'False' && side < 0)) {
    points += betValue
  } else {
    points -= betValue
    if (points <= 0) {
      points = 100
    }
  }

  ///User/UpdateUser?username=gamer&win=true
  //you can get the username with localStorage.getItem('username'')
}
</script>
