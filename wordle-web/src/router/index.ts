import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import WordleView from '../views/WordleView.vue'
import LeaderboardView from '../views/LeaderboardView.vue'
import LastTenWords from '@/views/LastTenWords.vue'
import { Services } from '@/scripts/services'
import { inject } from 'vue'
import { SignInService } from '@/scripts/signInService'
import WordEditor from '@/views/WordEditor.vue'

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
      name: 'leaderboard',
      component: LeaderboardView
    }
    ,
    {
      path: '/lasttenwords',
      name: 'lastTenWords',
      component: LastTenWords
    },
    {
      path: '/worldoftheday',
      name: 'wordOfTheDay',
      component: WordleView
    },
    {
      path: '/wordeditor',
      name: 'wordEditor',
      component: WordEditor,
    }
    ,
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/AboutView.vue'),
      beforeEnter: (to, from, next) => {
        //return SignInService.instance._isSignedIn
        if (SignInService.instance.isSignedIn) next()
        else next({ name: 'wordle' })
      }
    },
    {
      path: '/leaderboard',
      name: 'leaderboard',
      component: () => import('../views/LeaderboardView.vue')
    }
  ]
})

export default router
