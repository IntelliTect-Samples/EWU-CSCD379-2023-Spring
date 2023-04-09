<template>
    <v-container fluid class="game-board">
      <v-row class=" justify-center custom-row" v-for="(row, rowIndex) in 6" :key="'row-' + rowIndex">
        <v-col v-for="(col, colIndex) in 5" :key="'col-' + colIndex" cols="auto" class="px-1">
          <v-chip class="square" outlined></v-chip>
        </v-col>
      </v-row>
    </v-container>
  </template>
  
  <script lang="ts">
  import { defineComponent } from "vue";
  import { VContainer, VRow, VCol, VChip } from "vuetify/components";
  
  export default defineComponent({
    components: {
      VContainer,
      VRow,
      VCol,
      VChip,
    },
    
    methods: {
    handleKeyPress(key: string) {
      console.log("Key pressed:", key);
    },
  },
  });
  </script>

  
  <style scoped>
  .square {
    color: white;
    border-radius: 0 !important;
    border: 2px solid black;
    width: 50px;
    height: 50px;
  }
  
  .custom-row {
    margin-top: 1px;
  }
  </style>
  