# Oculus quest

- [General Unity development](../README.d)

## Prepare project

- [Tutorial to
  follow](https://developer.oculus.com/documentation/unity/unity-tutorial/)
- [Tutorial to follow on macOS](https://medium.com/virtual-reality-virtual-people/oculus-quest-development-in-unity-b3bac62fda87)

1. initialize Unity Project (2018.4.22f1+)
2. install Oculus Integration from Asset store
3. [configure build
   settings](https://developer.oculus.com/documentation/unity/unity-conf-settings)
4. [configure project for git](https://thoughtbot.com/blog/how-to-git-with-unity)
5. [setup avatar](https://developer.oculus.com/documentation/unity/as-avatars-gsg-unity/)

- [Setup XR Device to roomscale](https://forum.unity.com/threads/oculus-quest-unityengine-xr.677236/?_ga=2.250954688.750538125.1590067905-1389123627.1586989910)

## Upload application

### Manually

Download [adb](https://www.xda-developers.com/install-adb-windows-macos-linux/)

```bash
# first installation
$ ./platform-tools/adb install Base/Build.apk

# second installation
$ ./platform-tools/adb uninstall ca.etsmtl.oculus
$ ./platform-tools/adb install Base/Build.apk
```

- [To detect the oculus quest](https://www.android.com/filetransfer/)

### Automatically

Click on "File > "Build And Run" (Ctrl+B/⌘+B)

## How to develop

- [Build project](https://circuitstream.com/blog/oculus-quest-unity-setup/)
- [Setup oculus quest development](https://developer.oculus.com/documentation/native/android/mobile-device-setup/)
- [Debug tutorial](https://www.youtube.com/watch?v=AtOX6bXcQJE&feature=emb_logo)
- [OVRInput](https://developer.oculus.com/documentation/unity/unity-ovrinput/)
- [Unity Ui](https://developer.oculus.com/blog/unitys-ui-system-in-vr/)
- [Display
  hands](https://developer.oculus.com/documentation/unity/as-avatars-gsg-unity/)

Select Android SDK in Unity:

- https://answers.unity.com/questions/865842/os-x-unable-to-select-android-sdk-folder-because-i.html
- https://www.youtube.com/watch?v=ftPxYWjFIVk
- https://www.youtube.com/watch?v=x3Mi8GN5R-Q
- https://www.youtube.com/watch?v=dGrRQPE0pYc

### Inputs

- [Standard Unity Input](https://docs.unity3d.com/ScriptReference/Input.html)
  for not VR
- [Input Manager in Unity](https://docs.unity3d.com/Manual/class-InputManager.html)

### How to use Steam VR with Oculus quest

https://www.androidcentral.com/how-play-steamvr-quest

### Avatar

- [Display hands](https://developer.oculus.com/documentation/unity/as-avatars-gsg-unity/)

## Permissions

- https://docs.unity3d.com/2018.4/Documentation/Manual/android-manifest.html
- https://forums.oculusvr.com/developer/discussion/78412/accessing-local-files
- https://unitycoder.com/blog/2019/08/18/read-file-from-oculus-quest-sdcard-folder/

## Stream

- [Mirror Oculus Quest](https://support.oculus.com/1053142614872870/)
- [Different stream technologies for Oculus
  Quest](https://uploadvr.com/how-to-stream-oculus-quest/)
- [Chromecast Emulator](https://github.com/ajhsu/chromecast-device-emulator)
- https://uploadvr.com/how-to-stream-oculus-quest/

## Links

- https://developer.oculus.com/blog/unitys-ui-system-in-vr/
- https://developer.oculus.com/documentation/native/android/mobile-adb/
- https://www.androidcentral.com/steamvr-support-now-available-oculus-quest-through-sideloading
