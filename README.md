## Gamesparks Unity Sources

This repository contains the sources for the binaries included with the GameSparks Unity SDK.

Each project build the release assets to /Projects/GameSparksUnity/* (this is the folder structure that required in unity)

## C# projects

Contained within gamesparks-unity-sources.sln

### Projects/bccrypto-csharp-1.8.1/crypto/BouncyCastle_GameSparks.csproj

BouncyCastle assembly with a reduced class set to minimise the final asembly size.

This project builds the assembly for all supported platforms.

### Projects/GameSparks/GameSparks.csproj

Source for GameSparks.dll. This project builds the assembly for all supported platforms excluding the following:

Windows Metro
Windows UWP
Windows Phone 8


### Projects/GameSparks.Api/GameSparks.Api.csproj

Source for GameSparks.Api.dll This project builds the assembly for all supported platforms.

### Projects/GameSparks.Realtime/GameSparksRT/GameSparksRT.csproj

Source for GameSparksRT.dll  This project builds the assembly for all supported platforms excluding the following:

Windows Metro

## License

This library is licensed under the Apache 2.0 License. 


## C++ projects

Contained within Projects/GameSparks.Native/build/GameSparksNative/GameSparksNative.sln

### Projects/GameSparks.Native/build/GameSparksNative/GameSparksNative.PS4.vcxproj

Native library for PS4. If "mbed_tls_net_ps4.inc" is reported missing, you need to request this file from gamesparks support.

### Projects/GameSparks.Native/build/GameSparksNative/GameSparksNative.Switch.vcxproj

Native library for Nintendo Switch

### Projects/GameSparks.Native/build/GameSparksNative/GameSparksNative.Win64.vcxproj

Native library for Win64

### Projects/GameSparks.Native/build/GameSparksNative/GameSparksNative.XBoxOne.vcxproj

Native library for XboxOne