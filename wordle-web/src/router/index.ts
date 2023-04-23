import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import Wordle from '@/views/WordleView.vue'
import AboutView from '@/views/AboutView.vue'
import GameView from '@/views/GameView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'Home',
      component: HomeView
    },
    {
      //better format
      path: '/wordle',
      name: 'wordle',
      component: Wordle
    },
    {
      path: '/about',
      name: 'about',
      component: AboutView
    },
    {
      path: '/game',
      name: 'game',
      component: GameView
    }
  ]
})

export default router
