FROM microsoft/dotnet:1-runtime
WORKDIR /dotnetapidemo
COPY out .
EXPOSE 5000
ENTRYPOINT ["dotnet", "apiserver.dll"]