ARG VARIANT=7.0.400-bookworm-slim-amd64
FROM mcr.microsoft.com/dotnet/sdk:${VARIANT}
RUN apt-get update && \
    apt-get install -y curl bat exa mariadb-client ca-certificates gnupg && \
    mkdir -p /etc/apt/keyrings && \
    curl -fsSL https://deb.nodesource.com/gpgkey/nodesource-repo.gpg.key | gpg --dearmor -o /etc/apt/keyrings/nodesource.gpg && \
    echo "deb [signed-by=/etc/apt/keyrings/nodesource.gpg] https://deb.nodesource.com/node_20.x nodistro main" > /etc/apt/sources.list.d/nodesource.list && \
    apt-get update && \
    apt-get install -y nodejs && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*
ENV PATH $PATH:/home/vscode/.dotnet:/home/vscode/.dotnet/tools
