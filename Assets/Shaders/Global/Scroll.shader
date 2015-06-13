Shader "Renderer/Scroll" 
{
	Properties 
	{
		_MainTex   ("Base (RGB) Trans (A)", 2D    ) = "white" {}
		_Color     ("Material color"      , Color ) = (1,1,1,1)
		_Speed     ("Scroll speed"        , float ) = 0
		_Direction ("Scroll direction"    , Vector) = (0,0,0,0)
	
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
			
			uniform float  _Speed;
			uniform float2 _Direction;
			
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
					//=========
					// Calc pos
					//=========
					output.pos = mul(UNITY_MATRIX_MVP, input.pos);
					
					//========
					// Calc uv
					//========
					output.uv  = TRANSFORM_TEX(input.uv, _MainTex);
					
					float2 dir = normalize(_Direction);
					
					output.uv += dir*(_Time*_Speed);
				
				}
				
				return output;
				
			}
			
			fixed4 frag (const FragmentInput input) : COLOR0
			{
				fixed4 output = (fixed4)0;
				{
					output  = tex2D(_MainTex, input.uv);
					output *= _Color;
					
					if(output.a <= 0)
						discard;
							
				}
				
				return output;
				
			}
			
			ENDCG
			
		}
		
	}

}










