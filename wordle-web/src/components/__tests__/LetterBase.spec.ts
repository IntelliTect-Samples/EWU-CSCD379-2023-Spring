import { describe, it, expect } from 'vitest'

import { mount } from '@vue/test-utils'
import LetterBase  from '../LetterBase.vue'

describe('LetterBase', () => {
  it('renders properly with defaults', () => {
    const wrapper = mount(LetterBase, { props: {  },})
    expect(wrapper.attributes('color')).toBe('grey')
    expect(wrapper.text()).toBe('A')
  })
})