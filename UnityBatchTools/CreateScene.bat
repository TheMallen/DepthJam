:: *******************************************************
:: Name: CreateScene.bat
:: Purpose: Creates subdirs for a scene in a unity project
:: Usage: Place on project root, execute & follow prompt
:: *******************************************************

@Echo Off

:: User prompt
echo ***********
echo CreateScene
echo ***********
:CreateScene
set /p v_SceneName=Scene Name: 
if "%v_SceneName%" == "" GOTO BadInputPrompt

:: Subdir creation
md "../Assets/Resources/%v_SceneName%/Materials"
md "../Assets/Resources/%v_SceneName%/Textures"
md "../Assets/Resources/%v_SceneName%/Prefabs"
md "../Assets/Resources/%v_SceneName%/Models"
md "../Assets/Scripts/%v_SceneName%"
md "../Assets/Shaders/%v_SceneName%"

:: End of file
echo "%v_SceneName%" subdirectories created.
PAUSE
GOTO END

:BadInputPrompt
echo invalid scene name
GOTO CreateScene

:END