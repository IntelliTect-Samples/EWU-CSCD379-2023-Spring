import { describe, it, expect } from 'vitest'

import { mount } from '@vue/test-utils'
import LetterBase from '../LetterBase.vue'

describe('LetterBase', () => {
  it('renders properly with defaults', () => {
    const wrapper = mount(LetterBase, { props: {} })
    expect(wrapper.text()).toContain('?')
    expect(wrapper.attributes('color')).toBe('grey')
  })

  it('renders properly', () => {
    const wrapper = mount(LetterBase, { props: { char: 'a', color: 'green' } })
    expect(wrapper.text()).toContain('A')
    expect(wrapper.attributes('color')).toBe('green')
  })
})
