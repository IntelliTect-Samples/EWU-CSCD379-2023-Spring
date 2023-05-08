import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import WordleView from '../views/WordleView.vue'
import LeaderBoardView from '../views/LeaderBoardView.vue'

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
      path: '/leaderboard',
      name: 'about',
      component: LeaderBoardView
    }
  ]
})

export default router
