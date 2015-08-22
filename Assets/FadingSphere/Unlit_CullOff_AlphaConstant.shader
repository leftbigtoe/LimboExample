Shader "Unlit/Cutout/Unlit_CullOff_AlphaConstant" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_CutTex ("Cutout (A)", 2D) = "white" {}
		_Constant ("Alpha Constant", Range(0,1)) = 0
	}
 
	SubShader {
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		LOD 200
		Cull Off
		
		 
		CGPROGRAM
		#pragma surface surf Lambert alpha
		 
		sampler2D _MainTex;
		sampler2D _CutTex;
		fixed4 _Color;
		float _Constant;
		 
		struct Input {
			float2 uv_MainTex;
			float2 uv_CutTex;
		};
		 
			void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			//fixed4 e = tex2D(_Emissive, IN.uv_MainTex);
			float ca = tex2D(_CutTex, IN.uv_CutTex).a;
			//o.Albedo = c.rgb;
			o.Emission = c.rgb;
			//o.Emission = e.rgb;
			o.Alpha = clamp(ca + _Constant * 2 - 1, 0, 1) - (1-c.a);
		}
		ENDCG
	}
	 
	Fallback "Transparent/VertexLit"
}