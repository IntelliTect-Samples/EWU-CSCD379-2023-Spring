import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import WordleView from '../views/wordleView.vue'
import LeaderboardView from '../views/LeaderboardView.vue'
import InstructionsView from '../views/InstructionsView.vue'

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
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/AboutView.vue')
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
      path: '/instructions',
      name: 'instructions',
      component: InstructionsView
    }
  ]
})

export default router
