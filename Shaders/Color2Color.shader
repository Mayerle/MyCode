Shader "Def/Color2Color"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Color ("First", Color) = (1,1,1,1)
		_Color2 ("Second", Color) = (0,0,0,1)
		_TopDelay ("TopDelay", Range(0.0, 1.0)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
       
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            
			int _Kernel;
			float2 _MainTex_TexelSize;
			fixed4 _Color;
			fixed4 _Color2;
            float _TopDelay;
            fixed4 frag (v2f i) : SV_Target
            {
                if(_TopDelay<=i.uv.y){
                    return fixed4(0,0,0,0);
                }

                fixed4 delta = _Color2-_Color;
                fixed4 color = _Color+delta*i.uv.y;

				        return color;
            }
            ENDCG
        }
    }
}