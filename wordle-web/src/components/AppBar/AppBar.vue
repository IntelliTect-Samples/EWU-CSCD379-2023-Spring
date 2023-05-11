<template>
  <v-app-bar id="toolbar">
    <v-toolbar-title>
      <div @click="router.push('/')" id="toolbar-title">
        <v-icon icon="mdi-book-open-page-variant" />
        The Good Word
      </div>
    </v-toolbar-title>

    <v-btn @click="toggleMusic">
      <v-icon size="large">{{ isPaused ? 'mdi-volume-high' : 'mdi-volume-mute' }}</v-icon>
    </v-btn>

    <v-btn icon="mdi-align-vertical-bottom" to="/leaderboard"></v-btn>
    <v-btn icon="mdi-cog" @click.stop="settings = !settings"></v-btn>

    <v-app-bar-nav-icon @click.stop="menu = !menu"></v-app-bar-nav-icon>
  </v-app-bar>

  <SettingsCard v-model="settings" @updateSettingsCardValue="toggleSettings" />
  <MenuDrawer v-model="menu" />
</template>

<script setup lang="ts">
import { ref, watch, onMounted } from 'vue'
import router from '@/router'
import nightInKyoto from '@/assets/music/nightInKyoto.mp3'
import SettingsCard from '@/components/AppBar/SettingsCard.vue'
import MenuDrawer from '@/components/AppBar/MenuDrawer.vue'

let menu = ref(false)
let settings = ref(false)
const isPaused = ref(true)
const audio = ref(new Audio(nightInKyoto))

watch(settings, (val) => {
  if (val) {
    menu.value = false
  }
})

watch(
  () => settings.value,
  (newValue) => {
    settings.value = newValue
  }
)

onMounted(() => {
  audio.value.loop = true
  audio.value.volume = 0.2
})

function toggleSettings(newValue: boolean) {
  settings.value = newValue
}

function toggleMusic() {
  if (isPaused.value) {
    audio.value.play()
  } else {
    audio.value.pause()
  }
  isPaused.value = !isPaused.value
}
</script>

<style scoped>
#toolbar {
  width: 100%;
  padding: 6px 24px;
  font-size: 26px;
  font-weight: bold;
  border-bottom: 1px solid #656464;
  min-height: 65px;
}

#card-title {
  border-bottom: 1px solid;
}

#toolbar-title {
  cursor: pointer;
  width: 180px;
}
</style>
