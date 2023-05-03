<template>
  <main>Home Page</main>
  <v-card>
    <router-link to="/leaderBoard"><v-btn>Link To leaderBoard</v-btn></router-link>
  </v-card>

  <div class="text-center">
    <v-dialog transition="dialog-bottom-transition">
      <template v-slot:activator="{ props }">
        <v-btn v-bind="props" class="ml-1" v-on:keydown.enter.prevent>click me</v-btn>
      </template>
      <template v-slot:default="{ isActive }">
        <v-card>
          <v-toolbar title="login"></v-toolbar>
          <v-card-text>
            <v-container>
              <v-row>
                <v-col cols="12" sm="6" md="4">
                  <v-text-field label="Name" required></v-text-field>
                </v-col>
              </v-row>
            </v-container>
          </v-card-text>
          <v-spacer></v-spacer>
          <v-card-actions class="justify-end">
            <v-btn variant="text" @click="isActive.value = false">Close</v-btn>
            <v-btn variant="text" @click="isActive.value = false">Submit</v-btn>
          </v-card-actions>
        </v-card>
      </template>
    </v-dialog>
  </div>

  <p>display name :</p>
</template>

<script setup lang="ts"></script>
