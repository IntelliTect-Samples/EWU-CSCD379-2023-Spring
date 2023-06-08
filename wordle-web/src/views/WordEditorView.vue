<template>
  <div>
    <v-card>
      <v-card>
        <v-text-field label="search a word" v-model="searchString"></v-text-field>
      </v-card>

      <v-card>Word list</v-card>
      <v-list>
        <v-list-item v-for="word in paginatedWords" :key="word.wordId">
          <v-card>
            <v-list-item-content>
              <v-list-item-title>{{ word.text }}</v-list-item-title>
              <v-card>
                <v-list-item-subtitle>{{
                  word.isCommon ? 'common' : 'uncommon'
                }}</v-list-item-subtitle>
                <v-btn
                  ripple
                  @click="changeCommonFlag(word.wordId, !word.isCommon)"
                  :disabled="!permissions"
                  >Change Common</v-btn
                >
                <v-btn ripple @click="deleteWord(word.wordId)" :disabled="!permissions"
                  >Delete Word</v-btn
                >
              </v-card>
            </v-list-item-content>
          </v-card>
        </v-list-item>
      </v-list>
      <v-btn @click="addDialog = !addDialog">Add a word</v-btn>

      <v-pagination
        v-model="currentPage"
        :length="effectivePaginationLength"
        @input="handlePagination"
      ></v-pagination>
    </v-card>

    <v-dialog v-model="addDialog">
      <v-card>
        <v-card>
          <v-text-field v-model="newWord.text" label="word"></v-text-field>
        </v-card>
        <v-card>
          <v-checkbox v-model="newWord.isCommon" label="common"></v-checkbox>
        </v-card>
        <v-card>
          <v-btn @click="addWord">add</v-btn>
        </v-card>
      </v-card>
    </v-dialog>
  </div>
</template>

<script setup lang="ts">
import Axios from 'axios'
import { ref, onMounted, computed, watch } from 'vue'

interface Word {
  wordId: number
  text: string
  isCommon: boolean
  isUsed: boolean
}

const words = ref<Word[]>([])
const searchString = ref('')
const currentPage = ref(1)
const pageLength = 10
const wordTotal = ref(12972)
const addDialog = ref(false)
const deleteDialog = ref(false)
const newWord = ref<Word>({
  wordId: 0,
  text: '',
  isCommon: false,
  isUsed: true
})
const permissions = ref(false)

onMounted(() => {
  getWords(1)
  permissions.value = canCreateDelete()
})

watch(searchString, (newValue) => {
  currentPage.value = 1
  getWords(1)
})

const totalPages = computed(() => {
  return Math.ceil(wordTotal.value / pageLength)
})

const paginatedWords = computed(() => {
  const startIndex = (currentPage.value - 1) * pageLength
  const endIndex = startIndex + pageLength
  return words.value.slice(startIndex, endIndex)
})

const effectivePaginationLength = computed(() => {
  if (searchString.value.trim() === '') {
    return Math.ceil(wordTotal.value / pageLength)
  } else {
    const filteredWordsLength = words.value.filter((word) =>
      word.text.toLowerCase().includes(searchString.value.toLowerCase())
    ).length
    return Math.ceil(filteredWordsLength / pageLength)
  }
})

function getWords(pageNumber: number) {
  Axios.get('/Word/WordList', {
    params: {
      pageNumber: pageNumber,
      pageLength: pageLength,
      searchString: searchString.value
    }
  })
    .then((response) => {
      words.value = response.data
      console.log(response.data)
    })
    .catch((error) => {
      console.error(error)
    })
}

function addWord() {
  const existingWord = words.value.find(
    (word) => word.text.toLowerCase() === newWord.value.text.toLowerCase()
  )
  if (existingWord) {
    console.log('Word already exists!')
    return
  }
  wordTotal.value += 1
  Axios.post('/Word/AddWordFromBody', {
    text: newWord.value.text,
    isCommon: newWord.value.isCommon,
    isUsed: newWord.value.isUsed
  })
    .then((response) => {
      getWords(currentPage.value)
      console.log(response.data)
    })
    .catch((error) => {
      console.error(error)
    })
}

function deleteWord(wordId: number) {
  wordTotal.value -= 1
  Axios.get('/Word/DeleteWord', {
    params: {
      wordId: wordId
    }
  })
    .then((response) => {
      getWords(currentPage.value)
      console.log(response.data)
    })
    .catch((error) => {
      console.error(error)
    })
}

function handlePagination(page: number) {
  currentPage.value = page
  getWords(page)
}

function changeCommonFlag(wordId: number, value: boolean) {
  Axios.get('/Word/ChangeCommonFlag', {
    params: {
      wordId: wordId,
      value: value
    }
  })
    .then((response) => {
      getWords(currentPage.value)
      console.log(response.data)
    })
    .catch((error) => {
      console.error(error)
    })
}

function canCreateDelete(): boolean {
  let result = false
  Axios.get('/Token/CanCreateDelete').then((response) => {
    result = response.data
  })
  return result
}
</script>
