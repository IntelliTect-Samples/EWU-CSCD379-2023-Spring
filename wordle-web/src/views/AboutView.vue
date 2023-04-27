<template>
  <v-sheet color="blue" height="170px" class="pt-10 my-5">
    <v-text-field>
      This project its sooper cool and I love exploring the tools that are avalibe to us. This is a
      great learning exprice but wish I had more time between assigments
    </v-text-field>
  </v-sheet>

  <v-sheet color="green" height="170px" class="text-center">
    <v-text-field>
      Meg is so great, always willing to help and is so nice and understanding in class.
    </v-text-field>
  </v-sheet>

  <v-text-field> USE HAMBURGER MENU TO GO BACK </v-text-field>

  <v-btn color="purple" variant="outlined" class="nav-btn" @click="$router.push('/')">
    Back to Home
  </v-btn>

  <v-btn color="purple" variant="outlined" class="nav-btn" @click="$router.push('/wordle')">
    Back to Game
  </v-btn>

  <!-- <v-row no-gutters>
    <v-col v-for="i in 10" :key="i" cols="12" sm="6" md="4" lg="3">
      <v-card class="ma-1">
        <v-card-title> {{ i }} </v-card-title>
      </v-card>
    </v-col>
  </v-row> -->
</template>

<!-- <style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style> -->

<!-- ----------------------------the script has broken code but needed for inclass stuff --------KEEP-------------------- -->

<!-- <script setup lang="tx">
import Axios from "axios"

Axios.get("https://localhost:7255/WeatherForecast")
  .then((res) => {
    console.log(res)
  })
  .catch((err) => {
    console.log(err)
  })
</script> -->

<!-- ----------------------------the script has broken code but needed for inclass stuff --------KEEP-------------------- -->
