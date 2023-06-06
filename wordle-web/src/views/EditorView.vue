<template>
  <v-parallax height="650" src="https://source.unsplash.com/zeInZepl_Hw">
    <div class="d-flex flex-column fill-height justify-center align-center">
      <v-card class="pa-8">
        <v-row><h1>Word Editor</h1></v-row>

        <v-row>
          <v-col cols="12" lg="6">
            <v-text-field label="Search"></v-text-field>
          </v-col>
          <v-col cols="12" lg="3">
            <v-select
              label="Page Size"
              :items="[10, 25, 50, 100]"
              variant="outlined"
            ></v-select
          ></v-col>
          <v-col cols="12" lg="3"
            ><v-text-field
              label="Page No."
              type="number"
            ></v-text-field
          ></v-col>
        </v-row>

        <v-table density="compact">
          <thead>
            <tr>
              <th>Word</th>
              <th>Is Common</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <!-- <tr v-for="word in list" :key="word.wordId">
              <td>{{ word.text }}</td>
              <td>
                <v-checkbox
                  v-model="word.isCommon"
                  @change="updateWord(word)"
                />
                <v-icon v-if="word.isCommon" color="green"
                  >mdi-check</v-icon
                >
                <v-icon v-if="!word.isCommon">mdi-alpha-x</v-icon>
              </td>
              <td>
                <v-icon color="red" @click="deleteWord(word.wordId)">mdi-delete</v-icon>
              </td>
            </tr> -->
          </tbody>
        </v-table>
      </v-card>
    </div>
  </v-parallax>
</template>
<!-- <script lang="ts">
import { reactive, watch } from 'vue'
import { WLItem, WLOptions } from '../scripts/wordEditor'

const options = reactive(new WLOptions())
const wordList = reactive(new Array<WLItem>())

watch(options, () => {
  refreshList()
})
refreshList()

function refreshList() {
  console.log('A')
}
</script> -->
