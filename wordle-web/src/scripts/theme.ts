export class Theme{
    name: string
    colors: Array<string>

    constructor(name?: string | undefined, colors?: Array<string> | undefined){
        this.name = name ?? 'default'
        this.colors = colors ?? ['grey', 'green', 'orange', 'red']
    }
}