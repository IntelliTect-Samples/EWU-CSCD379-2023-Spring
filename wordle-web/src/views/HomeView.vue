<template>
  <v-card>
    <v-col>
      <router-link to="/leaderBoard"><v-btn>Link To leaderBoard</v-btn></router-link>
      <router-link to="/wordle"><v-btn>Link To game</v-btn></router-link>
      <router-link to="/about"><v-btn>Link To about</v-btn></router-link>
      <router-link to="/days"><v-btn>Link To Days</v-btn></router-link>
      <router-link to="/wordoftheday"><v-btn>Link To word of the day</v-btn></router-link>
    </v-col>
  </v-card>
  <v-carousel height="800px">
    <v-carousel-item
      src="https://c4.wallpaperflare.com/wallpaper/582/155/806/space-space-art-nebula-stars-wallpaper-preview.jpg"
      cover
    >
      <div style="display: flex; justify-content: center; align-items: center; height: 100vh">
        <v-card class="mx-auto" max-width="344" variant="outlined" vertical-align="bottom">
          <v-card-item>
            <div>
              <div class="text-overline mb-1">Wordle</div>
              <div class="text-h6 mb-1">Overview</div>
              <div class="text-caption">
                Wordle Is A Challenging, Brain-Bending Game, Click for More
              </div>
            </div>
          </v-card-item>

          <v-card-actions>
            <v-btn to="/about" variant="outlined"> About </v-btn>
            <v-btn variant="outlined"> Instructions </v-btn>
          </v-card-actions>
        </v-card>
      </div>
    </v-carousel-item>

    <v-carousel-item
      src="https://c4.wallpaperflare.com/wallpaper/292/712/921/space-galaxy-pink-blue-wallpaper-preview.jpg"
      cover
    >
      <div style="display: flex; justify-content: center; align-items: center; height: 100vh">
        <v-card class="mx-auto" max-width="344" variant="outlined">
          <v-card-item>
            <div>
              <div class="text-overline mb-1">Wordle</div>
              <div class="text-h6 mb-1">Game</div>
              <div class="text-caption">
                Each day, a new word is chosen based on the date, alternatively, you can choose a
                random word
              </div>
            </div>
          </v-card-item>

          <v-card-actions>
            <v-btn to="/wordle" variant="outlined"> Play </v-btn>
            <v-btn to="/wordoftheday" variant="outlined"> Wordle of Day </v-btn>
          </v-card-actions>
        </v-card>
      </div>
    </v-carousel-item>

    <v-carousel-item
      src="https://c4.wallpaperflare.com/wallpaper/990/589/239/death-valley-sky-wallpaper-preview.jpg"
      cover
    >
      <div style="display: flex; justify-content: center; align-items: center; height: 100vh">
        <v-card class="mx-auto" max-width="344" variant="outlined">
          <v-card-item>
            <div>
              <div class="text-overline mb-1">Wordle</div>
              <div class="text-h6 mb-1">Leaderboard</div>
              <div class="text-caption">
                Results are stored and those whom have played exceptionally will be displayed. The
                wordle of the day statistics too will be displayed
              </div>
            </div>
          </v-card-item>

          <v-card-actions>
            <v-btn to="/leaderBoard" variant="outlined"> Leaderboard </v-btn>
            <v-btn to="/days" variant="outlined"> Wordle Stats </v-btn>
          </v-card-actions>
        </v-card>
      </div>
    </v-carousel-item>
  </v-carousel>
</template>

<script setup lang="ts"></script>
