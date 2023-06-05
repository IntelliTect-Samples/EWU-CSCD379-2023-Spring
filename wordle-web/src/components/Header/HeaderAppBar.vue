<!--
---- Main vue file for the header of the website.
--->

<template>
  <v-app-bar class="py-1 px-6 toolbar">
    <v-toolbar-title>
      <div @click="router.push('/')" class="toolbar-title">
        <v-icon icon="mdi-book-open-page-variant" />
        The Good Word
      </div>
    </v-toolbar-title>

    <v-btn @click="toggleMusic">
      <v-icon size="large">{{ isPaused ? 'mdi-volume-high' : 'mdi-volume-mute' }}</v-icon>
    </v-btn>

    <SignInDialog />

    <v-btn icon="mdi-align-vertical-bottom" to="/leaderboard"></v-btn>

    <ActiveUser />

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
import SettingsCard from '@/components/Header/SettingsCard.vue'
import MenuDrawer from '@/components/Header/MenuDrawer.vue'
import ActiveUser from '@/components/Header/ActiveUser.vue'
import SignInDialog from '@/components/Header/SignInDialog.vue'

let menu = ref(false)
let settings = ref(false)
const isPaused = ref(true)
const audio = ref(new Audio(nightInKyoto))

/// Set menu to false when settings value is changed.
watch(settings, (val) => {
  if (val) {
    menu.value = false
  }
})

/// TODO: Add comment for watch function purpose.
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
.toolbar {
  font-size: 26px;
  font-weight: bold;
  border-bottom: 1px solid #656464;
  min-height: 65px;
}

.toolbar-title {
  cursor: pointer;
  width: 180px;
}
</style>
