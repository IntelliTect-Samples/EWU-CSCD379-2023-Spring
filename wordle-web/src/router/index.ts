import { createRouter, createWebHistory } from 'vue-router'
import WordleView from '../views/WordleView.vue'
import LeaderboardView from '../views/LeaderboardView.vue'
import LandingView from '../views/LandingView.vue'
import InstructionView from '../views/InstructionView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'Landing',
      component: LandingView
    },
    {
      path: '/instructions',
      name: 'instructions',
      component: InstructionView
    },
    {
      path: '/wordle',
      name: 'wordle',
      component: WordleView
    },
    {
      path: '/leaderboard',
      name: 'leaderboard',
      component: LeaderboardView
    },
    {
      path: '/wordoftheday',
      name: 'wordOfTheDay',
      component: WordleView
    }
  ]
})

export default router
