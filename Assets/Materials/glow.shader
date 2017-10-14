Shader "N3K/glow"
{
	Properties
	{
		_Color("Main Color", Color) = (0.5,0.5,0.5,1)
		_MainTex ("Texture", 2D) = "white" {}
		_OutlineColor("Outline color", Color) = (0,0,0,1)
		_OutlineX("Outline x", Range(1.0,5.0)) = 1.01
		_OutlineY("Outline y", Range(1.0,5.0)) = 1.01
		_OutlineZ("Outline z", Range(1.0,5.0)) = 1.01
	}

	CGINCLUDE
	#include "UnityCG.cginc"

	struct appdata
	{
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};

	struct v2f
	{
		float4 pos : POSITION;
		float3 normal : NORMAL;
	};

	float _OutlineX;
	float _OutlineY;
	float _OutlineZ;
	float4 _OutlineColor;

	v2f vert(appdata v)
	{
		v.vertex.x *= _OutlineX;
		v.vertex.y *= _OutlineY;
		v.vertex.z *= _OutlineZ;

		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		return o;
	}
	ENDCG

	SubShader
	{
		Pass //Outline
		{
			ZWrite Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			half4 frag(v2f i):COLOR
			{
				return _OutlineColor;
			}

			ENDCG
		}

		Pass //Object on top
		{
			ZWrite On

			Material
			{
				Diffuse[_Color]
				Ambient[_Color]
			}

			Lighting On

			SetTexture[_MainTex]
			{
				ConstantColor[_Color]
			}

			SetTexture[_MainTex]
			{
				Combine previous * primary DOUBLE
			}
		}
	}
}
