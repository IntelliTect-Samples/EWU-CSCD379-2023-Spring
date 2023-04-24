<template>
  <main>
    <v-card class="mx-auto elevation-3">
      <v-card-title>About</v-card-title>
      <v-card-text>
        Welcome to our Wordle game app! This project was created for a class assignment and
        showcases our skills in Vue.js and Veutify. I hope you enjoy playing the game and exploring
        the different features, including the ability to customize the color scheme and view
        available words. Thank you for visiting and have fun! Meg is a wonderful person!
      </v-card-text>
      <v-card-actions>
        <v-btn color="teal" variant="tonal" @click="$router.go(-1)">Back</v-btn>
      </v-card-actions>
    </v-card>
  </main>
</template>
