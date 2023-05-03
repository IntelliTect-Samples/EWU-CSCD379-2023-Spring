<template>
  <div class="text-center">
    <v-dialog v-model="dialog" transition="dialog-bottom-transition">
      <template v-slot:activator="{ props }">
        <v-btn v-bind="props" icon>
          <v-icon>mdi-account-circle</v-icon>
        </v-btn>
      </template>
      <template v-slot:default="">
        <v-card>
          <v-toolbar title="login"></v-toolbar>
          <v-card-text>
            <v-container>
              <v-row>
                <v-col cols="12" sm="6" md="4">
                  <v-text-field v-model="firstname" label="Firstname"></v-text-field>
                </v-col>
              </v-row>
            </v-container>
          </v-card-text>
          <v-spacer></v-spacer>
          <v-card-actions class="justify-end">
            <v-btn variant="text" @click="dialog = false">Close</v-btn>
            <v-btn variant="text" @click="dialog = false">Submit</v-btn>
          </v-card-actions>
        </v-card>
      </template>
    </v-dialog>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const firstname = ref('')
var dialog = ref(true)



</script>
