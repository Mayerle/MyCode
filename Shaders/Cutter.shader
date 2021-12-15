Shader "Def/Cutter"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _X1 ("x1", Range(0.0,1)) = 0
        _X2 ("x2", Range(0.0,1)) = 0
        _Y1 ("y1", Range(0.0,1)) = 0
        _Y2 ("y1", Range(0.0,1)) = 0
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
            float _X1;
            float _Y1;
            float _X2;
            float _Y2;


            fixed4 frag (v2f i) : SV_Target
            {
                if(i.uv.x<=_X1 || i.uv.x>=_X2||i.uv.y<=_Y1||i.uv.y>=_Y2){
                    return tex2D(_MainTex, i.uv);
                    }else{
                        return fixed4(0,0,0,0);
                    }
              
            }
            ENDCG
        }
    }
}