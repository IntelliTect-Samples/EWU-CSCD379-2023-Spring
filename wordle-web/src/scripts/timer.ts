import { ref } from 'vue';

export class Timer {
  minutes = ref<number>(0);
  seconds = ref<number>(0);
  timerId?: NodeJS.Timeout | undefined;

  constructor(initialSeconds = 0, initialMinutes = 0) {
    this.seconds.value = initialSeconds;
    this.minutes.value = initialMinutes;
  }


  get formattedMinutes() {
    return this.minutes.value < 10 ? '0' + this.minutes.value : this.minutes.value.toString();
  }

  get formattedSeconds() {
    return this.seconds.value < 10 ? '0' + this.seconds.value : this.seconds.value.toString();
  }

  startTimer() {
    if (this.timerId) {
      return;
    }
    this.timerId = setInterval(() => {
      if (this.seconds.value === 59) {
        this.minutes.value++;
        this.seconds.value = 0;
      } else {
        this.seconds.value++;
      }
    }, 1000);
  }

  stopTimer() {
    if (this.timerId) {
      clearInterval(this.timerId);
      this.timerId = undefined;
    }
  }
}