<template>
  <v-container class="d-flex justify-center align-center">
    <v-card>
      <div class="bg-primary text-h5 pa-3 text-center">How To Play</div>
      <v-card-text>
        <div v-for="(index) in 5" :key="index" >
          <div class="d-flex justify-start bg-secondary text-h6">{{ index }}</div>
          <v-card-text class="d-flex flex-column align-center">
            <v-row dense>
              <v-col cols="12" class="text-end">Total Games -</v-col>
              
            </v-row>
          </v-card-text>
        </div>
      </v-card-text>
    </v-card>
  </v-container>
</template>