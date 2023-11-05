/* 
---------------------------------------------
Натискання на Training Studio
--------------------------------------------- 
*/

document.addEventListener("DOMContentLoaded", function() {
    // Знаходимо елемент "Training Studio" за його ідентифікатором
    var topLink = document.getElementById("top-link");

// Додаємо обробник кліку
topLink.addEventListener("click", function(e) {
    e.preventDefault(); // Відміна стандартної дії переходу за посиланням

// Перехід на верх сторінки
window.scrollTo(0, 0);
    });
});

/* 
---------------------------------------------
Заняття (classes)
--------------------------------------------- 
*/

function showTab(tabId) {
    // Hide all articles in tabs-content
    var articles = document.querySelectorAll('.tabs-content article');
    articles.forEach(function (article) {
        article.style.display = 'none';
    });

    // Show the selected tab
    var selectedTab = document.getElementById(tabId);
    if (selectedTab) {
        selectedTab.style.display = 'block';
    }
}

/* 
---------------------------------------------
Відображення тренерів
--------------------------------------------- 
*/

// Отримайте всі елементи тренерів
const trainerItems = document.querySelectorAll('.trainer-item');

// Отримайте кнопки "Назад" і "Вперед"
const prevButton = document.getElementById('prevTrainer');
const nextButton = document.getElementById('nextTrainer');

// Індекс поточної сторінки і кількість тренерів, які відображаються одночасно
let currentPage = 0;
const trainersPerPage = 3;

// Функція для відображення тренерів згідно поточної сторінки
function showTrainers() {
    trainerItems.forEach((item, index) => {
        if (index >= currentPage * trainersPerPage && index < (currentPage + 1) * trainersPerPage) {
            item.style.display = 'block';
        } else {
            item.style.display = 'none';
        }
    });
}

// Обробник для кнопки "Вперед"
nextButton.addEventListener('click', () => {
    if (currentPage < trainerItems.length / trainersPerPage - 1) {
    currentPage++;
showTrainers();
    }
});

// Обробник для кнопки "Назад"
prevButton.addEventListener('click', () => {
    if (currentPage > 0) {
    currentPage--;
showTrainers();
    }
});

// Початкове відображення тренерів
showTrainers();


/*
---------------------------------------------

--------------------------------------------- 
*/