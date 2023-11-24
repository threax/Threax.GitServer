#/bin/bash
configFile="/app/sshd_config"
if [ "$StrictModes" = "no" ]
then
configFile="/app/sshd_config_nostrict"
fi

echo "Using config '$configFile'"
/usr/sbin/sshd -d -D -p 2222 -f $configFile