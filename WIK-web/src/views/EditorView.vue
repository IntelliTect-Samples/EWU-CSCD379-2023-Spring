<template>
  <v-container>
    <h1 class="text-center">WORD EDITOR PAGE</h1>
    <LoginPopout />
  </v-container>

  <v-container>
    <h2>Add Word</h2>
    <v-text-field v-model="add" label="Add Word" variant="outlined"></v-text-field>
    <v-list scrollable height="300px" width="100px">
      <v-list-item
        v-for="(item, i) in validWords(add)"
        :key="i"
        :value="item"
        active-color="primary"
        variant="plain"
        :title="item"
        @click="fillAdd(item)"
      />
    </v-list>

    <v-checkbox v-model="checkbox1" :label="'Is A Common Word?'"></v-checkbox>
    <v-btn @click="addWord"> Add Word </v-btn>
    <h3>{{ addError }}</h3>
  </v-container>

  <v-container>
    <h2>Update IsCommon</h2>
    <v-text-field v-model="update" label="Update Word" variant="outlined"></v-text-field>
    <v-list scrollable height="300px" width="100px">
      <v-list-item
        v-for="(item, i) in validWords(update)"
        :key="i"
        :value="item"
        active-color="primary"
        variant="plain"
        :title="item"
        @click="fillUpdate(item)"
      />
    </v-list>

    <v-checkbox v-model="checkbox2" :label="'Is A Common Word?'"></v-checkbox>
    <v-btn @click="updateWord"> Update Word </v-btn>
    <h3>{{ updateError }}</h3>
  </v-container>
  <v-container>
    <h2>Delete Word</h2>
    <v-text-field v-model="remove" label="Delete Word" variant="outlined"></v-text-field>
    <v-list scrollable height="300px" width="100px">
      <v-list-item
        v-for="(item, i) in validWords(remove)"
        :key="i"
        :value="item"
        active-color="primary"
        variant="plain"
        :title="item"
        @click="fillDelete(item)"
      />
    </v-list>
    <v-btn @click="removeWord"> Delete Word </v-btn>
    <h3>{{ deleteError }}</h3>
  </v-container>
</template>

<script setup lang="ts">
import { EditorService } from '@/scripts/editorService'
import LoginPopout from '@/components/LoginPopout.vue'
import Axios from 'axios'
import { onMounted, ref } from 'vue'

const allWords = ref(['', ''])
const allIsCommon = ref(['', ''])

const addError = ref('')
const add = ref('')
const checkbox1 = ref(false)
const updateError = ref('')
const update = ref('')
const checkbox2 = ref(false)
const deleteError = ref('')
const remove = ref('')

onMounted(async () => {
  localStorage.clear()
  console.log(localStorage.getItem('age'))
  allWords.value = await EditorService.getAllWords()
  allIsCommon.value = await EditorService.getAllIsCommon()
})

async function addWord() {
  let newWord = add.value.toLocaleLowerCase()
  if (localStorage.getItem('user') === null) {
    addError.value = 'You need to be logged in.'
  } else if (localStorage.getItem('age') == 'under') {
    addError.value = 'You are not old enough. Use a different account.'
  } else if (newWord.length != 5) {
    addError.value = 'Word length must be 5 characters.'
  } else if (allWords.value.includes(newWord)) {
    addError.value = 'Word already exists.'
  } else {
    Axios.post('/Word/AddWord?word=' + newWord + '&isCommon=' + checkbox1.value)
      .then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
    addError.value = 'New Word Added: ' + newWord + ', Is Common: ' + checkbox1.value
    allWords.value = await EditorService.getAllWords()
    allIsCommon.value = await EditorService.getAllIsCommon()
  }
}

async function updateWord() {
  let newWord = update.value.toLocaleLowerCase()
  if (localStorage.getItem('user') === null) {
    updateError.value = 'You need to be logged in.'
  } else if (newWord.length != 5) {
    updateError.value = 'Word length must be 5 characters.'
  } else if (!allWords.value.includes(newWord)) {
    updateError.value = 'Word does not exist.'
  } else {
    Axios.post('/Word/UpdateWord?word=' + newWord + '&isCommon=' + checkbox2.value)
      .then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
    updateError.value = 'Updated Word: ' + newWord + ', Is Common: ' + checkbox2.value
    allWords.value = await EditorService.getAllWords()
    allIsCommon.value = await EditorService.getAllIsCommon()
  }
}

async function removeWord() {
  let newWord = remove.value.toLocaleLowerCase()
  if (localStorage.getItem('user') === null) {
    addError.value = 'You need to be logged in.'
  } else if (localStorage.getItem('age') == 'under') {
    addError.value = 'You are not old enough. Use a different account.'
  } else if (newWord.length != 5) {
    deleteError.value = 'Word length must be 5 characters.'
  } else if (!allWords.value.includes(newWord)) {
    deleteError.value = 'Word does not exist.'
  } else {
    Axios.post('/Word/DeleteWord?word=' + newWord)
      .then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
    deleteError.value = 'Removed Word: ' + newWord
    allWords.value = await EditorService.getAllWords()
    allIsCommon.value = await EditorService.getAllIsCommon()
  }
}

function validWords(word: string): string[] {
  if (word !== '') {
    return allWords.value.filter((element) => {
      return element.substring(0, word.length) == word
    })
  } else {
    return new Array<string>()
  }
}
function fillAdd(word: string) {
  add.value = word
}
function fillUpdate(word: string) {
  update.value = word
}
function fillDelete(word: string) {
  remove.value = word
}
</script>
