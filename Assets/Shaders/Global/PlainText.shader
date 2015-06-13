Shader "Renderer/PlainText" 
{
	Properties 
	{
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_Color   ("Material color", Color   ) = (1,1,1,1)
	
	}

	SubShader 
	{
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		
		LOD 100
	
		ZWrite On
		Blend SrcAlpha OneMinusSrcAlpha
		cull off 
	
		Pass 
		{  
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

			//************************
			// Data formats & uniforms
			//************************
			uniform sampler2D _MainTex    ;
			uniform float4    _MainTex_ST ;
			uniform fixed4    _Color      ;
			
			struct VertexInput 
			{
				float4 pos : POSITION0 ;
				float2 uv  : TEXCOORD0 ;
				
			};

			struct FragmentInput 
			{
				float4 pos : POSITION0 ;
				half2  uv  : TEXCOORD0 ;
				
			};

			//********
			// Shaders
			//********	
			FragmentInput vert (const VertexInput input)
			{
				FragmentInput output = (FragmentInput)0;
				{
					output.pos = mul(UNITY_MATRIX_MVP, input.pos);
					output.uv  = TRANSFORM_TEX(input.uv, _MainTex);
				
				}
				
				return output;
				
			}
			
			fixed4 frag (const FragmentInput input) : COLOR0
			{
				fixed4 output = (fixed4)0;
				{
					output  = tex2D(_MainTex, input.uv);
					
					if(output.a <= 0)
						discard;
					else
						output.rgb = _Color;
							
				}
				
				return output;
				
			}
			
			ENDCG
			
		}
		
	}

}










