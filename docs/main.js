const REPO_OWNER = 'ivaylolivanov';
const REPO_NAME = 'cs-lessons';
const BRANCH = 'main';
const PATHS_FILE = 'docs/data/readme-paths.txt';

const GITHUB_RAW_URL  = `https://raw.githubusercontent.com/${REPO_OWNER}/${REPO_NAME}/refs/heads/${BRANCH}`;
const GITHUB_BLOB_URL = `https://github.com/${REPO_OWNER}/${REPO_NAME}/blob/${BRANCH}`;

async function buildContent(paths)
{
    const topicMap = new Map();

    for (let path of paths)
    {
        path = path.trim();
        if (!path)
            continue;

        if (!path.endsWith('README.md'))
            continue;

        const parts = path.split('/');
        const isRootReadme = parts.length === 1;

        if (isRootReadme)
            continue;

        const lessonUrl = `${GITHUB_RAW_URL}/${path}`;
        const lessonDataResponse = await fetch(lessonUrl);
        if (!lessonDataResponse.ok)
        {
            console.logError(`Lesson at ${lessonUrl} is not accessible`);
            return;
        }

        const lesson = await lessonDataResponse.text();
        if (!lesson)
        {
            console.logError(`Lesson at ${lessonUrl} is not accessible`);
            return;
        }

        const lessonTopic = lesson.split('\n')[0].slice(2);

        if (!topicMap.has(lessonTopic))
        {
            topicMap.set(lessonTopic, {
                name: lessonTopic,
                path: lessonTopic,
                readme: path,
            });
        }
    }

    return Array.from(topicMap.values()).sort((a, b) => a.name.localeCompare(b.name));
}

function renderHomepage(structure)
{
    const contentDiv = document.getElementById('content');
    let html = '';

    if (!structure || structure.length === 0) {
        html += '<p>Няма намерени уроци.</p>';
    }
    else
    {
        html += '<ul>';
        for (const topic of structure)
        {
            const topicReadmeLink = topic.readme
                  ? `<a href="${GITHUB_BLOB_URL}/${topic.readme}" target="_blank">${topic.name}</a>`
                  : `<span>${topic.name}</span>`;

            html += `<li class="topic">${topicReadmeLink}`;

            html += '</li>';
        }

        html += '</ul>';
    }

    contentDiv.innerHTML = html;
}

async function main() {
    const paths_url = `${GITHUB_RAW_URL}/${PATHS_FILE}`;
    const response = await fetch(paths_url);
    if (!response.ok) {
        console.logError(`Не може да се зареди ${paths_url} (HTTP ${response.status})`);
        return;
    }

    const text = await response.text();
    const lines = text.split('\n');
    const content = await buildContent(lines);

    renderHomepage(content);
}

window.addEventListener('DOMContentLoaded', main);
