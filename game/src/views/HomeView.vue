<script setup lang="ts">
import { ref } from 'vue'; 

const showMessage = ref(false);

const handleButtonClick = () => {
  showMessage.value = true;
};

</script>

<template>
  <div class="game">
    <v-card>
      <v-card-title>
        <h2>What is the state bird of WA state?</h2>
      </v-card-title>
      <v-container fluid>
        <v-row>
          <v-col cols="6">
            <img class="game-image" src="https://www.allaboutbirds.org/guide/assets/photo/67471191-480px.jpg" alt="Mountain Bluebird" />
            <v-btn color="primary" @click="handleButtonClick" ref="mountainBlueBirdBtn">Mountain Bluebird</v-btn>
            <p v-if="showMessage"> You dun' got it right scoob!</p>
          </v-col>
          <v-col cols="6">
            <img class="game-image" src="https://cdn.download.ams.birds.cornell.edu/api/v1/asset/306710541/1800" alt="American Goldfinch" />
            <v-btn color="primary">American Goldfinch</v-btn>
          </v-col>
        </v-row>
        <v-row>
          <v-col cols="6">
            <img class="game-image" src="https://t0.gstatic.com/licensed-image?q=tbn:ANd9GcSpaRjpF6r4vh9V0aDefVfLy2orf0X5jRBT9cwJ60PqgSa2wdUZ7GYYveThPF32iPz1ASO16XyDmMmg-QQ" alt="Pine Siskin" />
            <v-btn color="primary">Pine Siskin</v-btn>
          </v-col>
          <v-col cols="6">
            <img class="game-image" src="https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/Western_Meadowlark.jpg/1200px-Western_Meadowlark.jpg" alt="Western Meadowlark" />
            <v-btn color="primary">Western Meadowlark</v-btn>
          </v-col>
        </v-row>
      <v-card-text>
        <p>This is a sample of what the US States Trivia game would look like. No further functionality was added, because we're still learning. Lol.</p>  
      </v-card-text>

      </v-container>
    </v-card>
  </div>
</template>

<style scoped>
.game-image {
  width: 200px;
  height: 200px;
  object-fit: cover;
}
</style>
