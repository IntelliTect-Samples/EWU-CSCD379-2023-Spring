import { createRouter, createWebHistory } from 'vue-router'
import WordleView from '../views/WordleView.vue'
import InstructionsView from '@/views/InstructionsView.vue'
import LeaderboardView from '../views/LeaderboardView.vue'
import LandingPageView from '@/views/LandingPageView.vue'
import PastTenWordlesView from '@/views/PastTenWordlesView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'landingpage',
      component: LandingPageView
    },
    {
      path: '/wordle',
      name: 'wordle',
      component: WordleView
    },
    {
      path: '/instructions',
      name: 'instructions',
      component: InstructionsView
    },
    {
      path: '/leaderboard',
      name: 'leaderboard',
      component: LeaderboardView
    },
    {
      path: '/wordoftheday',
      name: 'wordoftheday',
      component: WordleView
    },
    {
      path: '/pasttenwordles',
      name: 'pasttenwordles',
      component: PastTenWordlesView
    }
  ]
})

export default router
