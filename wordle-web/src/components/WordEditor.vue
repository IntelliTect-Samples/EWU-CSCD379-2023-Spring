<template>
  <div class="text-center">
    <v-btn color="primary">
      Edit Dictionary

      <v-dialog v-model="dialog" activator="parent" width="auto">
        <v-card>
          <v-card-text> Word Editor </v-card-text>
          <v-card-actions>
            <v-btn color="primary" block @click="dialog = false">Close Dialog</v-btn>
          </v-card-actions>
        </v-card>
        <v-sheet width="300" class="mx-auto">
          <v-form ref="form">
            <v-text-field
              v-model="input"
              :counter="10"
              :rules="wordRules"
              label="Name"
              required
            ></v-text-field>

            <div class="d-flex flex-column">
              <v-btn color="success" class="mt-4" block @click="addWord"> Add </v-btn>

              <v-btn color="error" class="mt-4" block @click="flipIsCommon">
                Flip Is Common Value
              </v-btn>

              <v-btn color="warning" class="mt-4" block @click="removeWord"> Remove Word </v-btn>
            </div>
          </v-form>
        </v-sheet>
      </v-dialog>
    </v-btn>
  </div>
</template>

<script lang="ts">
import { ref } from 'vue'
import Axios from 'axios'

export default {
  data() {
    return {
      dialog: false,
      input: '',
      valid: true,
      wordRules: [
        (v: string) => !!v || 'Word is required',
        (v: string) => !/[^\p{L}]/u.test(v) || 'Word must only contain letters',
        (v: string) => (v && v.length === 5) || 'Word must be 5 characters'
      ]
    }
  },
  methods: {
    validate() {
      return this.input.length === 5
    },
    removeWord() {
      // This will have to make the Axios request for removing a word
      Axios.get(`/Word/RemoveWord?word=${this.input}`).then((response) => {
        console.log(response.data)
      })
    },
    addWord() {
      // Axios request for adding a word
      Axios.get(`/Word/AddWord?word=${this.input}`).then((response) => {
        console.log(response.data)
      })
    },
    flipIsCommon() {
      // Axios request for flipping if a word is common
      Axios.get(`/Word/FlipIsCommon?word=${this.input}`).then((response) => {
        console.log(response.data)
      })
    }
  }
}
</script>
