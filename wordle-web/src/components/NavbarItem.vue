<template v-slot:activator="{ props }">
  <nav>
    <v-app-bar>
      <v-app-bar-title>
        <v-btn prepend-icon="mdi-puzzle" variant="text" to="/" class="text-h6 mb-1">Wor·dle</v-btn>
      </v-app-bar-title>

      <v-app-bar-nav-icon>
        <SettingsMenu></SettingsMenu>
      </v-app-bar-nav-icon>

      <v-menu width="auto">
        <template v-slot:activator="{ props }">
          <v-app-bar-nav-icon v-bind="props">
            <v-icon>mdi-hamburger</v-icon>
          </v-app-bar-nav-icon>
        </template>

        <v-list>
          <v-list-item>
            <HelpMenu></HelpMenu>
          </v-list-item>

          <v-list-item>
            <LeaderBoard></LeaderBoard>
          </v-list-item>

          <v-list-item>
            <v-btn prepend-icon="mdi-book" to="/about"> About </v-btn>
          </v-list-item>

          <v-list-item>
            <v-btn color="blue-darken-1" variant="text" @click="isActive = false"> Close </v-btn>
          </v-list-item>
        </v-list>
      </v-menu>
    </v-app-bar>
  </nav>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import HelpMenu from './HelpMenuItem.vue'
import LeaderBoard from './LeaderBoardItem.vue'
import SettingsMenu from './SettingsMenu.vue'

export default defineComponent({
  components: {
    SettingsMenu,
    HelpMenu,
    LeaderBoard
  },

  data: () => ({
    isActive: false,
    isDarkMode: false
  })
})
</script>
