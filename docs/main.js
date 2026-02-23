const COLOR_RED    = "#422834";
const COLOR_PURPLE = "#221C28";
const COLOR_GREEN  = "#373828";
const COLOR_YELLOW = "#BBA786";
const COLOR_BLUE   = "#575563";

const REPO_OWNER = 'ivaylolivanov';
const REPO_NAME = 'cs-lessons';
const BRANCH = 'main';
const PATHS_FILE = 'docs/data/readme-paths.txt';

const GITHUB_RAW_URL  = `https://raw.githubusercontent.com/${REPO_OWNER}/${REPO_NAME}/refs/heads/${BRANCH}`;
const GITHUB_BLOB_URL = `https://github.com/${REPO_OWNER}/${REPO_NAME}/blob/${BRANCH}`;

class Node
{
    constructor(topic)
    {
        this.topic = topic;
        this.subtopics = new Map();
        this.examples = [];
        this.readme = "";
    }
};

function createLink(path, text = null)
{
    const a = document.createElement('a');
    a.href = `${GITHUB_BLOB_URL}/${path}`;

    if (text)
        a.textContent = text;
    else
        a.textContent = path;

    return a;
}

async function buildContent(paths)
{
    const contents = new Map();

    for (let path of paths)
    {
        path = path.trim();
        if (!path)
            continue;

        // NOTE: Discard the repo's readme
        const isTopLevelReadme = path.startsWith('README.md');
        if (isTopLevelReadme)
            continue;

        const isReadme = path.endsWith('README.md');
        const isCode   = path.endsWith('.cs');
        if (!isCode && !isReadme)
            console.logError("What are you then!?");

        const parts = path.split('/');
        const topic = parts[0];
        let   subtopic = "";
        if ((parts.length >= 1) && (!parts[1].trim().includes('README')))
            subtopic = parts[1];

        if (topic && !contents.has(topic))
            contents.set(topic, new Node(topic));

        if (subtopic && !contents.get(topic).subtopics.has(subtopic))
            contents.get(topic).subtopics.set(subtopic, new Node(topic));

        if (subtopic && isReadme)
            contents.get(topic).subtopics.get(subtopic).readme = path;
        else if (topic && isReadme)
            contents.get(topic).readme = path;

        if (subtopic && isCode)
            contents.get(topic).subtopics.get(subtopic).examples.push(path);
        else if (topic && isCode)
            contents.get(topic).examples.push(path);
    }

    return contents;
}

function renderPage(content)
{
    const contentDiv = document.getElementById('content');
    contentDiv.innerHTML = "";
    let html = '';

    if (!content || content.length === 0)
    {
        html += '<p>Няма намерени уроци.</p>';
        contentDiv.innerHTML = html;
        return;
    }

    const topicUl = document.createElement('ul');
    for (const item of content)
    {
        const topic = item[0];
        const topicLi = document.createElement('li');
        topicLi.classList.add('capitalize');
        topicLi.classList.add('topic');
        topicLi.textContent = topic;
        topicUl.appendChild(topicLi);

        let subtopicUl = null;
        if ((item[1].subtopics.size > 0) || (item[1].readme))
            subtopicUl = document.createElement('ul');

        if (subtopicUl)
        {
            if (item[1].readme)
            {
                const readmeLi = document.createElement('li');
                const readmeLink = createLink(item[1].readme, "Бележки");
                readmeLi.appendChild(readmeLink)
                subtopicUl.appendChild(readmeLi);
            }

            for (const subitem of item[1].subtopics)
            {
                const li = document.createElement('li');
                li.textContent = subitem[0];
                li.classList.add('capitalize');
                li.classList.add('topic');
                subtopicUl.appendChild(li);

                let examplesUl = null;
                if ((subitem[1].examples.length > 0) || (subitem[1].readme))
                    examplesUl = document.createElement('ul');

                if (examplesUl)
                {
                    if (item[1].subtopics.readme)
                    {
                        const subtopicReadmeLi = document.createElement('li');
                        const subtopicReadmeLink = createLink(item[1].readme, "Бележки");
                        subtopicReadmeLi.appendChild(subtopicReadmeLi);

                        examplesUl.appendChild(subtopicReadmeLi);
                    }

                    let counter = 0;
                    for (const example of subitem[1].examples)
                    {
                        ++counter;
                        const exampleLi = document.createElement('li');

                        const exampleLink = createLink(example, `Пример ${counter}`);
                        exampleLi.appendChild(exampleLink);

                        examplesUl.appendChild(exampleLi);
                    }

                    subtopicUl.appendChild(examplesUl);
                }
            }

            topicUl.appendChild(subtopicUl);
        }

        topicUl.appendChild(subtopicUl);
    }

    contentDiv.appendChild(topicUl);
}

async function main()
{
    const paths_url = `${GITHUB_RAW_URL}/${PATHS_FILE}`;
    const response = await fetch(paths_url);
    if (!response.ok)
    {
        console.logError(`Не може да се зареди ${paths_url} (HTTP ${response.status})`);
        return;
    }

    const text = await response.text();
    const lines = text.split('\n');
    const content = await buildContent(lines);

    renderPage(content);
}

window.addEventListener('DOMContentLoaded', main);
