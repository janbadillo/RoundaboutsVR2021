// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "FX/MirrorReflection"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_AlphaTex ("Alpha mask (R)", 2D) = "white" {}

		_CutTex ("Cutout (A)", 2D) = "white" {}
     	_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
		[HideInInspector] _ReflectionTex ("", 2D) = "white" {}
	}
	SubShader
	{
		Tags {"RenderType"="Opaque" "Queue"="Transparent"}
		LOD 100

		Lighting off//Turn off the light
		ZWrite off // Close deep cache
		Blend off//close mixing
		AlphaTest GEqual [_Cutoff]// Enable alpha testing
		Blend SrcAlpha OneMinusSrcAlpha

		Pass {


			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 refl : TEXCOORD1;
				float4 pos : SV_POSITION;
			};

            sampler2D _AlphaTex;
	
			sampler2D _Cutoff;

			float4 _MainTex_ST;
			v2f vert(float4 pos : POSITION, float2 uv : TEXCOORD0)
			{
				v2f o;
				o.pos = UnityObjectToClipPos (pos);
				o.uv = TRANSFORM_TEX(uv, _MainTex);
				o.refl = ComputeScreenPos (o.pos);

				return o;
			}
			sampler2D _MainTex;
			sampler2D _ReflectionTex;
			fixed4 frag(v2f i) : SV_Target
			{

				fixed4 tex = tex2D(_MainTex, i.uv);
				fixed4 refl = tex2Dproj(_ReflectionTex, UNITY_PROJ_COORD(i.refl));

				fixed4 col2 = tex2D(_AlphaTex, i.uv);
				return tex * refl * col2;
			}

			ENDCG


	    }
	}
}