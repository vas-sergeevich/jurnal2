
# ЭЛЕКТРОННЫЙ ЖУРНАЛ

## Руководство по настройке сервера

### Установка

Для установки сервера необходимо следующее:

- Скачать сервер с репозитория [https://github.com/Kyer41/journal];
- Необходимо установить 'Visual Studio' с 'IIS Express';

## Руководство пользователя
### Подключение к серверу

Для подключения к серверу необходимо в веб браузере, в адресной строке задать "URL адрес" сервера

### Взаимодействие с "шапкой"

#### **Кнопка "Электронный журнал"**

При взаимодействии (наведении) с кнопкой <Электронный журнал>, данная кнопка подсвечивается.

При взаимодействии (клике) с кнопкой <Электронный журнал>,для пользователя ничего не происходит (это нормально), в конец адресной строки добавляется не имеющий значения символ " # "

#### **Кнопка "Главная"**

При взаимодействии (наведении) с кнопкой <Страница поиска>, данная кнопка подсвечивается.

При взаимодействии (клик) с кнопкой <Страница поиска>, клиента перенаправят на главную страницу, если клиент и так находится на этой странице, она обновится.

#### **Кнопка "Вход"**

При взаимодействии (наведении) с кнопкой <Вход>, данная кнопка подсвечивается.

При взаимодействии (клик) с кнопкой <Вход>, клиента перенаправят на страницу входа, где пользователь может войти на свой зарегистрированный профиль, если клиент и так находится на этой странице, она обновится.

#### **Кнопка "Зарегистрироваться"**

При взаимодействии (наведении) с кнопкой <Зарегистрироваться>, данная кнопка подсвечивается.

При взаимодействии (клик) с кнопкой <Зарегистрироваться>, клиента перенаправят на страницу регистрации, где пользователь может зарегистрироваться, если клиент и так находится на этой странице, она обновится.

#### **Кнопка "Восстановление"**

При взаимодействии (наведении) с кнопкой <Восстановление>, данная кнопка подсвечивается.

При взаимодействии (клик) с кнопкой <Зарегистрироваться>, клиента перенаправят на страницу восстановления, где пользователь может восстановить вход на профиль, указав адрес почты, куда придёт письмо, если клиент и так находится на этой странице, она обновится.

## Работа с главной страницой '/'

На главной станице находятся поля ввода группы Фамилии и Имени студента, где можно указать данные студента и посмотреть его успеваемость нажав на кнопку "Найти".

#### **Кнопка "Найти"**

При взаимодействии (клике) с кнопкой <Найти> клиента перенаправят на страницу поиска студента, где клиент имеет возможность увидеть успеваемость студента.


## Работа со страницой входа '/'

На странице входа находятся поля ввода логина и пароля, где можно указать данные и авторизоваться в системе. Существует 2 вида профилей: профиль decanat и профиль преподаватель.

## Работа со страницей decanat'/'

При входе от логина decanat, идет перенаправление на страницу Деканат менеджер.

### Взаимодействие с "шапкой" деканата

#### **Кнопка "Главная"**

При взаимодействии (наведении) с кнопкой <Страница поиска>, данная кнопка подсвечивается.

При взаимодействии (клик) с кнопкой <Страница поиска>, клиента перенаправят на главную страницу, если клиент и так находится на этой странице, она обновится.


#### **Кнопка Студенты**

При взаимодействии (наведении) с кнопкой <Студенты>, данная кнопка подсвечивается.

При взаимодействии (клик) с кнопкой <Студенты>, клиента перенаправят на страницу студентов, если клиент и так находится на этой странице, она обновится.


#### **Кнопка Преподаватели**

При взаимодействии (наведении) с кнопкой <Преподаватели>, данная кнопка подсвечивается.

При взаимодействии (клик) с кнопкой <Преподаватели>, клиента перенаправят на страницу преподавателей, если клиент и так находится на этой странице, она обновится.

#### **Кнопка Предметы**

При взаимодействии (наведении) с кнопкой <Предметы>, данная кнопка подсвечивается.

При взаимодействии (клик) с кнопкой <Предметы>, клиента перенаправят на страницу предметов, если клиент и так находится на этой странице, она обновится.


#### **Кнопка Выход**

При взаимодействии (наведении) с кнопкой <Выход>, данная кнопка подсвечивается.

При взаимодействии (клик) с кнопкой <Выход>, клиента перенаправят на главную страницу Электронного журнала, если клиент и так находится на этой странице, она обновится.

## Работа со страницой Студенты  '/'

На странице Студенты отображается список зачисленных студентов, каждую запись можно удалить или изменить, при нажатии на кнопку Зачислить студента происходит перенаправление на страницу Зачисления студента, где нужно ввести группу, фамилию, имя и отчество студента.

## Работа со страницой Преподаватели  '/'

На странице Преподаватели отображены все зарегистрированные пользователи сервера, указаны логин, фамилия, имя, отчество и email.

## Работа со страницой Предметы  '/'

В данной странице находятся список предметов и преподавателей и кнопка Добавить новый, нажав на которую, можно добавить предмет преподавателю, также можно удалить предмет, нажав на кнопку удалить.

## Работа со страницей Препод менеджер'/'

Если при входе логин пользователя не decanat, то клиента перенаправят на страницу Препод Менеджер.


### Взаимодействие с "шапкой" Препод менеджера

#### **Кнопка "Главная"**

При взаимодействии (наведении) с кнопкой <Страница поиска>, данная кнопка подсвечивается.

При взаимодействии (клик) с кнопкой <Страница поиска>, клиента перенаправят на главную страницу, если клиент и так находится на этой странице, она обновится.

#### **Мои предметы"**

При взаимодействии (наведении) с кнопкой <Мои предметы>, данная кнопка подсвечивается.

При взаимодействии (клик) с кнопкой <Мои предметы>, клиента перенаправят на страницу Мои предметы, если клиент и так находится на этой странице, она обновится.


#### **Выставить оценку"**

При взаимодействии (наведении) с кнопкой <Выставить оценку>, данная кнопка подсвечивается.

При взаимодействии (клик) с кнопкой <Выставить оценку>, клиента перенаправят на страницу Выставить оценку, если клиент и так находится на этой странице, она обновится.

#### **Настройки"**

При взаимодействии (наведении) с кнопкой <Настройки>, данная кнопка подсвечивается.

При взаимодействии (клик) с кнопкой <Настройки>, клиента перенаправят на страницу Изменить пароль, если клиент и так находится на этой странице, она обновится.


## Работа со страницей Мои предметы  '/'

На странице Мои предметы пользователь может видеть список предметов, которые назначил ему decanat, на каждом предмете есть кнопка Открыть, при нажатии на которую отображается список студентов которым преподаватель выставил оценку, оценка и описание, также пользователь может удалить записи на данной странице.


## Работа со страницей Выставить оценку  '/'
На странице Выставить оценку, клиент выбирает студента, которому выставляется оценка, предмет, оценка и описание, затем нажать на кнопку Поставить, далее идет перенаправление на страницу выбранного предмета.

## Работа со страницей Настройки  '/'
На странице настройки отображаются поля ввода старого пароля, нового пароля и повторения нового пароля, после нажатия на кнопку изменить, идет перенаправление на новую страницу, где будет надпись об успешности смены пароля в случае, если всё верно, в противном случае страница выдаст ошибку ввода паролей.