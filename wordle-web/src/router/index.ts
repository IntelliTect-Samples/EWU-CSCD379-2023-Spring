import { createRouter, createWebHistory } from 'vue-router'
import WordleView from '../views/WordleView.vue'
import AboutView from '../views/AboutView.vue'
import LeaderboardView from '@/views/LeaderboardView.vue'
import WordOfTheDayView from '@/views/WordOfTheDayView.vue'
import WordEditor from '@/views/WordEditor.vue'
import { SignInService } from '@/scripts/signInService'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'wordle',
      component: WordleView
    },
    {
      path: '/about',
      name: 'about',
      component: AboutView,
      beforeEnter: (to, from, next) => {
        //return SignInService.instance._isSignedIn
        if (SignInService.instance.isSignedIn) next()
        else next({ name: 'wordle' })
      }
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
      path: '/wordEditor',
      name: 'wordEditor',
      component: WordEditor
    }
  ]
})

export default router
