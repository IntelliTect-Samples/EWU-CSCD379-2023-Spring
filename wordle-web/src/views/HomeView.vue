<template>
  <v-card>
    <!-- ... -->
    <v-carousel height="800px">
      <v-carousel-item
        :src="image1"
        cover
      >
        <!-- ... -->
      </v-carousel-item>

      <v-carousel-item
        :src="image2"
        cover
      >
        <!-- ... -->
      </v-carousel-item>

      <v-carousel-item
        :src="image3"
        cover
      >
        <!-- ... -->
      </v-carousel-item>
    </v-carousel>
  </v-card>
</template>

<script setup lang="ts">
import { ref, onMounted, onUnmounted, watch } from 'vue'
import { useTheme } from 'vuetify'

const themeName = ref('dark')

function getImage1(): string {
  switch (themeName.value) {
    case 'inverse':
      return 'https://img.freepik.com/free-vector/unfocused-winter-landscape-with-snowflakes_1393-210.jpg'
    case 'dark':
      return 'https://c4.wallpaperflare.com/wallpaper/582/155/806/space-space-art-nebula-stars-wallpaper-preview.jpg'
    case 'oceanlight':
      return 'Test1'
    case 'oceandark':
      return 'Test1'
    case 'forestlight':
      return 'Test1'
    case 'forestdark':
      return 'Test1'
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
      return 'Test1'
    case 'oceandark':
      return 'Test1'
    case 'forestlight':
      return 'Test1'
    case 'forestdark':
      return 'Test1'
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
      return 'Test1'
    case 'oceandark':
      return 'Test1'
    case 'forestlight':
      return 'Test1'
    case 'forestdark':
      return 'Test1'
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
const theme = useTheme()
onMounted(() => {
  themeName.value = theme.global.name.value
  watch(() => theme.global.name.value, (newValue:string) => {
    console.log("Change to: " + newValue);

  themeName.value = newValue
  updateImages()
})
})


// Export the variables to be used in the template
</script>