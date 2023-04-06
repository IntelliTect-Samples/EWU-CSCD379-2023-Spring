<template>
  <div class="about">
    <h1>This is an about page</h1>
    <v-card 
    class="mx-auto"
    max-width="344"
    variant="outlined"
    >
      <v-card-title> This is a vue/vuetify page! </v-card-title>
      <v-card-subtitle>(College Class)</v-card-subtitle>

      <v-card-text> This is the placeholder text for the button context</v-card-text>

      <v-card-actions>
        <v-spacer />
        <v-btn text color="error"> Cancel </v-btn>
        <V-btn text color="primary">OK</V-btn>
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
