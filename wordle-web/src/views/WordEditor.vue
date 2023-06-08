<template>
    <div class="text-center">
    <v-pagination v-model="page" :length="totalPages" :total-visible="6" rounded="circle"></v-pagination>
    <v-row>
        <v-col v-for="item in paginatedItems" :key="item.wordId" cols="2">
            <v-list-item @click="openDialog(item)">
                <v-list-item-title>{{ item.text }}</v-list-item-title>
            </v-list-item>
        </v-col>
    </v-row>
    <v-pagination v-model="page" :length="totalPages" :total-visible="6" rounded="circle"></v-pagination>
        <v-row justify="center">
            <v-col cols="2">
                <v-select label="Items per page" v-model="perPage" :items="[30, 60, 120, 240]"></v-select>
            </v-col>
            <v-col cols="2">
                <v-text-field v-model="search" label="Search for word"></v-text-field>
            </v-col>
            <v-col cols="2">
                <v-btn v-if="admin || (ruleroftheuniverse && age)" color="primary" text @click="addnewword = true">Add new word</v-btn>
            </v-col>
        </v-row>
  
        <v-dialog v-model="dialogVisible" max-width="500px">
            <v-card class="text-center">
                <v-card-title> Your select word: </v-card-title>
                <v-list-item>
                    <v-list-item-title>{{ selectedWord?.text }}</v-list-item-title>
                </v-list-item>
                <v-card-actions class="d-flex justify-center">
                    <v-btn v-if="signInService.isSignedIn" color="primary" text @click="editofword = true">Edit</v-btn>
                    <v-btn v-if="admin || (ruleroftheuniverse && age) " color="error" text @click="deleteWord(selectedWord?.text ?? '')">Delete</v-btn>
                    <v-btn color="primary" text @click="dialogVisible = false">Close</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>

        <v-dialog v-model="editofword" max-width="500px">
            <v-card>
                <v-card-title> Edit word: </v-card-title>
                <v-card-text>
                    <p> Are {{ selectedWord?.text }} a common word?</p>
                    <v-radio-group v-model="selectedOption">
                    <v-radio label="Yes" value="yes" color="green"></v-radio>
                    <v-radio label="No" value="no" color="red"></v-radio> 
                    </v-radio-group>
                </v-card-text>
            <v-card-actions class="d-flex justify-center">
                <v-btn color="error" text @click="editofword = false">Close</v-btn>
                <v-btn color="primary" text @click="editWord(selectedWord?.text ?? '', selectedOption === 'yes'), editofword = false">Save</v-btn>
            </v-card-actions>
            </v-card>
        </v-dialog>

        <v-dialog v-model="addnewword" max-width="500px">
            <v-card>
                <v-card-title> Add new word: </v-card-title>
                <v-card-text>
                    <v-text-field v-model="newword" label="New word" :rules="newWordRules" ></v-text-field>
                    <p> Are <strong>{{ newword }} </strong> a common word?</p>
                    <v-radio-group v-model="selectedOption">
                    <v-radio label="Yes" value="yes" color="green"></v-radio>
                    <v-radio label="No" value="no" color="red"></v-radio> 
                    </v-radio-group>
                </v-card-text>
            <v-card-actions class="d-flex justify-center">
                <v-btn color="error" text @click="addnewword = false">Close</v-btn>
                <v-btn color="primary" text @click="addnewword = false, addWord(newword, selectedOption === 'yes')" :disabled="!isWordValid"
                >Save</v-btn>
            </v-card-actions>
            </v-card>
    
        </v-dialog>
    </div>
  
    <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
    <v-progress-circular color="primary" indeterminate size="64" />
    </v-overlay>
</template>
  
<script setup lang="ts">
import { ref, computed, watch, inject, onMounted } from 'vue';
import Axios from 'axios'
import type { SignInService } from '@/scripts/signInService'
import { Services } from '@/scripts/services'

const signInService = inject(Services.SignInService) as SignInService

  
const page = ref(1)
const perPage = ref(60)
const countitem = ref<WordData[]>([])
const search = ref('')
const selectedWord = ref<WordData | null>(null)
const dialogVisible = ref(false)
const editofword = ref(false)
const overlay = ref(true)
const selectedOption = ref(null)
const addnewword = ref(false)
const newword = ref("")
const isWordValid = ref(false);

const admin = ref(false)
const ruleroftheuniverse = ref(false)
const age = ref(false)

onMounted(() => {
    testadmin()
    testruleroftheuniverse()
    testage()
})
  
interface WordData {
    wordId: number;
    text: string;
    isCommon: boolean;
    isUsed: boolean;
    dateWords: any[];
}
  
const fetchData = async () => {
    try {
      const response = await Axios.get('Word/WordList')
      countitem.value = response.data
      overlay.value = false
    } catch (error) {
      console.log(error)
    }
}
  
const totalPages = computed(() => Math.ceil(countitem.value.length / perPage.value))
const paginatedItems = computed(() => {
const startIndex = (page.value - 1) * perPage.value
const endIndex = startIndex + perPage.value
const filteredItems = countitem.value.filter((item) => item.text.includes(search.value))
return filteredItems.slice(startIndex, endIndex)
})
  
function openDialog(item: WordData) {
    selectedWord.value = item
    dialogVisible.value = true
}
  
function editWord(word : string, isCommon : boolean) {
    Axios.post(`Word/AddWord?newWord=${word}&isCommon=${isCommon}`)
    .then((response): void => {
          console.log(response.data)
      }) 
          .catch((error) => {
          console.log(error)
      })
    dialogVisible.value = false
}
  
function deleteWord( word : string) {
    Axios.post(`Word/RemoveWord?removeWord=${word}`)
    .then((response): void => {
          console.log(response.data)
      }) 
          .catch((error) => {
          console.log(error)
      })
    window.location.reload()
    dialogVisible.value = false
}
  
function addWord(word : string, isCommon : boolean) {
    Axios.post(`Word/AddWord?newWord=${word}&isCommon=${isCommon}`)
    .then((response): void => {
          console.log(response.data)
      }) 
          .catch((error) => {
          console.log(error)
      })
    dialogVisible.value = false
    window.location.reload()
}

const newWordRules = [
  (v: string) => !!v || "New word is required",
  (v: string) => /^[A-Za-z]+$/.test(v) || "New word must contain only letters",
  (v: string) => (v && v.length === 5) || "New word must have exactly 5 letters",
  (v: string) => !countitem.value.some(item => item.text === v) || "Word already exists in the list"
]

watch(newword, (value) => {
  isWordValid.value = newWordRules.every(rule => rule(value) === true);
})

function testadmin() {
    Axios.get('Token/testadmin')
    .then((response): void => {
          console.log(response.data)
          admin.value = true
      }) 
          .catch((error) => {
          console.log(error)
      })
}

function testruleroftheuniverse() {
    Axios.get('Token/testruleroftheuniverse')
    .then((response): void => {
          console.log(response.data)
          ruleroftheuniverse.value = response.data
      }) 
          .catch((error) => {
          console.log(error)
      })
}

function testage() {
    Axios.get('Token/testage')
    .then((response): void => {
          console.log(response.data)
          age.value = response.data
      }) 
          .catch((error) => {
          console.log(error)
      })
}


fetchData()
</script>
  