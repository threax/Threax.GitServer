$scriptPath = Split-Path $script:MyInvocation.MyCommand.Path

threax-dockertools build $scriptPath/appsettings.GitServer.json
threax-dockertools build $scriptPath/appsettings.GitSsh.json
threax-dockertools run $scriptPath/appsettings.GitServer.json
threax-dockertools run $scriptPath/appsettings.GitSsh.json

threax-dockertools exec $scriptPath/../../Threax.Pipelines/ExampleDeployment/Local/id/appsettings.json AddFromMetadata `
    "git" `
    --exec-load secret "git/JwtAuth__ClientSecret" "$scriptPath/appsettings.GitServer.json" "JwtAuth__ClientSecret" `
    --exec-load secret "git/SharedClientCredentials__ClientSecret" "$scriptPath/appsettings.GitServer.json" "SharedClientCredentials__ClientSecret"

$userId = Read-Host -Prompt 'Enter the admin user''s User Id here'
threax-dockertools exec $scriptPath/appsettings.GitServer.json AddAdmin $userId