# SharpChat

A C# chat application built using Blazor WASM, Bootstrap, Razor components, ASP.NET Core and SignalR.

### Run Instructions

1. Install self-signed certificates:
```
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```

2. Start the server:
```
cd Server
dotnet run
```
3. Start the client:
```
cd Client
dotnet run
```
4. Open the web UI at https://localhost:7045.
