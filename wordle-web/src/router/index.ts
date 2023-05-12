import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import LeaderboardView from '../views/LeaderboardView.vue'
import WordleView from '../views/WordleView.vue'
import AboutView from '../views/AboutView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/wordle',
      name: 'wordle',
      component: WordleView
    },
    {
      path: '/about',
      name: 'about',
      component: AboutView
    },

    {
      path: '/Leaderboard/0/',
      name: 'Leaderboard',
      component: LeaderboardView
    }
  ]
})

export default router
