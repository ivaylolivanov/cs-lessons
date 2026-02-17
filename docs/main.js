const REPO_OWNER = 'ivaylolivanov';
const REPO_NAME = 'cs-lessons';
const BRANCH = 'main';
const PATHS_FILE = 'data/readme-paths.txt';

const GITHUB_BLOB_URL = `https://github.com/${REPO_OWNER}/${REPO_NAME}/blob/${BRANCH}`;

function buildStructure(paths) {
    const topicMap = new Map();

    for (let p of paths) {
        p = p.trim();
        if (!p) continue;
        if (!p.endsWith('README.md')) continue;

        const parts = p.split('/');
        const isRootReadme = parts.length === 1;

        if (isRootReadme) {
            continue;
        }

        const topicName = parts[0];
        const isTopicReadme = parts.length === 2 && parts[1] === 'README.md';

        if (!topicMap.has(topicName)) {
            topicMap.set(topicName, {
                name: topicName,
                path: topicName,
                readme: null,
                lessons: []
            });
        }

        const topic = topicMap.get(topicName);

        if (isTopicReadme) {
            topic.readme = p;
        } else if (parts.length > 2 && parts[parts.length-1] === 'README.md') {
            const lessonName = parts[1];
            const exists = topic.lessons.some(lesson => lesson.name === lessonName);
            if (!exists) {
                topic.lessons.push({
                    name: lessonName,
                    path: p.replace(/\/README\.md$/, ''),
                    readme: p
                });
            }
        }
    }

    return Array.from(topicMap.values()).sort((a, b) => a.name.localeCompare(b.name));
}

function renderHomepage(structure) {
    const contentDiv = document.getElementById('content');
    let html = '<h2>📂 Теми и уроци</h2>';

    if (!structure || structure.length === 0) {
        html += '<p>Няма намерени уроци.</p>';
    } else {
        html += '<ul>';
        for (const topic of structure) {
            const topicReadmeLink = topic.readme
                  ? `<a href="${GITHUB_BLOB_URL}/${topic.readme}" target="_blank">📄 ${topic.name}</a>`
                  : `<span>📁 ${topic.name}</span>`;

            html += `<li class="topic">${topicReadmeLink} <span class="path">(${topic.path}/)</span>`;

            if (topic.lessons.length > 0) {
                topic.lessons.sort((a, b) => a.name.localeCompare(b.name));
                html += '<ul>';
                for (const lesson of topic.lessons) {
                    html += `<li class="lesson">📘 <a href="${GITHUB_BLOB_URL}/${lesson.readme}" target="_blank">${lesson.name}</a> <span class="path">(${lesson.path}/)</span></li>`;
                }
                html += '</ul>';
            }
            html += '</li>';
        }
        html += '</ul>';
    }

    html += `<hr><p>🔗 <a href="${GITHUB_BLOB_URL}/README.md" target="_blank">Виж основния README на хранилището</a></p>`;

    contentDiv.innerHTML = html;
}

async function main() {
    try {
        const paths_url = `${GITHUB_BLOB_URL}/${PATHS_FILE}`;
        const response = await fetch(paths_url);
        if (!response.ok) {
            throw new Error(`Не може да се зареди ${paths_url} (HTTP ${response.status})`);
        }
        const text = await response.text();
        const lines = text.split('\n');
        const structure = buildStructure(lines);
        renderHomepage(structure);
    } catch (error) {
        console.error(error);
        document.getElementById('content').innerHTML = `<div class="error">❌ Грешка: ${error.message}</div>`;
    }
}

window.addEventListener('DOMContentLoaded', main);
