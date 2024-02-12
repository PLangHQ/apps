# Use the .NET runtime image with Linux
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base

COPY ./app /app/
COPY ./plang /plang/

WORKDIR /app
ENV PATH="/plang:${PATH}"

EXPOSE %port%

# Command to run when the container starts
ENTRYPOINT ["plang", "run"]