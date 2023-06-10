<template>
  <v-card>
    <v-card-item>
      <v-table>
        <thead>
          <tr>
            <th class="text-center">Word</th>
            <th class="text-center">Is Common</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="word in words" :key="word.wordID">
            <td class="text-center">{{ word.text }}</td>
            <td class="text-center">{{ word.isCommon ? 'Yes' : 'No' }}</td>
            <td>
              <v-btn @click="openEditIsCommon(word.text, word.isCommon)" color="success"
                >Edit Is Common</v-btn
              >
            </td>
            <td>
              <v-btn
                v-if="signInService.token.roles.includes('MasterOfTheUniverse')"
                @click="openRemoveWord(word.text)"
                color="error"
                >Remove</v-btn
              >
            </td>
          </tr>
        </tbody>
      </v-table>
    </v-card-item>

    <v-card-item>
      <v-text-field v-model="searchWord" label="Search" @update:model-value="updateSearch()" />
    </v-card-item>

    <v-card-item
      class="justify-center"
      v-if="signInService.token.roles.includes('MasterOfTheUniverse')"
    >
      <v-btn @click="addWordDialog = !addWordDialog" color="primary">Add Word</v-btn>
    </v-card-item>

    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn @click="previousPage()" variant="outlined">Prev</v-btn>
      <v-btn @click="nextPage()" variant="outlined">Next</v-btn>
      <v-spacer></v-spacer>
    </v-card-actions>
  </v-card>

  <v-dialog
    v-model="addWordDialog"
    class="align-center justify-center"
    max-width="400px"
    persistent
  >
    <v-card>
      <v-card-item>
        <v-text-field v-model="addWordText" label="New Word"></v-text-field>
      </v-card-item>

      <v-card-item>
        <v-select v-model="addWordIsCommon" label="Is Common" :items="['No', 'Yes']"> </v-select>
      </v-card-item>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn class="bg-success" @click="addWord()">Submit</v-btn>
        <v-btn @click="addWordDialog = !addWordDialog" variant="outlined">Close</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>

  <v-dialog
    v-model="editIsCommonDialog"
    class="align-center justify-center"
    max-width="400px"
    persistent
  >
    <v-card>
      <v-card-item>
        <v-card-text>
          Word: {{ editIsCommonWord.text }} - Is Common:
          {{ editIsCommonWord.isCommon ? 'Yes' : 'No' }}
        </v-card-text>
      </v-card-item>

      <v-card-item>
        <v-select v-model="addWordIsCommon" label="Is Common" :items="['No', 'Yes']"> </v-select>
      </v-card-item>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn class="bg-success" @click="submitEditIsCommon()">Submit</v-btn>
        <v-btn @click="editIsCommonDialog = !editIsCommonDialog" variant="outlined">Close</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>

  <v-dialog
    v-model="removeWordDialog"
    class="align-center justify-center"
    max-width="400px"
    persistent
  >
    <v-card>
      <v-card-item>
        <v-card-text>Are you sure you want to remove {{ wordToRemove.text }}?</v-card-text>
      </v-card-item>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn @click="submitRemoveWord()" class="bg-error">Yes, I'm sure</v-btn>
        <v-btn @click="removeWordDialog = !removeWordDialog" variant="outlined">Cancel</v-btn>
        <v-spacer></v-spacer>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { WordHelper } from '@/scripts/wordHelper'
import Axios from 'axios'
import { inject, ref } from 'vue'
import type { SignInService } from '@/scripts/signInService'
import { Services } from '@/scripts/services/services'

const signInService = inject(Services.SignInService) as SignInService

const words = ref<WordHelper[]>([])
let page = 0
let searchWord = ref<string>('')

let addWordDialog = ref<boolean>(false)
let addWordText = ref<string>('')
let addWordIsCommon = ref<string>('')

let editIsCommonDialog = ref<boolean>(false)
let editIsCommonWord = ref<WordHelper>(new WordHelper())

