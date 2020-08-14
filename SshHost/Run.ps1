docker rm openssh-server --force

docker run `
-it `
  --name=openssh-server `
  --user 30010:30011 `
  -p 2222:2222 `
  -v ${pwd}/repo:/repo `
  -v ${pwd}/config/ssh-keys:/etc/ssh `
  -v ${pwd}/config/.ssh:/home/threax/.ssh `
  --rm `
  threax/openssh-server



  #--hostname=openssh-server `#optional` `
  #-e PUBLIC_KEY=yourpublickey `#optional` `
  #-e PUBLIC_KEY_FILE=/path/to/file `#optional` `
  #-e SUDO_ACCESS=false `#optional` `
  #-e PASSWORD_ACCESS=false `#optional` `
  #-e USER_PASSWORD=password `#optional` `
  #-e USER_PASSWORD_FILE=/path/to/file `#optional` `
  #-e USER_NAME=linuxserver.io `#optional` `
  #-v /path/to/appdata/config:/config `
  #--restart unless-stopped `