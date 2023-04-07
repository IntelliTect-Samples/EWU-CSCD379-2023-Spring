<template>
  <div class="about">
    <v-card
        theme="dark"
      >
        <v-card-title> About Page </v-card-title>

        <v-card-text> 
            This is an about page. 
        </v-card-text>

        <v-card-actions>  

            <v-spacer />

            <v-btn
                varient="tonal"
                rounded="xl"
                color="#5865f2"
                elevation="24"
                to="/"
            >
             Home 
            </v-btn>

            <v-btn
                varient="tonal"
                rounded="xl"
                color="#5865f2"
                elevation="24"
                to="/Game"
            >
             Game 
            </v-btn>

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
