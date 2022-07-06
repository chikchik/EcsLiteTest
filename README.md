# README #

Тестовое задание с использованием EcsLite
https://docs.google.com/document/d/1huX_UQjfb0f4OxgBPL4UXwpWuFNWQexld0mJrop7N8M/edit


## Логика

Файлы, которые относятся к логике, расположены в папке Assets->Scripts->Logic.
Соответственно классы и структуры в namespace EcsLiteTest.Logic.

### Компоненты
* **DoorButtonComponent** - данные дверной кнопки.
* **DoorComponent** - данные двери.
* **PlayerComponent** - данные игрока.
* **PlayerMoveDestinationComponent** - данные о точки движения игрока (существует только когда игрок двигается к цели, придостижении которой компонент удаляется).
* **PositionComponent** - данные о позиции сущности в мире.

### Системы
* **PlayerMoveSystem** - обрабатывает движение игрока к цели.
* **DoorSystem** - обрабатывает состояние открытия двери, по состоянию кнопки.
* **DoorButtonSystem** - обрабатывает состояние нажатия кнопки по позиции игрока.

### Классы

* **WorldTime** - таймер игры, для того чтобы обновлялись его значения необходима реализация соответствующей системы на "сервере".


## Представление в Unity

Файлы, которые относятся к представлению, расположены в папке Assets->Scripts->View.
Соответственно классы и структуры в namespace EcsLiteTest.View.

### Системы
* **DoorInitSystem** - инициализация сущностей дверей и кнопок.
* **PlayerInitSystem** - инициализация сущностей игрока.
* **DoorButtonUpdateSystem** - обновление представлений кнопок по данным сущностей.
* **DoorUpdateSystem** - обновление представлений дверей по данным сущностей.
* **PlayerUpdateSystem** - обновление представлений игрока по данным сущностей.
* **PlayerInputSystem** - обработка ввода пользователя и целеуказаний для игрока.
* **WorldTimeSystem** - обработка таймера игры.

### Классы

* **DoorButtonView** - представление дверной кнопки.
* **DoorView** - представление двери.
* **PlayerView** - представление игрока.
* **ViewsCache** - кэш представлений, обеспечивающий их поиск по сущностям.

