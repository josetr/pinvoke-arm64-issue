# C# PInvoke issue mac arm64

## Issue

PInvoke call crashes if the returned structure is not a Plain Old Data and it's size is <= 16.

## Running example

`./build-native-lib.sh && dotnet run`

## Expected

* CreatePod should return `1111 9223372036854775807`
* CreateNonPod_HackyFix should return `1111 9223372036854775807`
* CreateNonPod should return `1111 9223372036854775807`

## Actual

* CreatePod returns `1111 9223372036854775807`
* CreateNonPod_HackyFix returns `1111 9223372036854775807`
* CreateNonPod crashes

## Crash reason

* Go to native-lib.cpp -> CreateNonPod
* Add `print("%p, &s16);` before `s16.a = 1111`

In my case, the output shows 0xffffffffffffffff, which is clearly a corrupted address

So the next line `s16.a = 1111` that uses it will obviously crash the application.
