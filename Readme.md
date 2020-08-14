# Setup Keys
Add the public key to authorized_keys. Make sure to save as LF.

# Permissions Issues
If you get a login error `Permission denied (publickey,keyboard-interactive).` its probably file permisisons.
On Linux these should be fixed, but with a Windows host you will need to modify sshd_config find the line StrictModes and set it
to `StrictModes no`.