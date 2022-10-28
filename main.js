import { readConfig, resolveAllSnippets } from "./scripts/read-config.js";
import { writeAllSnippets } from "./scripts/write-snippets.js";

const config = await readConfig();
const snippets = await resolveAllSnippets(config);
await writeAllSnippets(snippets);
