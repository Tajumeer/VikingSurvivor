void GetMainLight_half(float3 WorldPos ,out half3 Direction, out half3 Color, out half DistanceAtten, out half SHadownAtten)
{
#if SHADERGRAPH_PREVIEW
    Direction = half3(0.5,0.5,0);
    Color = 1;
    DistanceAtten = 1;
    SHadownAtten = 1;
#else 
    #if SHADOWS_SCREEN
        half4 clipPos = TransformWorldToHClip(WorldPos);
        half4 shadowCoord = ComputeScreenPos(clipPos);
    #else
        half4 shadowCoord = TransformWorldToShadowCoord(WorldPos);
    #endif

    Light light = GetMainLight(shadowCoord);
    Direction = light.direction;
    Color = light.color;
    DistanceAtten = light.distanceAttenuation;
    SHadownAtten = light.shadowAttenuation;
#endif
}

void DirectSpecular_half(half3 SpecularColor, half Smoothness, half3 LightDir, half3 LightColor,half3 WorldNormal,half3 WorldView ,out half3 Specular)
{
    #if SHADERGRAPH_PREVIEW
        Specular = 0;
    #else
        Smoothness = exp2(10 * Smoothness + 1); //Smotness Curve
        WorldNormal = normalize(WorldNormal);
        WorldView = SafeNormalize(WorldView);
        Specular = LightingSpecular(LightColor, LightDir, WorldNormal, WorldView, half4(SpecularColor, 0), Smoothness);
    #endif

}

void CalculateAdditionalLights_half(half3 SpecularColor, half Smoothness, half3 WorldPos, half3 WorldNormal, half3 WorldView, out half3 Diffuse, out half3 Specular)
{
#if SHADERGRAPH_PREVIEW
    Diffuse = 0;
    Specular = 0;
#else
    half3 diffuseColor = 0;
    half3 specularColor = 0;

    Smoothness = exp2(10 * Smoothness + 1);
    WorldNormal = normalize(WorldNormal);
    WorldView = SafeNormalize(WorldView);

    int pixelLightCount = GetAdditionalLightsCount();

    for(int i = 0; i < pixelLightCount; i++)
    {
        Light addLight = GetAdditionalLight(i, WorldPos);
        half3 attenuatedLight = (addLight.distanceAttenuation * addLight.shadowAttenuation) * addLight.color;
        diffuseColor += LightingLambert(attenuatedLight, addLight.direction, WorldNormal);
        specularColor += LightingSpecular(attenuatedLight, addLight.direction, WorldNormal, WorldView, half4(specularColor, 0), Smoothness);
    }       

    Diffuse = diffuseColor;
    Specular = specularColor;                       
#endif
}