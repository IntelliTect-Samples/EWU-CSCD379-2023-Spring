<template>
    <v-dialog transition="dialog-bottom-transition" width="auto">
      <template v-slot:activator="{ props }">
        <v-btn v-bind="props" icon>
          <v-icon>mdi-help-circle-outline</v-icon>
        </v-btn>
      </template>
      <template v-slot:default="{ isActive }">
        <v-card>
          <v-toolbar>
            <v-toolbar-title>
              <span class="text-h6 bold">How To Play</span>
            </v-toolbar-title>
          </v-toolbar>
          <v-card-text>
            <div class="pa-5">
              <h3 style="font-weight: bolder;">Basic Rules</h3>
              <ul style="padding-left: 10%;">
                <li>Guess the word in 5 tries or less.</li>
                <li>Enter a 5 letter word and click the check button.</li>
              </ul>
              <br />
              <h3 style="font-weight: bolder;">Tips</h3>
              <ul style="padding-left: 10%;">
                <li>
                  The color of the tiles will change, giving you clues towards
                  the right answer.
                </li>
                <li>
                  Correct letters in the correct position will be marked
                  <span style="color: darkgreen; font-weight: bolder;">GREEN.</span>
                </li>
                <li>
                  Correct letters in the wrong position will be marked
                  <span style="color: darkgoldenrod; font-weight: bolder;">YELLOW.</span>
                </li>
                <li>
                  Incorrect letters will remain
                  <span style="color: dimgray; font-weight: bolder;">GREY.</span>
                </li>
              </ul>
            </div>
          </v-card-text>
          <v-card-actions class="justify-end">
            <v-btn
              variant="text"
              color="blue-darken-1"
              @click="isActive.value = false"
            >
              Close
            </v-btn>
          </v-card-actions>
        </v-card>
      </template>
    </v-dialog>
  </template>
  
  <script lang="ts">
  import { defineComponent } from "vue";
  
  export default defineComponent({});
  </script>
  