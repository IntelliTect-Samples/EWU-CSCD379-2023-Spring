<template>
  <v-card>
    <v-carousel height="800px">
      <v-carousel-item :src="image1" cover>
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
              <v-btn to="/description" variant="outlined"> Instructions </v-btn>
            </v-card-actions>
          </v-card>
        </div>
      </v-carousel-item>

      <v-carousel-item :src="image2" cover>
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

      <v-carousel-item :src="image3" cover>
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
  </v-card>
</template>

<script setup lang="ts">
import { ref, onMounted, onUnmounted, watch } from 'vue'
import { useTheme } from 'vuetify'

const theme = useTheme()

console.log(theme.name)
const themeName = ref(theme.name.value == 'useTheme' ? 'space' : theme.name.value)

function getImage1(): string {
  switch (themeName.value) {
    case 'inverse':
      return 'https://img.freepik.com/free-vector/unfocused-winter-landscape-with-snowflakes_1393-210.jpg'
    case 'dark':
      return 'https://c4.wallpaperflare.com/wallpaper/582/155/806/space-space-art-nebula-stars-wallpaper-preview.jpg'
    case 'oceanlight':
      return 'https://img.freepik.com/premium-vector/underwater-ocean-sandy-bottom-sunrays_87720-3706.jpg?size=626&ext=jpg'
    case 'oceandark':
      return 'https://img.freepik.com/free-photo/lovely-blue-paint-water_23-2147798302.jpg'
    case 'forestlight':
      return 'https://img.freepik.com/premium-vector/autumn-forest-landscape-with-grass-land-mid-autumn-fall-season-panoramic-illustration_288411-1838.jpg'
    case 'forestdark':
      return 'https://img.freepik.com/free-vector/watercolor-enchanted-forest-illustration_52683-84111.jpg'
  }
  return ''
}

function getImage2(): string {
  switch (themeName.value) {
    case 'inverse':
      return 'https://img.freepik.com/free-photo/floral-winter-watercolor-background-blue-with-beautiful-snow_53876-128740.jpg'
    case 'dark':
      return 'https://c4.wallpaperflare.com/wallpaper/292/712/921/space-galaxy-pink-blue-wallpaper-preview.jpg'
    case 'oceanlight':
      return 'https://img.freepik.com/free-photo/fantastic-seascape-with-ripples_1232-424.jpg'
    case 'oceandark':
      return 'https://img.freepik.com/premium-photo/rays-sun-make-their-way-depths-through-surface-water-underwater-background_250994-844.jpg'
    case 'forestlight':
      return 'https://img.freepik.com/free-vector/gradient-nature-background_52683-2433.jpg'
    case 'forestdark':
      return 'https://img.freepik.com/premium-photo/beautiful-landscape-green-forest_23-2148215269.jpg'
  }
  return ''
}

function getImage3(): string {
  switch (themeName.value) {
    case 'inverse':
      return 'https://img.freepik.com/free-vector/blurred-winter-background-with-hills_52683-48955.jpg'
    case 'dark':
      return 'https://c4.wallpaperflare.com/wallpaper/990/589/239/death-valley-sky-wallpaper-preview.jpg'
    case 'oceanlight':
      return 'https://img.freepik.com/free-vector/sea-background-video-conferencing_23-2148630091.jpg'
    case 'oceandark':
      return 'https://img.freepik.com/premium-photo/abstract-background-with-motion-shining-blinking-particles-blue-background-with-rays-light-3d-illustration_250994-2010.jpg'
    case 'forestlight':
      return 'https://img.freepik.com/free-vector/cartoon-forest-background-nature-scenery-landscape_107791-7791.jpg'
    case 'forestdark':
      return 'https://img.freepik.com/free-photo/landscape-tropical-green-forest_181624-30814.jpg'
  }
  return ''
}

let image1 = getImage1()
let image2 = getImage2()
let image3 = getImage3()

// Update the images when the theme changes
function updateImages() {
  image1 = getImage1()
  image2 = getImage2()
  image3 = getImage3()
}

// Listen to theme changes
onMounted(() => {
  const root = document.documentElement

  themeName.value = theme.global.name.value
  root.style.setProperty('--background-image', `url("${image1}")`)
  watch(
    () => theme.global.name.value,
    (newValue: string) => {
      // Update the value of the CSS variable
      //root.style.setProperty('--background-image', `url("${image1}")`);
      themeName.value = newValue

      // Update the value of the CSS variable
      root.style.setProperty('--background-image', `url("${getImage1()}")`)
      updateImages()
    }
  )
})
// Access the root element of the document

// Export the variables to be used in the template
</script>
