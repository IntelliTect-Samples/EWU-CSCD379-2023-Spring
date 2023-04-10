<template>
  <div class="about">
    <v-card>
      <v-card-title> This is a vue CLASS! </v-card-title>
      <v-card-subtitle> (CLASS) </v-card-subtitle>

      <v-card-text> 
        Pizza 
        <v-icon icon="mdi:mdi-abacus" />
      </v-card-text>

      <v-card-actions>
        <v-spacer />
        <v-btn text>Cancel</v-btn>
        <v-btn text>OK</v-btn>
      </v-card-actions>
    </v-card>
  </div>
</template>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