let wordToRemove = ref<WordHelper>(new WordHelper())
let removeWordDialog = ref<boolean>(false)

Axios.get('Word/WordList?pageNumber=0').then((response) => {
  words.value = response.data as WordHelper[]
})

function nextPage() {
  if (words.value.length == 10) {
    page++
    if (searchWord.value === '') {
      Axios.get('Word/WordList?pageNumber=' + page).then((response) => {
        words.value = response.data as WordHelper[]
      })
    } else {
      Axios.get('Word/WordList?pageNumber=' + page + '&searchWord=' + searchWord.value).then(
        (response) => {
          words.value = response.data as WordHelper[]
        }
      )
    }
  }
}

function previousPage() {
  if (page > 0) {
    page--
    if (searchWord.value === '') {
      Axios.get('Word/WordList?pageNumber=' + page).then((response) => {
        words.value = response.data as WordHelper[]
      })
    } else {
      Axios.get('Word/WordList?pageNumber=' + page + '&searchWord=' + searchWord.value).then(
        (response) => {
          words.value = response.data as WordHelper[]
        }
      )
    }
  }
}

function updateSearch() {
  console.log(searchWord.value)
  page = 0
  Axios.get('Word/WordList?pageNumber=' + page + '&searchWord=' + searchWord.value).then(
    (response) => {
      words.value = response.data as WordHelper[]
    }
  )
}

function addWord() {
  let text = addWordText.value.toLowerCase()
  let common = false

  if (addWordIsCommon.value === 'Yes') {
    common = true
  }

  if (text.length === 5) {
    const newWord = new WordHelper()
    newWord.text = text
    newWord.isCommon = common
    Axios.post('/Word/AddWord', newWord).then(() => {
      addWordText.value = ''
      addWordIsCommon.value = ''
      if (searchWord.value === '') {
        Axios.get('Word/WordList?pageNumber=' + page).then((response) => {
          words.value = response.data as WordHelper[]
        })
      } else {
        Axios.get('Word/WordList?pageNumber=' + page + '&searchWord=' + searchWord.value).then(
          (response) => {
            words.value = response.data as WordHelper[]
          }
        )
      }
    })
  }
  addWordDialog.value = false
}

function openRemoveWord(wordText: string) {
  wordToRemove.value.text = wordText
  removeWordDialog.value = !removeWordDialog.value
}

function submitRemoveWord() {
  Axios.post('/Word/RemoveWord', wordToRemove.value).then(() => {
    removeWordDialog.value = !removeWordDialog.value
    if (searchWord.value === '') {
      Axios.get('Word/WordList?pageNumber=' + page).then((response) => {
        words.value = response.data as WordHelper[]
      })
    } else {
      Axios.get('Word/WordList?pageNumber=' + page + '&searchWord=' + searchWord.value).then(
        (response) => {
          words.value = response.data as WordHelper[]
        }
      )
    }
  })
}

function openEditIsCommon(wordText: string, isCommon: boolean) {
  editIsCommonWord.value.text = wordText
  editIsCommonWord.value.isCommon = isCommon
  editIsCommonDialog.value = !editIsCommonDialog.value
}

function submitEditIsCommon() {
  if (addWordIsCommon.value === 'Yes') {
    editIsCommonWord.value.isCommon = true
  } else {
    editIsCommonWord.value.isCommon = false
  }

  Axios.post('/Word/AddWord', editIsCommonWord.value).then(() => {
    editIsCommonWord.value.text = ''
    editIsCommonWord.value.isCommon = false
    editIsCommonDialog.value = !editIsCommonDialog.value
    if (searchWord.value === '') {
      Axios.get('Word/WordList?pageNumber=' + page).then((response) => {
        words.value = response.data as WordHelper[]
      })
    } else {
      Axios.get('Word/WordList?pageNumber=' + page + '&searchWord=' + searchWord.value).then(
        (response) => {
          words.value = response.data as WordHelper[]
        }
      )
    }
  })
}
</script>
