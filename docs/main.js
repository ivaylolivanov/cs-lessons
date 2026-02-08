// Конфигурация
const REPO_OWNER = 'ivaylolivanov';
const REPO_NAME = 'cs-lessons';
const GITHUB_API_URL = `https://api.github.com/repos/${REPO_OWNER}/${REPO_NAME}`;

// Държава на приложението
let topics = [];
let selectedTopic = null;

// Функции за работа с GitHub API
async function fetchRepoContents(path = '') {
    try {
        const response = await fetch(`${GITHUB_API_URL}/contents/${path}`);
        if (!response.ok) {
            throw new Error(`Грешка при зареждане: ${response.status}`);
        }
        return await response.json();
    } catch (error) {
        console.error('Грешка при извличане на съдържание:', error);
        showError(`Грешка при зареждане на съдържанието: ${error.message}`);
        return [];
    }
}

async function fetchRepoInfo() {
    try {
        const response = await fetch(GITHUB_API_URL);
        if (!response.ok) {
            throw new Error(`Грешка при зареждане на информация: ${response.status}`);
        }
        return await response.json();
    } catch (error) {
        console.error('Грешка при извличане на информация за хранилището:', error);
        return null;
    }
}

async function fetchReadme(path = '') {
    try {
        const response = await fetch(`${GITHUB_API_URL}/contents/${path}README.md`);
        if (!response.ok) {
            // Ако няма README.md, връщаме празно съдържание
            return '';
        }
        const data = await response.json();
        // Декодираме base64 съдържанието
        return atob(data.content);
    } catch (error) {
        console.error('Грешка при извличане на README:', error);
        return '';
    }
}

// Функции за обработка на данни
function extractTopicsFromStructure(contents) {
    return contents
        .filter(item => item.type === 'dir' && !item.name.startsWith('.') && item.name !== 'data')
        .map(topic => ({
            name: topic.name,
            path: topic.path,
            displayName: formatTopicName(topic.name),
            lessons: []
        }));
}

function formatTopicName(topicName) {
    // Преобразуване на имената на теми в по-четлив формат
    const nameMap = {
        'introduction': 'Въведение в C#',
        'loops': 'Цикли',
        'arrays': 'Масиви',
        'homework-example': 'Примерна домашна',
        'first-term-review': 'Преговор за първи срок'
    };
    
    if (nameMap[topicName]) {
        return nameMap[topicName];
    }
    
    // Ако няма специфично име, форматираме го
    return topicName
        .split('-')
        .map(word => word.charAt(0).toUpperCase() + word.slice(1))
        .join(' ');
}

// Функции за рендериране
function renderTopicsList() {
    const topicsList = document.getElementById('topics-list');
    
    if (topics.length === 0) {
        topicsList.innerHTML = `
            <li class="no-content">
                <p>Не са намерени теми.</p>
            </li>
        `;
        return;
    }
    
    topicsList.innerHTML = topics.map(topic => `
        <li class="topic-item ${selectedTopic && selectedTopic.name === topic.name ? 'active' : ''}" 
            onclick="selectTopic('${topic.name}')">
            <div class="topic-name">${topic.displayName}</div>
            <div class="lesson-count">${topic.lessons.length} урока</div>
        </li>
    `).join('');
}

async function selectTopic(topicName) {
    const topic = topics.find(t => t.name === topicName);
    if (!topic) return;
    
    selectedTopic = topic;
    renderTopicsList();
    
    // Показваме съдържанието на урока
    await renderTopicContent(topic);
}

