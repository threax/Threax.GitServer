# Running
1. Go to SshHost
1. Use Threax.DockerTools to build appconfig.json
1. On Windows change `StrictModes` under environment to `no`. This way it will ignore the messed up permissions on the authorized_keys file.
1. Use Threax.DockerTools to run appconfig.json
1. Run Threax.GitServer
1. Add your public ssh key to the Authorized Keys gui.
1. You should now be able to create/clone/push etc to your repos.

# Permissions Issues
If you get a login error `Permission denied (publickey,keyboard-interactive).` its probably file permisisons.
On Linux these should be fixed, but with a Windows host you will need to modify the environment variable in appconfig.json `StrictModes` to `no`.

# TortoiseGit
To get TortoiseGit to use the windows ssh client open the (TortoiseGit) Settings app then Click on Network and change SSH Client to
```
C:\Windows\System32\OpenSSH\ssh.exe
```
It should now pick up the key and config from the user ssh folder.