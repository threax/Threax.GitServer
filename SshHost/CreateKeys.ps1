# This should work as an init command, make it ssh-keygen -A
# It seems like it can run over and over without destroying what is there

docker rm git-ssh-server --force

docker run `
  -it `
  --name=git-ssh-server `
  --user 30010:30011 `
  -p 2222:2222 `
  -v ${pwd}/repo:/repo `
  -v ${pwd}/config/ssh-keys:/etc/ssh `
  -v ${pwd}/config/.ssh:/home/threax/.ssh `
  --rm `
  threax/git-ssh-server ssh-keygen -A