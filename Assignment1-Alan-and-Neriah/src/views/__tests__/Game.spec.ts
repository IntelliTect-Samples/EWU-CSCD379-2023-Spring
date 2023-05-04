import { describe, it, expect } from 'vitest'

import { mount } from '@vue/test-utils'
import Game from '../GameView.vue'

describe('Game', () => {
  it('renders properly', () => {
    const wrapper = mount(Game)
    expect(wrapper.text()).toContain('A Play on Wordle')
  })
})
