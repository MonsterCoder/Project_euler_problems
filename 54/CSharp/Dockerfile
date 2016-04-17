FROM microsoft/dotnet:0.0.1-alpha
RUN mkdir /src
WORKDIR /src
ADD . /src
RUN dotnet restore
RUN dotnet build
CMD sh test.sh