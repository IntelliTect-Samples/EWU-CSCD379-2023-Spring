<!-- main color: #318F6B Secondary color: #B5441C-->

<template>
  <h1>This is the PLAYGROUND</h1>

  <v-tabs fixed-tabs>
    <v-tab to=""> Home </v-tab>
    <v-tab to=""> About </v-tab>
    <v-tab to=""> Wordle </v-tab>
    <v-tab to=""> Game </v-tab>
  </v-tabs>

  <v-card class="mx-auto" max-width="600" max-height="400" variant="outlined">
    <v-card-title> Stirred Word </v-card-title>
    <v-card-text>
      Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.
      Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo
      magna eros quis urna. Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
    </v-card-text>
    <v-card-actions>
      <v-spacer />
      <v-btn variant="tonal" to="/" color="primary"> Home Page </v-btn>
    </v-card-actions>
  </v-card>
</template>
