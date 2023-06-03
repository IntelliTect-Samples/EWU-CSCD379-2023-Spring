<template>
<div class="text-center">
    <v-container>
    <v-pagination 
    v-model="page" 
    :length="totalPages"
    :total-visible="6"
    ></v-pagination>
    <v-row>
        <v-col v-for="item in paginatedItems" :key="item" cols="2">
        <v-list-item @click="openDialog(item)">
            <v-list-item-title>{{ item }}</v-list-item-title>
        </v-list-item>
        </v-col>
    </v-row>
    </v-container>
    <v-pagination 
    v-model="page" 
    :length="totalPages"
    :total-visible="5"
    ></v-pagination>
    <v-row justify="center">
        <v-col cols = "2">
            <v-select 
            label="Items per page"
            v-model="perPage" 
            :items="[30, 60, 120, 240]"
            > </v-select>
        </v-col>
        <v-col cols = "2">
            <v-text-field 
            v-model="search" 
            label="Search for word"
            > </v-text-field>
        </v-col>
    </v-row>


    <v-dialog v-model="dialogVisible" max-width="500px">
        <v-card class="text-center">
          <v-card-title>{{selectedWord}}</v-card-title>
          <v-card-text>
            <v-btn color="primary" text @click="editWord">Edit</v-btn>
            <v-btn color="error" text @click="deleteWord">Delete</v-btn>
            <v-btn color="primary" text @click="dialogVisible = false">Close</v-btn>
          </v-card-text>
        </v-card>
    </v-dialog>

</div>
</template>
  
<script setup lang="ts">
import { ref, computed } from 'vue'
import { WordsService } from '../scripts/wordsService'
  
const page = ref(1)
const perPage = ref(60)
const countitem = ref(WordsService.getAllWords())
const search = ref('')
const selectedWord = ref('')
const dialogVisible = ref(false)

const totalPages = computed(() => Math.ceil(countitem.value.length / perPage.value))
const paginatedItems = computed(() => {
const startIndex = (page.value - 1) * perPage.value
const endIndex = startIndex + perPage.value
const filteredItems = countitem.value.filter(item => item.includes(search.value))
return filteredItems.slice(startIndex, endIndex)
})

function openDialog(item : string) {
    selectedWord.value = item
    dialogVisible.value = true
}

function editWord(word: string) {
    dialogVisible.value = false
}

function deleteWord(word: string) {
    dialogVisible.value = false
}

function addWord(word: string) {
    dialogVisible.value = false
}

  </script>