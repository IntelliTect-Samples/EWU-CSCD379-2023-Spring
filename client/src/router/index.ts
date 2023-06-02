import { createRouter, createWebHistory } from 'vue-router'
import HomeViewVue from '@/views/HomeView.vue'
import NoteEditorVue from '@/components/NoteEditor.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeViewVue
    },
    {
      path: '/note-editor',
      name: 'NodeEditor',
      component: NoteEditorVue
    }
  ]
})

export default router
