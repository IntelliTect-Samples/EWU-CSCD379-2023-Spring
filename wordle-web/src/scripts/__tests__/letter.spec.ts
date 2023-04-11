import { describe, expect, it } from "vitest";
import { Letter, LetterStatus } from "@/scripts/letter";

describe('Letter',() => {
  it('Gets Correct Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Correct;
    expect(letter.color).toBe('green')
  })
    it('Gets Misplaced Color', () => {
      const letter = new Letter('a')
      letter.status = LetterStatus.Misplaced;
      expect(letter.color).toBe('orange')
    })
})
