# Spuit

![demo](/docs//images/demo.gif)

Spuit is a Windows-only application that allows users to retrieve color and cursor position information for specific locations on the screen.

## Env & Install

The released executable is built exclusively for x64 Windows. The operating system on which the author has tested the software is Windows 11.

There is a zip containing the executable on the [Release page](https://github.com/kawana77b/Spuit/releases).
This application is not signed.

## Usage

- Once the app is launched, click on the syringe icon or press the `S` key on the keyboard with the app in focus.
- Press the `S` key on the keyboard at the position where you want to get any information.
- A string is copied to the clipboard with the selection from the pull-down menu.

## Features and Nearby Apps

- Copy the captured color code and RGB or HSL CSS format string to the clipboard
- Copy the captured cursor position to the clipboard

This tool can be used to examine any color rendered on a PC screen, copy-paste it into CSS, or use it as a preliminary study to check the cursor position in automation tools, for example.  
This application is a personal creation and is intended as a trivial demonstration and experiment.

There are many excellent ones similar to this app.
A typical example is [PowerToys](https://github.com/microsoft/PowerToys). This tool includes the excellent [ColorPicker](https://github.com/martinchrzan/ColorPicker).

## Tech Background

A simple application, but includes the following small personal technical efforts:

- 🧰 Provides examples of basic Windows application development with [WPF](https://learn.microsoft.com/en-US/dotnet/desktop/wpf/overview/?view=netdesktop-8.0) and [MVVM](https://learn.microsoft.com/en-us/windows/apps/develop/data-binding/data-binding-and-mvvm) models
- 💻 Modern front end with [WPF-UI](https://wpfui.lepo.co/index.html)
- 🌠 Use the relatively popular [CommunityToolkit.Mvvm](https://www.nuget.org/packages/CommunityToolkit.Mvvm) for implementing MVVM (my favorite!)
- 🎛️ Use relatively new .NET
- 🔦 Support for Light and Dark modes according to System settings
- 🔠 Localization in English and Japanese (Reflected by system settings)
