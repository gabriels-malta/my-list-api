dotnet new classlib -f netstandard2.0 -n MyList.Domain -o ./src/MyList.Domain

dotnet new classlib -f netstandard2.0 -n MyList.Application -o ./src/MyList.Application

rm ./src/**/Class1.cs

dotnet add ./src/MyList.Application/MyList.Application.csproj reference ./src/MyList.Domain/MyList.Domain.csproj
dotnet add ./src/MyList.Application/MyList.Application.csproj package MediatR
dotnet add ./src/MyList.Application/MyList.Application.csproj package Microsoft.Extensions.DependencyInjection.Abstractions --version 3.1.15
dotnet add ./src/MyList.Application/MyList.Application.csproj package MediatR.Extensions.Microsoft.DependencyInjection --version 9.0.0

dotnet new webapi -f netcoreapp3.1 -n MyList.Api -o ./src/MyList.Api -au None
dotnet add ./src/MyList.Api/MyList.Api.csproj reference ./src/MyList.Application/MyList.Application.csproj
dotnet add ./src/MyList.Api/MyList.Api.csproj package Newtonsoft.Json --version 13.0.1
dotnet add ./src/MyList.Api/MyList.Api.csproj package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 3.1.15

dotnet new sln -n MyList -o ./src

dotnet sln ./src/MyList.sln add `
./src/MyList.Domain/MyList.Domain.csproj `
./src/MyList.Application/MyList.Application.csproj `
./src/MyList.Api/MyList.Api.csproj
