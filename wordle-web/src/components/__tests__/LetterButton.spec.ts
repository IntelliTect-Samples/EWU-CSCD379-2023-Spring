import { describe, it, expect } from 'vitest'

import { mount } from '@vue/test-utils'
import LetterButton from '../LetterButton.vue'
import { LetterStatus, Letter } from '@/scripts/letter'

describe('LetterButton', () => {
  it('renders properly', () => {
    const testLetter = new Letter('a')
    const wrapper = mount(LetterButton, { props: { letter: testLetter } })
    expect(wrapper.text()).toContain('A')
    expect(wrapper.attributes('color')).toBe('grey')
  })
  it('renders properly with passed params', () => {
    const testLetter = new Letter('b', LetterStatus.Correct)
    const wrapper = mount(LetterButton, { props: { letter: testLetter } })
    expect(wrapper.text()).toContain('B')
    expect(wrapper.attributes('color')).toBe('green')
  })
})
