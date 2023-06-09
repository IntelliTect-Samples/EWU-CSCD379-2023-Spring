export class WordListOptions {
  pageSize: number = 10
  pageNumber: number = 1
  search: string = ''
}

export class WordListItem {
  wordId: number = 0
  text: string = ''
  isCommon: boolean = false
  isUsed: boolean = false
}
