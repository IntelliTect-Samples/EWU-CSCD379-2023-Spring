import { describe, it, expect } from 'vitest'

import { mount } from '@vue/test-utils'
import { Letter, letterStatus } from '../letter'

describe('Letter', () => {
  it('Gets Correct Color', () => {
    const letter = new Letter('a')
    letter.status = letterStatus.Correct
    expect(letter.color).toBe('green')
  })
})
