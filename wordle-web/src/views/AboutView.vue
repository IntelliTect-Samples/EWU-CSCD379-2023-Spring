<template>
  <v-container>
    <v-card class="mx-auto" max-width="600">
      <v-card-title>About</v-card-title>
      <v-card-text>
        This is a class project for the Web Development course. Our goal is to create a web
        application using Vue.js and Vuetify that allows users to play the game Wordle. We're
        fortunate to have Meg as our instructor. She's a skilled web developer and an excellent
        teacher who is passionate about helping us learn and grow in our skills.
      </v-card-text>
      <v-card-actions>
        <v-btn variant="outlined" prepend-icon="mdi-keyboard-backspace" @click="$router.go(-1)"
          >Back</v-btn
        >
      </v-card-actions>
    </v-card>
  </v-container>
</template>
