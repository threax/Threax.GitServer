$scriptPath = Split-Path $script:MyInvocation.MyCommand.Path

threax-dockertools build $scriptPath/appsettings.GitServer.json
threax-dockertools build $scriptPath/appsettings.GitSsh.json
threax-dockertools run $scriptPath/appsettings.GitServer.json
threax-dockertools run $scriptPath/appsettings.GitSsh.json