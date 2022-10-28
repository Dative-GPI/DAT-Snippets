import { readFile } from "node:fs/promises";
import { ConfigItem, configPath, templateFile } from "./config.js";
import { Snippet } from "./snippet.js";


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

