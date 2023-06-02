export class ListWord {
  text: string = ''
  isCommon: boolean = false

  constructor(text: string, isCommon: boolean) {
    this.text = text
    this.isCommon = isCommon
  }
}
