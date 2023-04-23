<template>
    <nav>
        <v-toolbar flat app>
            <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
            <v-toolbar-title @click="$router.push('/')"><v-icon>mdi-diamond-stone</v-icon> Wordle Redux</v-toolbar-title>
            <v-spacer></v-spacer>
            <v-toolbar-items class="red--text">
                <v-btn  to="/">Home</v-btn>
                <v-btn  to="/wordle">Wordle</v-btn>
                <v-btn  to="/about">About</v-btn>
                <v-app-bar-nav-icon @click="setLightTheme" icon="mdi-theme-light-dark" > </v-app-bar-nav-icon>
                <v-app-bar-nav-icon @click.stop="setting = !setting" icon="mdi-cog"></v-app-bar-nav-icon>
            </v-toolbar-items>
        </v-toolbar>



        <v-navigation-drawer @click.stop="drawer = !drawer" v-model="drawer" temporary>
            <v-list-item>
                <v-list-item-content>
                    <v-list-item-title class="title" >Wordle Redux</v-list-item-title>
                    <v-list-item-subtitle>Wordle Redux</v-list-item-subtitle>
                    <v-list-item @click.stop="drawer = !drawer" prepend-icon="mdi-home" to="/"> Home </v-list-item>
                    <v-list-item @click.stop="drawer = !drawer" prepend-icon="mdi-star" to="/wordle"> Wordle </v-list-item>
                    <v-list-item @click.stop="drawer = !drawer" prepend-icon="mdi-information" to="/about"> About</v-list-item> 
                </v-list-item-content>
            </v-list-item>
        </v-navigation-drawer>

        <v-navigation-drawer @click.stop="setting = !setting" location="right" v-model="setting" temporary>
            <v-list-item>
                <v-list-item-content>
                    <v-list-item-title class="title" >Wordle Redux</v-list-item-title>
                    <v-list-item-subtitle>Wordle Redux</v-list-item-subtitle>
                    <v-list-item @click="setLightTheme" prepend-icon="mdi-theme-light-dark" > LightTheme </v-list-item>
                    <v-list-item @click="setDarkTheme" prepend-icon="mdi-theme-light-dark" > DarkTheme </v-list-item>
                    <v-list-item @click.stop="setting = !setting" prepend-icon="mdi-information" to="/about"> About</v-list-item> 
                </v-list-item-content>
            </v-list-item>
        </v-navigation-drawer>

    </nav>
</template>

<script>
import { useTheme } from 'vuetify/lib/framework.mjs'

export default {
  name: 'NavBar',
  data: () => ({
    drawer: false,
    setting: false,
  }),
  setup() {
    const theme = useTheme();
    return { theme };
  },
  methods: {
    setLight() {
      if (this.theme.global.name === 'neonLight') {
        this.theme.global.name = 'neonLight';
      } else {
        this.theme.global.name = 'light';
      }
    },
    setDark() {
      if (this.theme.global.name === 'neonDark') {
        this.theme.global.name = 'neonDark';
      } else {
        this.theme.global.name = 'dark';
      }
    }
  }
}


</script>