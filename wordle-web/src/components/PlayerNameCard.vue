<template>
    <div class="text-center">
      <v-btn
        color="primary"
      >
        Open Dialog
  
        <v-dialog
          v-model="dialog"
          activator="parent"
          width="auto"
        >
          <v-card
          title="Please enter Player name:"
          subtitle="If no name is enter will play as Guest:"
          >
          <v-text-field
          class="ps-5 pe-5 pt-5"
            label="Player Name:"
            variant="outlined"
            v-model="props.wordGame.currentPlayer"
          ></v-text-field>

            <v-card-actions class="justify-center">
              <v-btn variant="outlined" @click="dialog = !dialog">Close Dialog</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-btn>
    </div>
  </template>

<script setup lang="ts">
import type { WordleGame } from '@/scripts/wordleGame';
import { ref } from 'vue';  

const props = defineProps<{
  wordGame: WordleGame
}>()

var dialog = ref(true);
  


</script>