Shader "Custom/shader"
{
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
        
            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolators
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            float circle (float2 uv, float size) {
                return smoothstep(0.0, 0.005, 1 - length(uv) / size);
            }

            float2x2 rotate2D (float angle) {
                return float2x2 (
                    cos(angle), -sin(angle),
                    sin(angle),  cos(angle)
                );
            }

            float4 frag (Interpolators i) : SV_Target
            {
              float2 uv = i.uv * 2 - 1;
                float time = _Time.y;
                float3 color = 0;
               
                //tangent thing 
             //   float warpStrength = tan(time * 0.9);
             //   uv += cos(uv.yx + float2(time, 1.5)) * warpStrength; //output float2 -- input to float 2
           //     uv += sin(uv.yx + float2(0, time *3)) * warpStrength;


              // noise-y warp thing
               float warpStrength = 0.33;
                uv += cos(uv.yx*7 + float2(time, 1.5)) * atan(cos(sin(warpStrength*time)));
                uv += sin(uv.yx*7 + float2(0, time * 3)) * sin(cos(warpStrength*time));
                
             
             float circ = circle(uv, 0.8);
                color += float3(0.6, 0.7, 1);
                color += circ.rrr;
               

                return float4(color, 1.0);
                
            }
            ENDCG
        }
    }
}
