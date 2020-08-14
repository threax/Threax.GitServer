# Setup Keys
Add the public key to authorized_keys. Make sure to save as LF.

# Permissions Issues
If you get a login error `Permission denied (publickey,keyboard-interactive).` its probably file permisisons.
On Linux these should be fixed, but with a Windows host you will need to modify sshd_config find the line StrictModes and set it
to `StrictModes no`.

This will appear in the /config folder. Run the image once to create it.

# TortoiseGit
To get TortoiseGit to use the windows ssh client open the (TortoiseGit) Settings app then Click on Network and change SSH Client to
```
C:\Windows\System32\OpenSSH\ssh.exe
```
It should now pick up the key and config from the user ssh folder.

# Ubuntu Server
Start with 
```
/usr/sbin/sshd -D -p 2222
```

Will have to run ssh-keygen -A once in the container to create the keys, do a volume mount for this to keep it. (See run.ps1)

sshd_config works, but has lessened security with `StrictModes no` as described above.

Put this into the ssk-keys mount that goes to /etc/ssh

The .ssh folder maps to /home/$USER/.ssh