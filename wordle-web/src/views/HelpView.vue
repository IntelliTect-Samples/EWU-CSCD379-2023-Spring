<template>
    <main class="d-flex align-center justify-center flex-wrap text-center ma-auto">
  <v-card
    class="mx-auto"
    max-width="1000"
    max-height="1000"
    min-height="500px"
    variant="outlined"
    style="

    min-width: 500px
    "
  >
          
  <v-card-item>
      <div>
        <div class="text-h6 mb-1">
          How to play:
        </div>
        <div class="text-caption">Guess the word of the day! 6 wrong guesses and you lose :'(</div>
      </div>
    </v-card-item>

      <v-btn color="correct">"?"</v-btn> Letter is correct and it's at the right place! Nice!
      <br>
      <br>
      <v-btn color="misplaced">"?"</v-btn> Letter exists in word but it's at the wrong place!
      <br>
      <br>
      <v-btn color="wrong">"?"</v-btn> Letter does not exist in word, don't try it again!!
  </v-card>
  
    
    
    </main>
</template>