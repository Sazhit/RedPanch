Shader "Displacement/Displacement_Wave"
{
    Properties
    {
        [PerRendererData]
        _MainTex ("Main Texture", 2D) = "white" {}
        _Color ("Color" , Color) = (1,1,1,1)
        _DisplacementTex ("Displacement Texture", 2D) = "white" {}
        _DisplacementPower ("Displacement Power" , Range(0.0, 1.0)) = 0
        _OpacityWave ("OpacityWave " , Range(0.0, 1.0)) = 0
    }

    SubShader
    {
        Tags
        {
            "RenderType" = "Transparent"
            "Queue" = "Transparent"
        }

        Cull Off
        //Blend SrcAlpha OneMinusSrcAlpha
        Blend Off
        
        GrabPass
        {
            "_GrabTexture"
        }

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
                float4 color : COLOR;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
                float4 grabPos : TEXCOORD1;
            };

            fixed4 _Color;
            sampler2D _MainTex;
            sampler2D _GrabTexture;
            sampler2D _DisplacementTex;
            float _DisplacementPower;
            float _OpacityWave;


            v2f vert (appdata v)
            {
	            v2f o;
	            o.uv = v.uv;
	            o.color = v.color;
	            o.vertex = UnityObjectToClipPos(v.vertex);	
	            o.grabPos = ComputeGrabScreenPos (o.vertex);
	            o.grabPos /= o.grabPos.w;
	            return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {                   
	            fixed4 displPos = tex2D(_DisplacementTex, i.uv);
                float2 offset = (displPos.xy*2 - 1) * _DisplacementPower * _OpacityWave * displPos.a;
                fixed4 grabColor = tex2D (_GrabTexture, i.grabPos.xy + offset);         
	            fixed4 texColor = tex2D(_MainTex, i.uv)*i.color;
                fixed4 color = grabColor < 0.5
                    ? 2*grabColor*texColor 
                    : 1-2*(1-texColor)*(1-grabColor);
                color = lerp(grabColor, color ,texColor.a * _OpacityWave);
	            return color;
            }
            ENDCG
        }
    }
}
