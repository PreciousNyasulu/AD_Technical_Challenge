# AD Technical Challenge

## Table of Contents

- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [How to Run](#how-to-run)


### Prerequisites

To run the project you need the following tools:

- Docker (for the database container)
- Dotnet 8.0

### Installation


```bash
git clone https://github.com/PreciousNyasulu/AD_Technical_Challenge.git
cd AD_Technical_Challenge
```

### How to Run

Start the docker container using the following command

```bash
docker compose up -d
```

create an environment file (`.env`) on the root directory of the project.
```bash
cp .env.example .env
```

To start the program run the following shell script command below:
```bash
sh ./serve.sh
```