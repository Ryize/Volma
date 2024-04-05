# Строительный тренажер

## Описание

**Строительный тренажер** создан для обучения и тренировки навыков в строительстве в **VR**. Эта инновационная виртуальная среда позволяет пользователям не только практиковать разнообразные строительные задачи, но и повышать свой уровень безопасности и профессионализма.

**Цель проекта** - помочь студентам и профессионалам строительной отрасли улучшить свои навыки и подготовиться к реальным ситуациям на стройке. Разработанный на **Unity** с использованием языка **C#**, этот тренажер предлагает захватывающий и эффективный способ обучения, воплощая в себе передовые технологии виртуальной реальности.

Проект представляет собой программное решение с двумя основными вариантами использования: демо-версией и платной полной версией.

1. **Демо-версия:**
   - Доступна бесплатно для всех пользователей.
   - Предназначена для знакомства с основными возможностями продукта.
   - Включает в себя ограниченный набор задач и функциональности, достаточный для первоначального опыта использования.

2. **Платная полная версия:**
   - Предлагает полный набор функций и возможностей продукта.
   - Подходит для пользователей, которым требуется полный спектр инструментов для обучения и тренировки в строительстве.
   - Обычно обеспечивает более широкий функционал, большую производительность и поддержку со стороны разработчиков.
   - Включает в себя дополнительные функции, такие как более сложные строительные сценарии, улучшенные инструменты обратной связи и поддержка пользовательских настроек.
   - Доступ к платной полной версии осуществляется через приобретение лицензии.
  
### Для игры
* Нажмите справа на Release и скачайте нужную версию
* Разархивируйте
* Запустите EXE файл

### Использованные технологии: 

![](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![](https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white)
![](https://img.shields.io/badge/steamvr-1b2838.svg?style=for-the-badge&logo=steam&logoColor=white)
![](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)
![](https://img.shields.io/badge/blender-%23F5792A.svg?style=for-the-badge&logo=blender&logoColor=white)
![](https://img.shields.io/badge/jira-%230A0FFF.svg?style=for-the-badge&logo=jira&logoColor=white)
![](https://img.shields.io/badge/Rider-000000.svg?style=for-the-badge&logo=Rider&logoColor=white&color=black&labelColor=crimson)

## Реализованные возможности в тренажере

### Игрок
- Меню игры для удобного навигации.
- Телепортация по комнате для быстрого перемещения.
- Возможность поворота камеры для обзора окружающего пространства.
- Возможность подбора предметов для выполнения задач.
- Телепортация предметов к игроку для удобства использования.
- Управление меню для настройки параметров и выбора задач.

### Предметы
Разнообразие инструментов и материалов, включая *метлу*, *валик*, *кюветку*, *грунтовку*, *ведро*, *мешок*, *кран*, *миксер*, *шпатель*, *плиту*, *пилу*, *киянку*, *распорку* и *пистолет*.

### Система квестов
#### Подготовка поверхности:
- Нужно взять *метлу* и очистить певерхность от пыли
- Нужно взять *грунотовку* и наполнить *кюветку*
- Нужно взять *валик* и обмакнуть в *кюветку*
- *Валиком* нужно нанести грунтовку на стену
- Грунтовка на *валике* может заканчиваться. Нужно регулярно обмакивать его в *кюветку*
- Нужно дать время грунтовки высохнуть

#### Получение смеси:
- Нужно открыть *кран*, чтобы наполнить *вердо* водой
- Нужно перевернуть и трятси *мешок* с раствором, чтобы наполнить его раствором
- *Ведро* постепенно наполняется водой и раствором
- Вода и раствор может вылиться из *ведра*
- *Ведро* нужно заполнить водой и раствором в нужном соотношении
- Нужно взять *миксер* и опустить в воду и песок, чтобы перемешать смесь
- Появляется оценка смеси (*Отличная*, *Сухая*, *Слишком жидкая*)
- Нужно дать время, чтобы смесь приготовилась

#### Монтаж ПГП:
- Нужно взять *шпатель* и зачерпнуть смесь из *ведра*
- *Шпателем* нужно нанести смесь на подготовленную поверхность
- Подготовить *плиту* (опционально)
    + У *плиты* может быть несколько состояний (*Подходит*, *Можно разрезать*, *Не подходит*, *Мусор*)
    + Нужно взять *пилу* и *плиту* в руки
    + Индикатор показывает правильное место для разреза
    + Нужно провети *пилой* по *плите*, чтобы её разрезать
    + *Плита* получает новое сотояние
- Нужно поставить подходящюю *плиту* на место
- Нужно взять *киянку* и постучать по *плите*, чтобы её закрепить
- В дверном проеме нужно утсановить *распорку*
- Между стеной и потолком будет зазор в 3-5 см
- Нужно взять *пистолет* и залить зазор пеной

### Статистика
- Учет времени, затраченного на работу.
- Отслеживание расхода ресурсов, таких как вода, цемент, смесь, грунтовка и плиты.
- Учет ошибок и неправильных действий (испорченная смесь, выброшенные предметы)
- На осонове полученных данных формируется оценка работы

### Аудио сопровождение
- Звуковое сопровождение для предметов и окружающей среды.
- Включение радио с *оригинальным саундтреком* для создания атмосферы и улучшения игрового опыта.

## Титры
Список участников проекта и их вклад:

- [Свиридов Денис](https://github.com/MrFireDeN) - тимлид и разработка кода.
- [Чекашок Матвей](https://github.com/Ryize) - техлид и разработка кода.
- [Подмосковнов Илья](https://github.com/rokosvlg) - разработка кода и создание 3D моделей.
- [Березовский Петр](https://github.com/8RODOGAST8) - создание 3D моделей и визуальных эффектов (VFX).
- [Сагалаев Михаил](https://github.com/Gissigunth) - дизайн звука.
- [Смолин Кирилл](https://vk.com/iluvatar_eru) - композитор оригинального саундтрека.

Этот разнообразный состав команды обеспечил успешное выполнение всех аспектов проекта, от разработки кода и моделей до звукового оформления и музыкального сопровождения.
