FROM ubuntu as base

# Install SSH
RUN apt-get update &&\
    apt-get install openssh-server -y &&\
    apt-get install git -y &&\
    apt-get autoremove &&\
    apt-get clean



FROM base as build

RUN apt-get update &&\
    apt-get install curl -y &&\
    apt-get install build-essential -y &&\
    apt-get install make -y &&\
    apt-get install git -y &&\
    apt-get autoremove &&\
    apt-get clean
    
#Install Rust
RUN curl --proto '=https' --tlsv1.3 https://sh.rustup.rs -sSf | sh -s -- -y
# Add .cargo/bin to PATH
ENV PATH="/root/.cargo/bin:${PATH}"

# Check cargo is visible
RUN cargo --help

WORKDIR /scutiger
RUN git clone https://github.com/threax/scutiger .
RUN make



FROM base as final

COPY --from=build /scutiger/target/release/git-lfs-transfer /bin/git-lfs-transfer

COPY sshd_config /app/sshd_config
COPY sshd_config_nostrict /app/sshd_config_nostrict
COPY run.sh /app/run.sh

CMD /app/run.sh
RUN chmod 777 /app/run.sh