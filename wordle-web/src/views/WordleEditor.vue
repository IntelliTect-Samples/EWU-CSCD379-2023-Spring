<template>
    <v-container class="d-flex justify-center align-center">
      <v-card  style="width: 75%;">
        <div class="bg-primary text-h5 pa-3 text-center">Search Words</div>
        <v-text-field
            label="Wordle"
            type="text"
            v-model="value"
            @input="search"
        >
        </v-text-field>
        <v-card-text>
          <div v-for="(word, index) in words" :key="index" class="border my-3">
            <v-card-text class="d-flex flex-column">
              <v-row dense>
                <v-col cols="3">{{ word.text }}</v-col>
                <v-col cols="3">Common Word:</v-col>
                <v-col v-if="!signInService.isSignedIn" cols="3">{{ word.isCommon }}</v-col>
                <v-col v-else col="3">
                    <v-btn>{{ word.isCommon }}</v-btn>
                </v-col>
                <v-col v-if="signInService.token.masterOfTheUniverse" cols="3">
                    <v-btn>Delete</v-btn>
                </v-col>
              </v-row>
            </v-card-text>
          </div>
        </v-card-text>
      </v-card>
    </v-container>
  </template>
  
  <script lang="ts" setup>
  import Axios from 'axios'
  import { inject, ref } from 'vue'
  import type { WordDto } from '@/scripts/wordDto'
  import { Services } from '@/scripts/services'
  import type { SignInService } from '@/scripts/signInService'
  
  const signInService = inject(Services.SignInService) as SignInService
  const words = ref<WordDto[]>([])
  const value = ref('')

  async function search(){
    console.log(value.value)
    let apiPath = `word/paginatedWords?start=${value.value}`
    Axios.get(apiPath).then((result) => {
        console.log(result.data)
        words.value = result.data as WordDto[]
    })
  }
  </script>
  