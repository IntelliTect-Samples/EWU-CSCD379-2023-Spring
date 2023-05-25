import { createRouter, createWebHistory } from 'vue-router'
import WordleView from '../views/WordleView.vue'
import AboutView from '../views/AboutView.vue'
import LeaderboardView from '../views/LeaderboardView.vue'
import DailyView from '../views/DailyView.vue'
import InstructionView from '../views/InstructionView.vue'
import PreviousView from '../views/PreviousView.vue'
//import IndexView from '../views/IndexView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    /*{
      path: '/',
      name: 'index',
      component: IndexView
    },*/
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
      path: '/dailywordle',
      name: 'dailywordle',
      component: DailyView
    },
    {
      path: '/instructions',
      name: 'instructions',
      component: InstructionView
    },
    {
      path: '/previouswordles',
      name: 'previouswordles',
      component: PreviousView
    }
  ]
})

export default router
