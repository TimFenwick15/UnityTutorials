# Graph Tutorial
https://catlikecoding.com/unity/tutorials/basics/building-a-graph/

Points are a pre-fab. Made by dragging an object to the Assets bar. If you change one pre-fab, it changes other instances of it too.

In this case there won't be pre-fabs added to the scene - we're going to make them in the script

To exit play mode, press play again

Think you need this above the object class to see what the tutorial shows
[ExecuteInEditMode] , [ExecuteAlways]
This isn't mentioned, I think behaviour has changed, or there's a setting I've missed

Shader code is written in a shader block, with text to say where in the menu it goes:

Shader "Custom/PointShader" { }

Shaders can have sub-shaders: SubShader {}

Fallback (if shader won't compile?): FallBack "Diffuse".

Sub-shader will use a mix of CG and HLSL which live between these keywords:

    SubShader {
        CGPROGRAM
        ENDCG
    }

This is included: #pragma surface ConfigureSurface Standard fullforwardshadows

Sets a quality level: #pragma target 3.0

Properties make the shader configurable. This will appear on the material:
    Properties {
        _Smoothness ("Smoothness", Range(0,1)) = 0.5
    }


So far we've made:
- point pre-fab - points are generated in the script
- point shader
- point material, uses the shader
- shader > material > pre-fab


surface.Albedo = input.worldPos * 0.5 + 0.5;

I think this works because both are float3, so colour (RGB) is set by coordinate (XYZ). Tutorial comments this is a silly way to do this because if the points moved, their colour would change.

The transformation at the end is to turn from -1 - 1 range (which makes no sense for a colour) to 0 - 1 range

In our case, points are in 2D. So it makes more sense to:
surface.Albedo.rg = input.worldPos.xy * 0.5 + 0.5;

Tutorial comments URP will probably be standard in the future, so good to support that

Universal Render Pipeline
Assets / Create / Rendering / Universal Render Pipeline / Pipeline Asset (Forward Renderer)
Actually added Assets / Create / Rendering / URP Asset (Universal Renderer)

Still don't really know what we're doing here.

We've set the Scriptable Render Pipeline Settings

At the time of the tutorial, writing URP shaders was difficult, and likely to change. So we're using Shader Graph package to visually design our effect

