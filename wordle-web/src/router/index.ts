import { createRouter, createWebHistory } from 'vue-router'
import WordleView from '../views/WordleView.vue'
import AboutView from '../views/AboutView.vue'
import LeaderboardView from '../views/LeaderboardView.vue'
import InstructionsViewVue from '@/views/InstructionsView.vue'
import DailyView from '@/views/DailyView.vue'
import StatsView from '@/views/StatsView.vue'

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
      name: 'wordoftheday',
      component: DailyView
    },
    {
      path: '/instructions',
      name: 'instructions',
      component: InstructionsViewVue
    },
    {
      path: '/stats',
      name: 'stats',
      component: StatsView
    }
  ]
})

export default router
