Shader "Custom/BlackMask"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _HoleSize ("Hole Size", Float) = 0.2
        _CursorPosition ("Cursor Position", Vector) = (0,0.5,0,0)
    }
    SubShader
    {
        Tags { "Queue"="Overlay" "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Off
            Lighting Off

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
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _HoleSize;
            float2 _CursorPosition;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv;

                uv.y = 1 - uv.y;
                uv.x = 1 - uv.x;

                float dist = distance(uv, _CursorPosition); 
                
                float alpha = step(_HoleSize, dist);

                half4 col = tex2D(_MainTex, i.uv);
                col.a *= alpha;
                return col;
            }
            ENDCG
        }
    }
}
