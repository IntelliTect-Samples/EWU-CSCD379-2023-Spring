import { describe, it, expect } from 'vitest'

import { mount } from '@vue/test-utils'
import LetterBase from '../LetterBase.vue'

describe('LetterBase', () => {
  it('renders properly', () => {
    const wrapper = mount(LetterBase, { props: {  } })
    expect(wrapper.text()).toContain('?')
    expect(wrapper.attributes('color').toBe('grey'))
  })
})