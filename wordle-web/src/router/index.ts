import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import WordleView from '../views/WordleView.vue'
import DescriptionView from '../views/DescriptionView.vue'
import WordDay from '@/views/WordDay.vue'

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
      path: '/description',
      name: 'description',
      component: DescriptionView
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
      path: '/leaderBoard',
      name: 'leaderBoard',
      component: () => import('../views/LeaderBoard.vue')
    },
    {
      path: '/days',
      name: 'LastTenDays',
      component: () => import('../views/DaysView.vue')
    },
    {
      path: '/wordoftheday',
      name: 'wordoftheday',
      component: WordDay
    },
    {
      path: '/pastwordoftheday',
      name: 'pastwordoftheday',
      component: WordDay
    }
  ]
})

export default router
