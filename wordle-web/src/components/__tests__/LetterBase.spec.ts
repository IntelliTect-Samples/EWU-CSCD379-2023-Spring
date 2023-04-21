import { describe, it, expect } from 'vitest'

import { mount } from '@vue/test-utils'
import LetterBase from '../LetterBase.vue'

describe('LetterBase', () => {
  it('renders properly with defaults', () => {
    const wrapper = mount(LetterBase, { props: {} })
    expect(wrapper.text()).toContain('?')
    expect(wrapper.attributes('color')).toBe('grey')
  })

  it('renders properly with passed params', () => {
    const wrapper = mount(LetterBase, { props: { char: 'a', color: 'blue' } })
    expect(wrapper.text()).toContain('a')
    expect(wrapper.attributes('color')).toBe('blue')
  })
})