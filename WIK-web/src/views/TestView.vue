<template>
  <v-col class="px-16 py-10 my-10" align="center">
    <v-container id="element" class="px-4 py-10 my-10" style="max-width: 1000px">
      <iframe id="player" width="420" height="315"
      src="https://www.youtube.com/embed/ko-6nHuBf8g?start=12&autoplay=1&enablejsapi=1">
      </iframe>
      <!--testing to try and get any to work-->
      <!-- <video-embed src="https://www.youtube.com/watch?v=s4ObxcdXoFE"></video-embed>
      <video-embed src="https://vimeo.com/370293725"></video-embed>
      <video-embed src="https://dai.ly/x7n7y06"></video-embed>
      <video-embed src="https://coub.com/embed/22eztb"></video-embed> -->
      <!-- 
        Actual WIK clips (shockingly small amount)
        https://twitter.com/EVO/status/1419024349692973061
        https://www.youtube.com/watch?v=DEGjCWxMnm4
        https://www.youtube.com/watch?v=ko-6nHuBf8g
        https://www.youtube.com/watch?v=ti3NGlVO7Bs
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

  function myTimer() {
  timer.value = timer.value + 1
}
function guessSide(side: number) {
  sideGuess = side
  //enable submit button
}
function submit() {
  var video = document.querySelector("iframe")
  video?.contentWindow?.postMessage( '{"event":"command", "func":"pauseVideo", "args":""}', '*');
  console.log("click")
  // if betValue > points
  // betValue = points
  // easiest way i can think of to get around """cheating"""
  // if guessSide == correctSide
  // points += betValue
  // else
  // points -= betValue
}
</script>
