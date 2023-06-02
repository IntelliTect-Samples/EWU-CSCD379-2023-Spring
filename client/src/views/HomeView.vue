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
            <v-textarea
              @input="updateNote($event.target.value)"
              variant="outlined"
              style="display: flex; flex-direction: column; flex-grow: 1; width: 500px"
            ></v-textarea>
            <div style="display: flex; justify-content: right">
              <v-btn>Save</v-btn>
            </div>
          </div>
        </v-card>
        <v-layout>
          <v-navigation-drawer expand-on-hover rail>
            <v-list>
              <v-list-item
                prepend-avatar="https://randomuser.me/api/portraits/women/85.jpg"
                title="Sandra Adams"
                subtitle="sandra_a88@gmailcom"
              ></v-list-item>
            </v-list>

            <v-divider></v-divider>

            <v-list density="compact" nav>
              <v-list-item prepend-icon="mdi-folder" title="My Files" value="myfiles"></v-list-item>
              <v-list-item
                prepend-icon="mdi-account-multiple"
                title="Shared with me"
                value="shared"
              ></v-list-item>
              <v-list-item prepend-icon="mdi-star" title="Starred" value="starred"></v-list-item>
            </v-list>
          </v-navigation-drawer>
        </v-layout>
      </v-col> </v-row
  ></v-container>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const notes = ref('')

const updateNote = (text: any) => {
  console.log(text)
  notes.value = text
}
</script>
