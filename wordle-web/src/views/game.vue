

<template>
  <div class="game">
    <VCard variant="tonal">
      <VCardTitle>
        WordleCopy
      </VCardTitle>
      <VCardSubtitle>
        Sample Text. Lorem ipsum dolor sit amet consectetur adipisicing elit. Numquam, fuga consectetur.
      </VCardSubtitle>
      <v-divider :thickness="5"></v-divider>
      <v-container>
        <v-row justify="space-evenly" v-for="i in 6" :key="i">
          <v-col v-for="j in 5" :key="`${i}-${j}`" cols="auto">
            <v-card
              height="50"
              width="50"
              :class="['d-flex justify-center align-center', ]"
            >
              <div>{{  }}</div>
            </v-card>
          </v-col>
        </v-row>
      </v-container>

      <v-combobox
      
        label="WordGuess"
        clearable
        
      ></v-combobox>

      <VCardActions>
        <VSpacer></VSpacer>
        <v-btn variant="tonal">
          <RouterLink to="/">Home</RouterLink>
        </v-btn>
      </VCardActions>
    </VCard>
  </div>
</template>



  
  <style>
    @media (min-width: 1024px) {
      .game {
        min-height: 100vh;
        display: flex;
        align-items: center;
      }
    }
  </style>
  