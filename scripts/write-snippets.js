import { writeFile } from "node:fs/promises";
import { snippetFile } from "./snippet.js";


export async function writeAllSnippets(snippets) {
    const snippetDict = new Map();

    for (const snippet of snippets) {
        if (!snippetDict.has(snippet.language))
            snippetDict.set(snippet.language, []);

        snippetDict.get(snippet.language).push(snippet);
    }

    const promises = [];
    for (const [language, snippets] of snippetDict) {
        promises.push(writeSnippets(snippets, language));
    }
    await Promise.all(promises);
}

export async function writeSnippets(snippets, language) {
    const dataToWrite = {};

    for (const snippet of snippets) {
        dataToWrite[snippet.name] = {
            "prefix": snippet.prefix,
            "description": snippet.description,
            "body": snippet.content
        };
    }

    const stringifiedData = JSON.stringify(dataToWrite, null, "\t");
    await writeFile(snippetFile(language), stringifiedData, "utf8");
}

