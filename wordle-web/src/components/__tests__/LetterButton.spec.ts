import { describe, it, expect } from 'vitest'

import { mount } from '@vue/test-utils'
import LetterButton from '../LetterButton.vue'
import { Letter, LetterStatus } from '@/scripts/letter'

describe('LetterButton', () => {
  it('renders properly', () => {
    const letter = new Letter('a')

    const wrapper = mount(LetterButton, {
      props: { letter },
      global: {
        provide: {
          display: { sm: false, xs: false } // override for useDisplay
        }
      }
    })
    expect(wrapper.text()).toContain('A')
    expect(wrapper.attributes('color')).toBe('darkgrey')
  })

  it('renders properly with passed params', () => {
    const letter = new Letter('a', LetterStatus.Correct)
    const wrapper = mount(LetterButton, { props: { letter: letter } })
    expect(wrapper.text()).toContain('A')
    expect(wrapper.attributes('color')).toBe('correct')
  })
})
