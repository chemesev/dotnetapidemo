FROM microsoft/dotnet:runtime
WORKDIR /dotnetapidemo
COPY out .
ENTRYPOINT ["dotnet", "apiserver.dll"]