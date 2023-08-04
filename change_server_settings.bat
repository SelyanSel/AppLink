@ECHO OFF
title AppLink - Change Settings

cd .applink
cd server

notepad .env

echo >>> Settings closed.

timeout /t 2

exit /b