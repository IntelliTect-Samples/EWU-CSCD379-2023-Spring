<template>
  <div style="display: flex; justify-content: center">
    <v-card style="width: 75%"
      ><v-card-title>INSTRUCTIONS </v-card-title
      ><v-card-text
        >This is Will it Kill, a site based around simulating the online game. These are the
        instructions for playing the game.
        <div style="margin: 15px">
          <v-card-text style="padding: 5px"
            >Once you begin playing (if you aren't logged in you'll be prompted), a screenshot of
            the initial hit will be shown.
          </v-card-text>
          <v-card-text style="padding: 5px">
            You can either manually input some amount of points already on your account and attempt
            to double it, or press the "All-in" button to automatically put all your points
            in.</v-card-text
          >
          <v-card-text style="padding: 5px">
            Once you choose a betting amount, an outcome, and submit, the clip will play out and you
            will have points taken away or given to you.</v-card-text
          >
          <v-card-text style="padding: 5px">
            The leaderboard will remember your all time max and automatically update each time you
            play.
          </v-card-text>
        </div>

        <div align="center">
          Below is an clip from the show - mild language warning.
          <iframe
            style="justify-content: center; display: flex"
            id="player"
            width="60%"
            height="320"
            src="https://www.youtube.com/embed/2-g7H4BHfy4?start=1301&end=&1350autoplay=1"
            allowfullscreen="true"
          />
        </div>
      </v-card-text>
    </v-card>
  </div>
</template>

<script setup lang="ts"></script>
