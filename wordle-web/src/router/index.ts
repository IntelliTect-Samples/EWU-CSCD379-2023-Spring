import { createRouter, createWebHistory } from 'vue-router'
import WordleView from '../views/WordleView.vue'
import AboutView from '../views/AboutView.vue'
import LeaderboardView from '../views/LeaderboardView.vue'
import LandingPageView from '../views/LandingPageView.vue'
import HowToPlayViewVue from '@/views/HowToPlayView.vue'
import DailyWordListView from '../views/DailyWordListView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'welcome',
      component: LandingPageView
    },
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
      path: '/howtoplay',
      name: 'howtoplay',
      component: HowToPlayViewVue
    },
    {
      path: '/leaderboard',
      name: 'leaderboard',
      component: LeaderboardView
    },
    {
      path: '/dailywordlist',
      name: 'dailywordlist',
      component: DailyWordListView
    },
    {
      path: '/wordOfTheDay',
      name: 'wordoftheday',
      component: WordleView
    }
  ]
})

export default router
