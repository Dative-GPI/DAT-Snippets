const fs = require('node:fs');
const readline = require('readline');

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

const snippetFile = (language) => `./snippets/snippets-${language}.code-snippets`;

let snippetName;
let snippetPrefix;
let snippetDescription;
let snippetLanguage;

let fileToTransform;
let fileData;

let snippetsData;


// Maybe use commander or yargs to make all of this cleaner
function checkForTemplateArg() {
    const templateArgIndex = process.argv.indexOf("--template");
    if (templateArgIndex >= 0 && process.argv.length > templateArgIndex + 1) {
        fileToTransform = process.argv[templateArgIndex + 1];
    }
}

function checkForNameArg() {
    const templateArgIndex = process.argv.indexOf("--name");
    if (templateArgIndex >= 0 && process.argv.length > templateArgIndex + 1) {
        fileToTransform = process.argv[templateArgIndex + 1];
    }
}


function askForSnippetName() {
    return new Promise((res, rej) => {
        rl.question("Enter your snippet's name: ", name => {
            snippetName = name;
            res();
        });
    });
}

function askForSnippetPrefix() {
    return new Promise((res, rej) => {
        rl.question("Enter your snippet's prefix (leave empty to keep the existing one): ", prefix => {
            snippetPrefix = prefix;
            res();
        });
    });
}

function askForSnippetDescription() {
    return new Promise((res, rej) => {
        rl.question("Enter your snippet's description (leave empty to keep the existing one): ", desc => {
            snippetDescription = desc;
            res();
        });
    });
}

function askForSnippetLanguage() {
    return new Promise((res, rej) => {
        rl.question("Enter your snippet's language: ", lang => {
            snippetLanguage = lang;
            res();
        });
    });
}

function askForPath() {
    return new Promise((res, rej) => {
        if (!!fileToTransform) res(fileToTransform);
        else {
            rl.question('Enter the path to the file to convert to a snippet: ', path => {
                fileToTransform = path;
                res(path);
            });
        }
    });
}

function readFile() {
    return new Promise((res, rej) => {
        fs.readFile(fileToTransform, "utf8", (err, data) => {
            if (!!err) rej(err); // File does not exist
            else {
                fileData = data;
                res();
            }
        });
    });
}

function readSnippets() {
    return new Promise((res, rej) => {
        fs.readFile(snippetFile(snippetLanguage), "utf8", (err, data) => {
            if (!!err) { // File does not exist (yet!)
                snippetsData = {};
                res();
            }
            else {
                snippetsData = JSON.parse(data.trim() || "{}");
                res();
            }
        })
    });
}

function generateSnippets() {
    return new Promise((res, rej) => {
        const dataToWrite = { ...snippetsData };
        dataToWrite[snippetName] = {
            "prefix": snippetPrefix.trim() || dataToWrite[snippetName]?.prefix || "",
            "description": snippetDescription || dataToWrite[snippetName]?.description || "",
            "body": fileData.split("\n")
        };

        const stringifiedData = JSON.stringify(dataToWrite, null, "\t");

        fs.writeFile(snippetFile(snippetLanguage), stringifiedData, "utf8", (err, result) => {
            if (err) rej(err);
            else res();
        });
    })
}

function gracefulExit() {
    console.log("Snippet generated");
    process.exit();
}

function handleError(error) {
    console.log(error);
    process.exit(1);
}

checkForTemplateArg();
askForSnippetName()
    .then(askForSnippetPrefix, handleError)
    .then(askForSnippetDescription, handleError)
    .then(askForSnippetLanguage, handleError)
    .then(askForPath, handleError)
    .then(readFile, handleError)
    .then(readSnippets, handleError)
    .then(generateSnippets, handleError)
    .then(gracefulExit, handleError);