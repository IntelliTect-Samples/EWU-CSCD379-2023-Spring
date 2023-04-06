<template>
  <div class="about">
    <v-card>
      <v-card-title> This is a Vuetify Card </v-card-title>
      <v-card-subtitle> This is a subtitle </v-card-subtitle>
      <v-card-text>
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Commodi, ratione debitis quis est
        labore voluptatibus! Eaque cupiditate minima, at placeat totam, magni doloremque veniam
        neque porro libero rerum unde voluptatem!
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn text color="warning"> Cancel </v-btn>
        <v-btn text color="primary"> OK </v-btn>
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
