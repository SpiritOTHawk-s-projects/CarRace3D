## Compatible URP versions:

- 11.0.0

## How to use. Examples

First, plugin necessary libraries

```c#
using GraphicsConfigurator.API.URP;
using UnityEngine.Rendering.Universal;
using ShadowResolution = UnityEngine.Rendering.Universal.ShadowResolution;
```

To change the active URP Asset, you need to do the following:

```c#
// ...
// code somewhere
Configuring.CurrentURPA.OpaqueDownsampling(Downsampling._4xBox);
Configuring.CurrentURPA.AntiAliasing(MsaaQuality._4x);

Configuring.CurrentURPA.MainLightMode(LightRenderingMode.PerPixel);
Configuring.CurrentURPA.MainLightShadowsCasting(true);
Configuring.CurrentURPA.MainLightShadowResolution(ShadowResolution._1024);
// ...
```

If you want to work with a specific URP Asset, do it like this:

```c#
private URPAssetConfiguring URPA = new URPAssetConfiguring(target);

// ...
// code somewhere
URPA.MainLightShadowsCasting(true);
URPA.Cascade3Split(new Vector2(0.1f, 0.3f));
// ...
```

## Tested devices

|    CPU    |         GPU         |       OS       | Graphics API | Backend | .Net  |
| :-------: | :-----------------: | :------------: | :----------: | :-----: | :---: |
|  SD 855   |     Adreno 640      | Android 10.3.8 |    Vulkan    | IL2CPP  |  4.x  |
|  SD 845   |     Adreno 630      | Android 10.3.7 |    Vulkan    | IL2CPP  |  4.x  |
| i7 6700HQ | AMD Randeon Pro 450 |  macOS 11.2.1  |    Metal     | IL2CPP  |  4.x  |

## Known issues

- When there is a change in the additional light rendering mode with the display of the target asset in the inspector,
  then the mode changes briefly, after which it has the parameters that were set before the change was attempted.
  This happens only in editor mode, it is not observed in assemblies.
  If, in editor mode, you try to change the rendering mode of the additional light and do not display the target asset in the inspector,
  then everything is successful.
  Presumably the problem lies in the way the asset editor works.
