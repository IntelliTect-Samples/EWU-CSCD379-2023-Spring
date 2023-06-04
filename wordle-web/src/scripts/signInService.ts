import Axios from 'axios'

class WordleToken {
  random: string = ''
  userId: string = ''
  userName: string = ''
  aud: string = ''
  exp: number = 0
  'http://schemas.microsoft.com/ws/2008/06/identity/claims/role': string[] = []
  iss: string = ''
  jti: string = ''
  sub: string = ''
  get roles(): string[] {
    return this['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']
  }
}

export class SignInService {
  private _rawToken: string | null = null
  private _token: WordleToken = new WordleToken()
  private _isSignedIn: boolean = false
  private static _instance = new SignInService()
  private _tokenLocalStorageKey = 'token'

  private constructor() {
    this.setToken(localStorage.getItem(this._tokenLocalStorageKey))
  }

  public async signInAsync(username: string, password: string): Promise<boolean> {
    try {
      const result = await Axios.post('Token/GetToken', {
        username: username,
        password: password
      })
      this.setToken(result.data.token)
      // Axios.get('Token/TestAdmin').then((result) => {
      //   console.log(result)
      // })
      this._isSignedIn = true
      return true
    } catch (err) {
      console.log(`Login failed: ${err}`)
      this.signOut()
      return false
    }
  }

  public signOut() {
    this.setToken(null)
  }

  public get isSignedIn() {
    return this._isSignedIn
  }

  private setToken(token: string | null) {
    if (!token) {
      // Clear the token
      this._token = new WordleToken()
      this._isSignedIn = false
      this._rawToken = ''
      localStorage.setItem(this._tokenLocalStorageKey, '')
    } else {
      // Set the token
      this._rawToken = token
      localStorage.setItem(this._tokenLocalStorageKey, this._rawToken)
      this._isSignedIn = true
      Axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
      const parts = token.split('.')
      const payload = JSON.parse(window.atob(parts[1]))
      this._token = Object.assign(new WordleToken(), payload)
    }
  }

  public get rawToken(): string | null {
    return this._rawToken
  }

  public get token(): WordleToken {
    return this._token
  }

  public static get instance(): SignInService {
    return SignInService._instance
  }
}