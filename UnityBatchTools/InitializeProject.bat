:: *****************************************************
:: Name: InitializeProject.bat
:: Purpose: Creates global subdirs for a unity project
:: Usage: Place on project root, execute & follow prompt
:: *****************************************************

@Echo Off

:: User prompt
echo *****************
echo InitializeProject
echo *****************
echo Press return to init...
set /p a= 

:: Create project subdirs
md "../Assets/Resources/Global/Materials"
md "../Assets/Resources/Global/Textures"
md "../Assets/Resources/Global/Prefabs"
md "../Assets/Resources/Global/Models"
md "../Assets/Scenes/Unit Tests"
md "../Assets/Scripts/Global"
md "../Assets/Shaders/Global"

:: Copy global prefabs
copy "Viewport2D.prefab" "../Assets/Resources/Global/Prefabs/Viewport2D.prefab"
copy "Viewport3D.prefab" "../Assets/Resources/Global/Prefabs/Viewport3D.prefab"

:: End of file prompt
echo Global directories initialized
PAUSE