FROM ubuntu

# Install Node
RUN apt-get update &&\
    apt-get install openssh-server -y &&\
    apt-get install git -y &&\
    apt-get autoremove &&\
    apt-get clean

COPY sshd_config /app/sshd_config
COPY sshd_config_nostrict /app/sshd_config_nostrict
COPY run.sh /app/run.sh

CMD /app/run.sh
RUN chmod 777 /app/run.sh