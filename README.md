# MediaInfo.DotNetWrapper
A C# .NET Wrapper for the [MediaInfo.Native](https://www.nuget.org/packages/MediaInfo.Native/) and [MediaInfo.dll](https://mediaarea.net/en/MediaInfo/Download/Windows)

[![Build status](https://ci.appveyor.com/api/projects/status/0fb53mu4p186got3?svg=true)](https://ci.appveyor.com/project/StefH/mediainfo-dotnetwrapper)

[![NuGet Badge](https://buildstats.info/nuget/Mediainfo.DotNetWrapper)](https://www.nuget.org/packages/Mediainfo.DotNetWrapper)

Supported frameworks are
- .NET 3.5
- .NET 4.0 and up
- .NET Standard 2.0

Note that you need to build you application/library in **x64** or **x86**, else it will not work.

Based on [MP-MediaInfo](https://github.com/yartat/MP-MediaInfo).

For example see : test\MediaInfo.DotNetWrapper.ConsoleTest

# Targeting .Net Standard 1.3

MediaInfo.Native is not included when targeting .Net Standard / Core. Manually include MediaInfo native libaries for your operating system / platform.

## Windows

[Download](https://mediaarea.net/en/MediaInfo/Download/Windows) latest version of DLL for your platform (x64 or x86). Add installation directory to windows PATH environment variable.

## MacOS

Install mediainfo via [HomeBrew](https://brew.sh).

```bash
brew install media-info
```

## Linux

[Download](https://mediaarea.net/en/MediaInfo/Download) and install **official release** for your linux distribution. You can also build mediainfo from source. MediaInfo.DotNetWrapper will look for libmediainfo.so in LD_LIBRARY_PATH.
 