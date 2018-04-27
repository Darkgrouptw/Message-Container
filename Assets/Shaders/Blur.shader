Shader "Custom/Blur" {
	Properties {
		_MainTex("Texture", 2D) = "white" {}
		_FilterSize("FilterSize", Int) = 2
	}
	
	CGINCLUDE
	#include "UnityCG.cginc"

	sampler2D	_MainTex;				// 原圖
	float4		_MainTex_TexelSize;		// 每個 pxiel 對應的 UV
	int			_FilterSize;

	

	// 要模糊的函式
	float4 BlurFunction(v2f_img pixel) : SV_Target
	{
		float4 blurColor = 0;
		for(int i = -_FilterSize; i <= _FilterSize; i++)
			for (int j = -_FilterSize; j <= _FilterSize; j++)
			{
				float2 UVOffset = _MainTex_TexelSize.xy * float2(i, j);
				blurColor += tex2D(_MainTex, pixel.uv + UVOffset);
			}
		int length = (_FilterSize + _FilterSize + 1);
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
			#pragma target 3.0
			ENDCG
		}
	}
}
