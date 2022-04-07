# Удаленное подключение

## Установка драйверов

Если вы уверены, что у вас нет TAP драйвера, можете скачать его [здесь](https://github.com/Alexxx180/Wisdom/blob/master/Instruction/Remote/Tap-driver.exe).

## Скачать OpenVPN

- [Windows-7/8/8.1](https://github.com/Alexxx180/Wisdom/blob/master/Instruction/Remote/openvpn-Win7.exe)
- [Windows-10](https://github.com/Alexxx180/Wisdom/blob/master/Instruction/Remote/openvpn-Win10.exe)

## Настройка

1. Установите OpenVPN, следуя шагам установщика.
2. Получите конфигурацию у руководителя, примерно следующего содержания:

![Конфигурация](https://github.com/Alexxx180/Wisdom/blob/master/Instruction/Remote/Images/Config-sample.png)

3. Откройте файл .txt, в данном случае это "user-pwd.txt":

![Файл с учетными данными](https://github.com/Alexxx180/Wisdom/blob/master/Instruction/Remote/Images/Login-sample.png)

4. Замените "логин" на ваш логин и "пароль" на ваш пароль для удаленного подключения.
5. Запустите программу Open VPN GUI.
6. Кликните по появившемуся значку правой кнопкой мыши, он может быть скрыт за "^"

![Иконка "Монитор с замочком"](https://github.com/Alexxx180/Wisdom/blob/master/Instruction/Remote/Images/OpenVPN-icon.PNG)

7. Выберите "Настройки".
8. Нажмите "Расширенные".
9. В поле "Файлы конфигурации" -> "Папка:" скопируйте полный путь в буфер обмена (Ctrl + C)

![Настройки](https://github.com/Alexxx180/Wisdom/blob/master/Instruction/Remote/Images/Settings-sample.png)

10. Откройте проводник.
11. Вставьте путь и перейдите по нему.
12. Замените старую папку конфигурации, на измененную вами

![Пример замены конфигурации](https://github.com/Alexxx180/Wisdom/blob/master/Instruction/Remote/Images/Replace-sample.png)

## Удаленное подключение

1. Запустите программу Open VPN GUI.
2. Кликните по появившемуся значку правой кнопкой мыши, он может быть скрыт за "^"

![Иконка "Монитор с замочком"](https://github.com/Alexxx180/Wisdom/blob/master/Instruction/Remote/Images/OpenVPN-icon.PNG)

3. Нажмите "Подключиться"
4. Введите пароль сертификата
5. Подтвердите

## Проблемы

Если у вас выскакивает ошибка
```
All TAP-Windows adapters on the system are currently in use
```
Значит скорее всего у вас не установлен TAP драйвер, подробнее см. Установка драйверов.


[Вход в систему](https://github.com/Alexxx180/Wisdom/blob/master/Instruction/Configuration.md) |
[Содержание](https://github.com/Alexxx180/Wisdom/blob/master/Instruction/Contents.md)
