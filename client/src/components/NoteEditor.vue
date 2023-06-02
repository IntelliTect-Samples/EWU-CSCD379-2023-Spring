<template>
  <v-container
    ><v-row justify="center">
      <v-col cols="12" style="display: flex; justify-content: center">
        <div style="display: flex; align-items: center; justify-content: center; flex-wrap: wrap">
          <h1 class="text-h1">Noted</h1>
        </div>
      </v-col>
      <v-col cols="12" style="display: flex; justify-content: center">
        <v-card
          style="
            padding: 10px;
            display: flex;
            flex-direction: row;
            height: 800px;
            width: fit-content;
          "
        >
          <div>
            <v-text-field
              @input="editNoteTitle($event.target.value)"
              variant="underlined"
            ></v-text-field>
            <v-textarea
              @input="editNoteContent($event.target.value)"
              variant="outlined"
              style="display: flex; flex-direction: column; flex-grow: 1; width: 500px"
            ></v-textarea>
            <div style="display: flex; justify-content: right">
              <v-btn @click="handleSave()">Save</v-btn>
            </div>
          </div>
        </v-card>
      </v-col>
    </v-row></v-container
  >
</template>

<script setup lang="ts">
import type { INote } from '@/views/HomeView.vue'
import Axios from 'axios'
import { ref } from 'vue'

const currentNote = ref<INote>({ title: '', content: '', date: '' })

const editNoteTitle = (text: string) => {
  currentNote.value.title = text
}

const editNoteContent = (text: string) => {
  currentNote.value.content = text
}

const createNote = () => {
  console.log(currentNote.value)
  Axios.post('/Note/Add', currentNote.value)
}

const updateNote = () => {
  Axios.put('/Note/Update', currentNote.value)
}

const handleSave = () => {
  currentNote.value.id ? updateNote() : createNote()
}
</script>
