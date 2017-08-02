FROM microsoft/dotnet:runtime
WORKDIR /dotnetapidemo
COPY out .
EXPOSE 5000
ENTRYPOINT ["dotnet", "apiserver.dll"]