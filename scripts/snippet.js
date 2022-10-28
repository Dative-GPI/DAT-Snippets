export const snippetDir = `./snippets`;
export const snippetFile = (language) => `${snippetDir}/snippets-${language}.code-snippets`;


export class Snippet {
    constructor(
        name = "",
        prefix = "",
        description = "",
        language = "",
        content = []
    )
    {
        this.name = name;
        this.prefix = prefix;
        this.description = description;
        this.language = language;
        this.content = content;
    }
}
