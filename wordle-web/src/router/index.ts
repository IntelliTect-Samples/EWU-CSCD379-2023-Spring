import { createRouter, createWebHistory } from 'vue-router'
import WordleView from '../views/WordleView.vue'
import AboutView from '../views/AboutView.vue'
import LeaderboardView from '../views/LeaderboardView.vue'
import InstructionsView from '../views/InstructionsView.vue'
import PreviousWordles from '../views/PreviousWordles.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'wordle',
      component: WordleView
    },
    {
      path: '/about',
      name: 'about',
      component: AboutView
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
    },
    {
      path: '/previouswordles',
      name: 'previouswordles',
      component: PreviousWordles
    },
    {
      path: '/instructions',
      name: 'instructions',
      component: InstructionsView
    }
  ]
})

export default router
