# RouteReader Mobile (C#/.NET)

Offline-first **route & meter-reading practice** app built with **.NET MAUI** (mobile) + a simple **ASP.NET Core Minimal API** (backend), sharing models/contracts via a **Shared** library.

## What it does (MVP)
- Browse **Routes**
- Tap a route to see **Stops**
- Tap a stop to enter a **Reading**
- Local-first workflow (SQLite planned) with optional sync (API planned)

## Tech Stack
- **.NET 9**
- **.NET MAUI** (Android / iOS / Mac Catalyst)
- **ASP.NET Core Minimal API**
- **Shared** project for models/contracts
- **Tests** project for unit/integration tests

## Repo Structure
src/
RouteRead.Mobile/ # .NET MAUI app (UI + MVVM)
RouteRead.Api/ # ASP.NET Core Minimal API
RouteRead.Shared/ # Shared models/contracts/helpers
tests/
RouteRead.Tests/ # Test project
RouteRead.sln


## Getting Started
### 1) Restore + Build the solution

  ```bash
  dotnet restore
  dotnet build RouteRead.sln -c Debug
  ```

### 2) Build Mobile (Android)

  ```bash
  dotnet restore
  dotnet build RouteRead.sln -c Debug
  ```

### 3) Run Mobile (Android)
- #### Requires an Android emulator running (Android Studio Device Manager) or a connected device (USB debugging enabled).

  ```bash
  dotnet build src/RouteRead.Mobile/RouteRead.Mobile.csproj -f net9.0-android -t:Run \
  -p:AndroidSdkDirectory="$ANDROID_SDK_ROOT" \
  -p:JavaSdkDirectory="$JAVA_HOME"
  ```

- #### If you have multiple devices/emulators:
````bash
"$ANDROID_SDK_ROOT/platform-tools/adb" devices -l
````

- #### Then:
```bash
dotnet build src/RouteRead.Mobile/RouteRead.Mobile.csproj -f net9.0-android -t:Run \
  -p:AndroidSdkDirectory="$ANDROID_SDK_ROOT" \
  -p:JavaSdkDirectory="$JAVA_HOME" \
  -p:AndroidDeviceSerial=emulator-5554
```

### 4) Run the API
```bash
dotnet run --project src/RouteRead.Api
```

## Tests
```bash
dotnet test
```

## Current MVP Milestones
- [X] Milestone A — App boots + navigation works, Routes → Stops → Stop detail → enter reading
- [ ] Milestone B — Local persistence (SQLite) for routes/stops/readings
- [ ] Milestone C — Optional sync with API (pull routes/stops, push readings)


