import { createRouter, createWebHistory } from 'vue-router'
import WordleView from '../views/WordleView.vue'
import AboutView from '../views/AboutView.vue'
import LeaderboardView from '../views/LeaderboardView.vue'
import InstructionsView from '../views/InstructionsView.vue'
import StatisticsView from '../views/StatisticsView.vue'
import LandingPageView from '../views/LandingPageView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/wordle',
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
      path: '/statistics',
      name: 'statistics',
      component: StatisticsView
    },
    {
      path: '/wordoftheday',
      name: 'wordOfTheDay',
      component: WordleView
    },
    {
      path: '/',
      name: 'landingpage',
      component: LandingPageView
    }
  ]
})

export default router
