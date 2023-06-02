<template>
  <v-container
    ><v-card
      ><v-card-title>Notes:</v-card-title
      ><v-list v-for="note in notes" :key="note.id"
        ><v-list-item :to="'/note-editor/' + note.id">{{ note.title }}</v-list-item></v-list
      ></v-card
    ></v-container
  ><v-btn to="/note-editor">Select</v-btn>
</template>

<script setup lang="ts">
import Axios from 'axios'
import { ref } from 'vue'

const notes = ref<INote[]>([])

export interface INote {
  id?: number
  title: string
  content: string
  date: string
}

Axios.get('/Note/Get').then((result) => {
  notes.value = result.data as INote[]
})
</script>
