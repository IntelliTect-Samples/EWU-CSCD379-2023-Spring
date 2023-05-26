import { createRouter, createWebHistory } from 'vue-router'
import WordleView from '../views/WordleView.vue'
import AboutView from '../views/AboutView.vue'
import HomeView from '../views/HomeView.vue'
import LeaderBoardView from '../views/LeaderBoardView.vue'
import HelpView from '../views/HelpView.vue'
import WordleOfTheDay from '../views/WordleOfTheDay.vue'
//
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/game',
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
      component: LeaderBoardView
    },
    {
      path: '/help',
      name: 'help',
      component: HelpView
    },
    {
      path: '/wordOfTheDay',
      name: 'wordOfTheDay',
      component: WordleOfTheDay
    }
  ]
})

export default router
