<template>
  <v-sheet>
    <v-card>
      <v-card-title>Leader Board</v-card-title>
      <v-progress-linear 
        v-model="progress[0]"
        color="amber"
        height="25"
      ><strong>First place: {{ num1.Name }} Number of Games: {{ num1.GameCount }} Average Guesses: {{ num1.AverageGuesses }} Average Time: {{ num1.AverageSecondsPerGame }} </strong> 
      </v-progress-linear>
      <v-progress-linear 
        v-model="progress[1]"
        color="#AFAFAF"
        height="25"
      ><strong>Second place: {{ num2.Name }} Number of Games: {{ num2.GameCount }} Average Guesses: {{ num2.AverageGuesses }} Average Time: {{ num2.AverageSecondsPerGame }}</strong> 
      </v-progress-linear>
      <v-progress-linear 
        v-model="progress[2]"
        color="#CD7F32"
        height="25"
      ><strong>Third place: {{ num3.Name }} Number of Games: {{ num3.GameCount }} Average Guesses: {{ num3.AverageGuesses }} Average Time: {{ num3.AverageSecondsPerGame }}</strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[3]"
        color="#757575"
        height="25"
      ><strong>Fourth place: {{ num4.Name }} Number of Games: {{ num4.GameCount }} Average Guesses: {{ num4.AverageGuesses }} Average Time: {{ num4.AverageSecondsPerGame }}</strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[4]"
        color="#757575"
        height="25"
      ><strong>Fifth place: {{ num5.Name }} Number of Games: {{ num5.GameCount }} Average Guesses: {{ num5.AverageGuesses }} Average Time: {{ num5.AverageSecondsPerGame }}</strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[5]"
        color="#757575"
        height="25"
      ><strong>Sixth place: {{ num6.Name }} Number of Games: {{ num6.GameCount }} Average Guesses: {{ num6.AverageGuesses }} Average Time: {{ num6.AverageSecondsPerGame }}</strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[6]"
        color="#757575"
        height="25"
      ><strong>Seventh place: {{ num7.Name }} Number of Games: {{ num7.GameCount }} Average Guesses: {{ num7.AverageGuesses }} Average Time: {{ num7.AverageSecondsPerGame }}</strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[7]"
        color="#757575"
        height="25"
      ><strong>Eighth place: {{ num8.Name }} Number of Games: {{ num8.GameCount }} Average Guesses: {{ num8.AverageGuesses }} Average Time: {{ num8.AverageSecondsPerGame }}</strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[8]"
        color="#757575"
        height="25"
      ><strong>Ninth place: {{ num9.Name }} Number of Games: {{ num9.GameCount }} Average Guesses: {{ num9.AverageGuesses }} Average Time: {{ num9.AverageSecondsPerGame }}</strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[9]"
        color="#757575"
        height="25"
      ><strong>Tenth place: {{ num10.Name }} Number of Games: {{ num10.GameCount }} Average Guesses: {{ num10.AverageGuesses }} Average Time: {{ num10.AverageSecondsPerGame }}</strong> 
    </v-progress-linear>
      <template v-for="i in 17" :key="i.id">
        <v-progress-linear 
          v-model="progress[i+3]"
          color="#757575"
          height="25"
        ></v-progress-linear> 
      </template>
      <v-btn @click="$router.back()">Back</v-btn>
    </v-card>
  </v-sheet>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import Axios from 'axios'

const progress = ref([100,80,60,40,20,18,16,14,18,10])

const overlay = ref(true)

var num1: any
var num2: any
var num3: any
var num4: any
var num5: any
var num6: any
var num7: any
var num8: any
var num9: any
var num10: any

Axios.get('topTen')
  .then((response) => {
    var topTen = response.data;
    num1 = topTen[0]
    num2 = topTen[1]
    num3 = topTen[2]
    num4 = topTen[3]
    num5 = topTen[4]
    num6 = topTen[5]
    num7 = topTen[6]
    num8 = topTen[7]
    num9 = topTen[8]
    num10 = topTen[9]
    setTimeout(() => {
      overlay.value = false
    }, 502)
  })
  .catch((error) => {
    console.log(error)
  })



</script>

<style scoped>
 .v-progress-linear {
  border-radius: 8px;
  width: 99%;
  margin-bottom: 10px;
}
</style>
```



