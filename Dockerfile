FROM microsoft/dotnet:runtime
WORKDIR /dotnetapidemo
COPY out .
COPY bin/Debug/netcoreapp1.1/Tasks.db .
EXPOSE 5000
ENTRYPOINT ["dotnet", "apiserver.dll"]