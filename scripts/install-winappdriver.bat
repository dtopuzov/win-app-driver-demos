REM Download and Install WinAppDriver
del /f WindowsApplicationDriver.msi
call curl https://github.com/microsoft/WinAppDriver/releases/download/v1.2.1/WindowsApplicationDriver_1.2.1.msi --output WindowsApplicationDriver.msi
call msiexec /i WindowsApplicationDriver.msi /qn