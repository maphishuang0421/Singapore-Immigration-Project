Shader "Custom/ScrollingTextureUpwards"
{
    Properties
    {
        _MainTex ("Base Texture", 2D) = "white" {}
        _ScrollSpeed ("Scroll Speed", Range(0, 10)) = 1
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float _ScrollSpeed;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv; // No tiling applied, UVs are passed through unchanged
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                // Scroll upwards by adding to the Y component of UV coordinates
                float2 uv = i.uv;
                uv.y += _ScrollSpeed * _Time.y;
                uv = frac(uv); // Wrap UV coordinates to keep them in [0, 1]
                half4 col = tex2D(_MainTex, uv);
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