async function renderTopicContent(topic) {
    const container = document.getElementById('lesson-content-container');
    const loadingElement = document.getElementById('initial-loading');
    
    if (loadingElement) {
        loadingElement.style.display = 'none';
    }
    
    // Зареждаме README файла на темата
    const readmeContent = await fetchReadme(topic.path + '/');
    
    container.innerHTML = `
        <div class="lesson-content active">
            <h2 class="lesson-title">${topic.displayName}</h2>
            
            ${readmeContent ? `
                <div class="lesson-description">
                    ${renderMarkdown(readmeContent)}
                </div>
            ` : `
                <p class="no-content">Тази тема все още няма описание.</p>
            `}
            
            <div class="lesson-files">
                <h3 class="files-title"><i class="fas fa-file-code"></i> Уроци в тази тема</h3>
                
                ${topic.lessons.length > 0 ? `
                    <ul class="file-list">
                        ${topic.lessons.map(lesson => `
                            <li class="file-item">
                                <i class="fas fa-folder"></i>
                                <a href="https://github.com/${REPO_OWNER}/${REPO_NAME}/tree/main/${lesson.path}" 
                                   class="file-link" target="_blank">
                                    ${lesson.name}
                                </a>
                                <a href="https://github.com/${REPO_OWNER}/${REPO_NAME}/archive/refs/heads/main.zip" 
                                   class="file-download" title="Изтегляне">
                                    <i class="fas fa-download"></i>
                                </a>
                            </li>
                        `).join('')}
                    </ul>
                ` : `
                    <p class="no-content">Все още няма уроци в тази тема.</p>
                `}
            </div>
        </div>
    `;
}

function renderMarkdown(content) {
    // Проста обработка на Markdown за показване на HTML
    return content
        .replace(/^# (.*$)/gim, '<h3>$1</h3>')
        .replace(/^## (.*$)/gim, '<h4>$1</h4>')
        .replace(/^### (.*$)/gim, '<h5>$1</h5>')
        .replace(/\*\*(.*)\*\*/gim, '<strong>$1</strong>')
        .replace(/\*(.*)\*/gim, '<em>$1</em>')
        .replace(/!\[(.*?)\]\((.*?)\)/gim, '<img alt="$1" src="$2">')
        .replace(/\[(.*?)\]\((.*?)\)/gim, '<a href="$2" target="_blank">$1</a>')
        .replace(/\n/gim, '<br>')
        .replace(/```([\s\S]*?)```/gim, '<pre class="code-snippet"><code>$1</code></pre>');
}

function showError(message) {
    const container = document.getElementById('lesson-content-container');
    const loadingElement = document.getElementById('initial-loading');
    
    if (loadingElement) {
        loadingElement.style.display = 'none';
    }
    
    container.innerHTML = `
        <div class="error-message">
            <h3><i class="fas fa-exclamation-triangle"></i> Грешка</h3>
            <p>${message}</p>
            <p>Моля, опитайте отново по-късно или проверете връзката с интернет.</p>
        </div>
    `;
}

// Основна функция за инициализация
async function initializeApp() {
    try {
        // Зареждаме информация за хранилището
        const repoInfo = await fetchRepoInfo();
        if (repoInfo) {
            const updatedAt = new Date(repoInfo.updated_at).toLocaleDateString('bg-BG', {
                year: 'numeric',
                month: 'long',
                day: 'numeric',
                hour: '2-digit',
                minute: '2-digit'
            });
            document.getElementById('last-updated').textContent = updatedAt;
        }
        
        // Зареждаме съдържанието на хранилището
        const contents = await fetchRepoContents();
        
        // Извличаме темите
        topics = extractTopicsFromStructure(contents);
        
        // Зареждаме уроците за всяка тема
        for (const topic of topics) {
            const topicContents = await fetchRepoContents(topic.path);
            if (topicContents && Array.isArray(topicContents)) {
                topic.lessons = topicContents
                    .filter(item => item.type === 'dir' && !item.name.startsWith('.'))
                    .map(lesson => ({
                        name: lesson.name,
                        path: lesson.path
                    }));
            }
        }
        
        // Рендерираме списъка с теми
        renderTopicsList();
        
        // Ако има поне една тема, избираме първата
        if (topics.length > 0) {
            await selectTopic(topics[0].name);
        } else {
            document.getElementById('initial-loading').style.display = 'none';
            document.getElementById('lesson-content-container').innerHTML = `
                <div class="no-content">
                    <h3>Няма налични теми</h3>
                    <p>Все още няма теми в това хранилище.</p>
                </div>
            `;
        }
    } catch (error) {
        console.error('Грешка при инициализация:', error);
        showError(`Грешка при инициализация на приложението: ${error.message}`);
    }
}

// Стартиране на приложението при зареждане на страницата
document.addEventListener('DOMContentLoaded', initializeApp);

// Експорт на функциите, които трябва да са достъпни глобално
window.selectTopic = selectTopic;