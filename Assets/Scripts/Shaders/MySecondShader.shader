Shader "James/MySecondShader"
{
    Properties
    {
        _MainTexture("Main Texture", 2D) = "white" {}
        _Color1("Color", Color) = (1,1,1,1)
        _Color2("Color", Color) = (1,1,1,1)
    }

    SubShader
    {
        Pass
        {
            CGPROGRAM

            #pragma vertex vertexFunc
            #pragma fragment fragmentFunc

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTexture;
            fixed4 _Color1;
            fixed4 _Color2;
            float _Height;
            float4 _MainTex_ST;

            v2f vertexFunc(appdata IN)
            {
                v2f OUT;

                // OUT.vertex = UnityObjectToClipPos(IN.normal);
                // OUT.uv = TRANSFORM_TEX(IN.uv, _MainTexture);
                // OUT.worldPos = mul(unity_ObjectToWorld, IN.vertex);
                OUT.position = UnityObjectToClipPos(IN.vertex);
                // OUT.uv = IN.uv;

                return OUT;
            }

            fixed4 fragmentFunc(v2f IN) : SV_Target
            {
                fixed4 pixelColor = tex2D(_MainTexture, IN.uv);

                fixed4 gradient = 1;//lerp(_Color1, _Color2, IN.worldPos.y / _Height);

                return pixelColor * gradient;
            }

            ENDCG
        }
    }
}