import { createRouter, createWebHistory } from 'vue-router'
import WordleView from '../views/WordleView.vue'
import AboutView from '../views/AboutView.vue'
import LeaderboardView from '../views/LeaderboardView.vue'
import PreviousWordles from '../views/PreviousWordles.vue'
import HowToPlay from '../views/HowToPlay.vue'
import LandingPage from '../views/LandingPage.vue'

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
      path: '/previouswordles',
      name: 'previouswordles',
      component: PreviousWordles
    },
    {
      path: '/wordoftheday',
      name: 'wordoftheday',
      component: WordleView
    },
    {
      path: '/howtoplay',
      name: 'howtoplay',
      component: HowToPlay
    },
    {
      path: '/',
      name: 'landingpage',
      component: LandingPage
    }
  ]
})

export default router
