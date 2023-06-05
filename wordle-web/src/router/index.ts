import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import WordleView from '../views/WordleView.vue'
import AboutView from '../views/AboutView.vue'
import LeaderboardView from '@/views/LeaderboardView.vue'
import WordOfTheDayView from '@/views/WordOfTheDayView.vue'
import InstructView from '../views/InstructView.vue'
import EditorView from '../views/EditorView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
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
      component: WordOfTheDayView
    },
    {
      path: '/wordle',
      name: 'wordle',
      component: WordleView
    },
    {
      path: '/instruct',
      name: 'instructions',
      component: InstructView
    },
    {
      path: '/editor',
      name: 'editor',
      component: EditorView
    }
  ]
})

export default router
