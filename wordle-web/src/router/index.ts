import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import WordleView from '../views/WordleView.vue'
import AboutViewVue from '@/views/AboutView.vue'
import LeaderboardViewVue from '@/views/LeaderboardView.vue'

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
      component: AboutViewVue
    },
    {
      path: '/leaderboard',
      name: 'leaderboard',
      component: LeaderboardViewVue
    }
  ]
})

export default router
