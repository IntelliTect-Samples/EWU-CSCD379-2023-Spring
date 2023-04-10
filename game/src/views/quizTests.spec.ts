import {describe, it, expect} from 'vitest'
import game from '@/views/game.vue'
import { mount } from '@vue/test-utils';

describe('MyComponent', () => {
    it('checks to see if correct question is displayed',  () => {
      const wrapper = mount(game);
  
      const question = wrapper.find('h2').text();
    
      expect(question).toContain('What is the state bird of WA state?');
    });
});