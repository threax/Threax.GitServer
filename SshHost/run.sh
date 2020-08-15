if [ -z "$StrictModes" ]
then
echo "Setting StrictModes to '$StrictModes'"
echo "\nStrictModes $StrictModes" >> /app/sshd_config
else
echo "Not changing StrictModes from default."
fi

/usr/sbin/sshd -D -p 2222 -f /app/sshd_config