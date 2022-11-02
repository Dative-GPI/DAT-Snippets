# Dat'Snippets

## What's in the folder

* This folder contains all of the files necessary to create our snippets.
* `package.json` - this is the manifest file that defines the location of the snippet files and specifies the language of the snippets.
* `snippets/*.code-snippets` - the files containing all snippets.

## Get up and running straight away

* Press `F5` to open a new window with your extension loaded.
* Create a new file with a file name suffix matching your language.
* Verify that your snippets are proposed on IntelliSense.

## Make changes

* You can relaunch the extension from the debug toolbar after making changes to the files listed above.
* You can also reload (`Ctrl+R` or `Cmd+R` on Mac) the VS Code window with your extension to load your changes.

## Generate snippets from templates

* Add your templates to the *templates* folder.
* Update the *templates.json* file to add your new template.
* Generate snippets using the `npm run generate` command.
* All snippets in the *templates.json* file will be generated.

## Install your extension

* To start using your extension with Visual Studio Code copy it into the `<user home>/.vscode/extensions` folder and restart Code.
* *Note:* only the *package.json* file and the *snippets* folder are actually necessary.
* To share your extension with the world, read on https://code.visualstudio.com/docs about publishing an extension.
