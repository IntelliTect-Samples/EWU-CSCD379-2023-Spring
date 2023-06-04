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

              <v-btn color="warning" class="mt-4" block @click="removeAndRefresh">
                Remove Word
              </v-btn>
            </div>
          </v-form>
        </v-sheet>
      </v-dialog>
    </v-btn>
  </div>
</template>

<script lang="ts">
import { defineEmits, ref } from 'vue'
import Axios from 'axios'

export default {
  emits: ['refreshDictionary'],
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
    removeWord(): Promise<string> {
      return Axios.get(`/Word/DropWord?word=${this.input}`)
        .then((response) => {
          console.log('Did Word Successfully Get Removed: ' + response.data)
          return response.data
        })
        .catch(() => {
          console.log('Axios Error :(')
          return 'false'
        })
    },
    removeAndRefresh() {
      this.removeWord().then((isRemoved: string) => {
        if (isRemoved === 'true') {
          this.$emit('refreshDictionary')
        }
      })
    },
    addWord() {
      Axios.get(`/Word/AddWord?word=${this.input}`).then((response) => {
        console.log(response.data)
      })
    },
    flipIsCommon() {
      Axios.get(`/Word/FlipIsCommon?word=${this.input}`).then((response) => {
        console.log(response.data)
      })
    }
  }
}
</script>
