<template>
  <v-sheet color="teal-darken-4" height="150px" class="pt-10">
    <v-card class="ma-10" rounded="xl" elevation="">
      <v-card-title>Hello World!</v-card-title>>
    </v-card>
  </v-sheet>
  <v-row dense>
    <v-col v-for="i in 10" :key = "i" cols ="12" sm="6" md="3" lg="3">
      <v-card class="ms-1">
        <v-card-title>{{ i }}</v-card-title>
      </v-card>
    </v-col>
  </v-row>
</template>
