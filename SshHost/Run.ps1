docker rm openssh-server --force

docker run `
  -d `
  --name=openssh-server `
  --user 30010:30011 `
  -p 2222:2222 `
  -v ${pwd}/repo:/repo `
  -v ${pwd}/config/ssh-keys:/etc/ssh `
  -v ${pwd}/config/.ssh:/home/threax/.ssh `
  --rm `
  threax/openssh-server