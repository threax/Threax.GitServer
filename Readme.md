# Running
1. Install Threax.DockerTools if needed. `dotnet tool install -g Threax.DockerTools`
2. Run `Local.ps1` in the Deployment folder.

# Permissions Issues
If you get a login error `Permission denied (publickey,keyboard-interactive).` its probably file permisisons.
On Linux these should be fixed, but with a Windows host you will need to modify the environment variable in appconfig.json `StrictModes` to `no`.

# TortoiseGit
To get TortoiseGit to use the windows ssh client open the (TortoiseGit) Settings app then Click on Network and change SSH Client to
```
C:\Windows\System32\OpenSSH\ssh.exe
```
It should now pick up the key and config from the user ssh folder.

You may also have to ssh into the host once or otherwise get it into known_hosts for Tortoise to start working correctly.