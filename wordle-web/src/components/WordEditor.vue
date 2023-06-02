<template>
  <div class="text-center">
    <v-btn
      color="primary"
    >
      Edit Dictionary

      <v-dialog
        v-model="dialog"
        activator="parent"
        width="auto"
      >
        <v-card>
          <v-card-text>
            Word Editor
          </v-card-text>
          <v-card-actions>
            <v-btn color="primary" block @click="dialog = false">Close Dialog</v-btn>
          </v-card-actions>
        </v-card>
        <v-sheet width="300" class="mx-auto">

<v-form ref="form">
  <v-text-field
    v-model="name"
    :counter="10"
    label="Name"
    required
  ></v-text-field>

  <div class="d-flex flex-column">
    <v-btn
      color="success"
      class="mt-4"
      block
      @click="addWord"
    >
      Add
    </v-btn>

    <v-btn
      color="error"
      class="mt-4"
      block
      @click="flipIsCommon"
    >
      Flip Is Common Value
    </v-btn>

    <v-btn
      color="warning"
      class="mt-4"
      block
      @click="removeWord"
    >
      Remove Word
    </v-btn>
  </div>
</v-form>
</v-sheet>
      </v-dialog>
    </v-btn>
  </div>
</template>

<script lang="ts">
// Goals of the word editor page: 
// 1) Be a dialog that pops up when the user clicks a button on the Dictionary Page
// 2) Have a text box where the user types in the relevant word
// 3) 3 Buttons
  // a) Remove
  // b) Add
  // c) Flip Is Common Flag
  import { ref } from 'vue'

    export default {
    data: () => ({
      dialog: false,

      valid: true,
      name: '',
      select: null,
      items: [
        'Item 1',
        'Item 2',
        'Item 3',
        'Item 4',
      ],
      checkbox: false,
    }),

    methods: {
      async removeWord () {
        console.log("Remove Word")
      },
      addWord () {
        console.log("Add Word")
      },
      flipIsCommon () {
        console.log("Flip is common")
      },
    },
  }
  

</script>
