import * as path from "node:path";


export const packageJsonPath = "./package.json";

export const configPath = "./templates/templates.json";
export const templateFile = (templatePath) => path.join("./templates", templatePath); 

export class ConfigItem {
    constructor(
        name,
        prefix,
        description,
        language,
        template
    ) {
        this.name = name;
        this.prefix = prefix;
        this.description = description;
        this.language = language;
        this.template = template;
    }
}