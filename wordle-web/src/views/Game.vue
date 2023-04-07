<template>
  <div class="about">
      <v-card
        theme="dark"
      >
        <v-card-title> The Good Word </v-card-title>

        <v-card-subtitle> The word guessing game! </v-card-subtitle>

        <v-card-text> 
            This is the game page. This text is being used as a placeholder as per the documentation requirements. 
        </v-card-text>

        <v-card-actions>  

            <v-spacer />
            
            <v-btn
                varient="tonal"
                rounded="xl"
                color="#5865f2"
                elevation="24"
            >
             Home 
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
