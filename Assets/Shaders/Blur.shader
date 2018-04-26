Shader "Custom/Blur" {
	Properties {
		_MainTex("Texture", 2D) = "white" {}
	}
	
	CGINCLUDE
	#include "UnityCG.cginc"

	sampler2D	_MainTex;				// 原圖
	float4		_MainTex_TexelSize;		// 每個 pxiel 對應的 UV

	

	// 要模糊的函式
	float4 BlurFunction(v2f_img pixel) : SV_Target
	{
		// 範圍
		int OffsetPixelSize = 10;

		float4 blurColor = 0;
		for(int i = -OffsetPixelSize; i <= OffsetPixelSize; i++)
			for (int j = -OffsetPixelSize; j <= OffsetPixelSize; j++)
			{
				float2 UVOffset = _MainTex_TexelSize.xy * float2(i, j);
				blurColor += tex2D(_MainTex, pixel.uv + UVOffset);
			}
		int length = (OffsetPixelSize + OffsetPixelSize + 1);
		return blurColor / length / length;
	}
	ENDCG

	SubShader
	{
		Pass
		{
			Cull Off
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment BlurFunction
			//#pragma target 2.0
			ENDCG
		}
	}
}
