FROM ubuntu

# Install Node
RUN apt-get update &&\
    apt-get install openssh-server -y &&\
    apt-get install git -y &&\
    apt-get autoremove &&\
    apt-get clean

RUN useradd -u 30010 -ms /bin/bash threax
USER threax

CMD /usr/sbin/sshd -D -p 2222 -f /app/config/sshd_config