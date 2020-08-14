# This should work as an init command, make it ssh-keygen -A
# It seems like it can run over and over without destroying what is there

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
  threax/openssh-server ssh-keygen -A