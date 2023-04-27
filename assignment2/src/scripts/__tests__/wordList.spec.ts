import { describe, it, expect } from 'vitest'
import { game } from '@/scripts/wordList'

const main = new game()
describe('wordList', () => {
    it('validTest1', () => {
        let arr = main.validWords('g')
        expect(arr.length).toBe(94)
    })
    it('validTest2', () => {
        let arr = main.validWords('gr')
        expect(arr.length).toBe(34)
    })
    it('validTest3', () => {
        let arr = main.validWords('gre')
        expect(arr.length).toBe(4)
    })
})