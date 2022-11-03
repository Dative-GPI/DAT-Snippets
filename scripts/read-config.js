import { readFile, writeFile } from "node:fs/promises";
import { ConfigItem, configPath, packageJsonPath, templateFile } from "./config.js";
import { Snippet, snippetFile } from "./snippet.js";


export async function readConfig() {
    const data = await readFile(configPath, "utf8");
    const templatesData = JSON.parse(data || "[]");

    var config = [];
    for (const item of templatesData) {
        config.push(new ConfigItem(
            item.name, item.prefix, item.description, item.language, item.template
        ));
    }
    return config;
}


export async function resolveAllSnippets(configItems) {
    var promises = [];
    for (const item of configItems) {
        promises.push(resolveSnippet(item));
    }
    return await Promise.all(promises);
}


export async function resolveSnippet(configItem) {
    const templateBody = await readFile(templateFile(configItem.template), "utf8");

    return new Snippet(
        configItem.name,
        configItem.prefix,
        configItem.description,
        configItem.language,
        templateBody.split("\n")
    )
}


export async function updatePackageJson(snippets) {
    const data = await readFile(packageJsonPath, "utf8");
    const packageData = JSON.parse(data);

    const languageSet = new Set();
    for (const snippet of snippets) {
        languageSet.add(snippet.language);
    }

    const snippetsSection = [];
    for (const language of languageSet) {
        snippetsSection.push({ language: language, path: snippetFile(language) });
    }

    packageData["contributes"]["snippets"] = snippetsSection;
    
    const stringifiedData = JSON.stringify(packageData, null, "\t");
    await writeFile(packageJsonPath, stringifiedData, "utf8");
}

