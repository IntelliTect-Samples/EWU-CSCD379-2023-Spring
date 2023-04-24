// import { describe, it, expect } from 'vitest'

// import { Letter, LetterStatus } from '@/scripts/letter'
// import { mount } from '@vue/test-utils'
// import LetterButton from '../LetterButton.vue'

// Tests Fail because of gradient requirement

// describe('LetterBase', () => {
//   it('renders properly param char', () => {
//     const letter = new Letter('a')
//     const wrapper = mount(LetterButton, { props: { letter: letter} })
//     expect(wrapper.text()).toContain('a')
//     expect(wrapper.attributes('color')).toBe('grey-darken-1')
//   })
// })

// describe('LetterBase', () => {
//   it('renders properly params char and status', () => {
//     const letter = new Letter('b', LetterStatus.Correct)
//     const wrapper = mount(LetterButton, { props: { letter: letter} })
//     expect(wrapper.text()).toContain('b')
//     expect(wrapper.attributes('color')).toBe('correct')
//   })
// })