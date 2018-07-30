# Sample project to use Firestore by Xamarin.Forms

## Environment

### IDE and SDK

* Visual Studio Community 2017 for Mac Version 7.5.4 (build 3)
* Mono 5.10.1.57 (2017-12/ea8a24b1bbf) (64-bit)
* Xamarin.iOS  Version: 11.12.0.4 (Visual Studio Community)
* Xamarin.Android Version: 8.3.3.2 (Visual Studio Community)

### Library

* [Xamarin.Forms 3.1.0.637273](https://www.nuget.org/packages/Xamarin.Forms/3.1.0.637273)
* [Xamarin.Firebase.Firestore 60.1142.1](https://www.nuget.org/packages/Xamarin.Firebase.Firestore/60.1142.1)

## Notice

### Android

Must add reference [Xamarin.Google.Guava](https://www.nuget.org/packages/Xamarin.Google.Guava/) in your Xamarin.Android project if you use Xamarin.Firebase.Firestore 60.1142.1 .

ref: https://github.com/xamarin/GooglePlayServicesComponents/pull/130

### iOS

WIP

You must build [GoogleApisForiOSComponents](https://github.com/xamarin/GoogleApisForiOSComponents) and reference it.

## LICENSE

MIT
