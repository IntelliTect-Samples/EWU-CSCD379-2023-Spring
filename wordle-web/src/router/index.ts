import { createRouter, createWebHistory } from 'vue-router'
import WordleView from '../views/WordleView.vue'
import AboutView from '../views/AboutView.vue'
import LeaderboardView from '../views/LeaderboardView.vue'
import InstructionsView from '../views/InstructionsView.vue'
import LastTenWordsView from '../views/LastTenWordsView.vue'

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
      path: '/instructions',
      name: 'instructions',
      component: InstructionsView
    },
    {
      path: '/wordoftheday',
      name: 'wordoftheday',
      component: WordleView
    },
    {
      path: '/last-ten-words',
      name: 'last-ten-words',
      component: LastTenWordsView
    }
  ]
})

export default router
