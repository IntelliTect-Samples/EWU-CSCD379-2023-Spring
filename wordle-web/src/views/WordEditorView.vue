<template>
  <v-container
    ><v-row justify="center">
      <v-col cols="12" style="display: flex; justify-content: center">
        <div style="display: flex; align-items: center; justify-content: center; flex-wrap: wrap">
          <h3 class="text-h3">Word Editor</h3>
        </div>
      </v-col>
      <v-col cols="12" style="display: flex; justify-content: center">
        <v-card style="padding: 10px; display: flex; flex-direction: column; width: 500px">
          <DeleteWord />
          <AddWord />
          <CommonWord />
          <WordList />
        </v-card>
      </v-col> </v-row
  ></v-container>
</template>

<script setup lang="ts">
import DeleteWord from '../components/DeleteWord.vue'
import AddWord from '../components/AddWord.vue'
import CommonWord from '../components/CommonWord.vue'
import WordList from '../components/WordList.vue'
</script>
