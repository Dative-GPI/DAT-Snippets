import { readdir, readFile } from "node:fs/promises";
import { Snippet, snippetDir, snippetFile } from "./snippet.js";


export async function readAllSnippets() {
    const snippetFilenames = await readdir(snippetDir);
    const snippetLanguageRegex = /^snippers-([a-zA-Z0-9]*).code-snippets$/; // TODO: A verifier

    const snippetArray = [];
    for (const filename of snippetFilenames) {
        const languageMatches = filename.match(snippetLanguageRegex);

        if (!languageMatches || languageMatches.length == 0)
            continue;

        snippetArray.push(...(await readSnippets(languageMatches[0])));
    }

    return snippetArray;
}

export async function readSnippets(language) {
    const data = await readFile(snippetFile(language), "utf8");
    const snippetData = JSON.parse(data.trim() || "{}");

    const snippetArray = [];

    for (const snippetName in snippetData) {
        const snippet = snippetData[snippetName];
        snippetArray.push(new Snippet(
            snippetName,
            snippet.prefix,
            snippet.description,
            language,
            snippet.body
        ));
    }

    return snippetArray;
}