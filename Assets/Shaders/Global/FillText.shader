Shader "Renderer/FillText"
{
	Properties
	{
		_FontText    ("Base (RGB) Trans (A)", 2D    ) = "white" {}
		_FillColor   ("Fill color"          , Color ) = (1,1,1,1)
		_ShadowColor ("Shadow color"        , Color ) = (0,0,0,1)
		_Alpha       ("Alpha", Float) = 1
	
	}
	
	Subshader
	{
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		
		LOD 100
	
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha 
	
		Pass //"BorderTopLeft"
		{
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#define ALPHACUTOFF fixed(0.3)
				#define BLACK fixed4(0,0,0,1)
				#define BORDEROFFSET float2(-0.1,0.1)
				
			//
			// Data formats
			//
			struct VertexInput
			{
				float4 pos:POSITION0;
				fixed2 uv:texcoord0;
			
			};
			
			struct FragmentInput
			{
				float4 pos:POSITION0;
				fixed2 uv:texcoord0;
				
			};
			
			
			//
			// Uniforms
			//
			sampler2D _FontText;
			fixed4    _ShadowColor;
			float _Alpha;
			
			//
			// Shaders
			//
			FragmentInput vert(const VertexInput input)
			{
				FragmentInput output = (FragmentInput)0;
				{
					//Calculate pos
					output.pos = input.pos;
					output.pos[0] += BORDEROFFSET[0];
					output.pos[1] += BORDEROFFSET[1];
					
					output.pos = mul(UNITY_MATRIX_MVP,output.pos);
					
					//Calculate uv
					output.uv = input.uv;
				
				}
				
				return output;
			
			}
			
			fixed4 frag(const FragmentInput input) : COLOR0
			{
				fixed4 output = (fixed4)0;
				{
					//Calculate color
					fixed4 texel = tex2D(_FontText, input.uv);
					
					if (texel[3] < ALPHACUTOFF)
						discard;
					else
					{
						output = _ShadowColor;						
						output[3] = _Alpha;
					
					}
				
				}
				
				return output;
			
			}
			
			ENDCG
		
		}
	
		Pass //"BorderTopRight"
		{
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#define ALPHACUTOFF fixed(0.3)
				#define BLACK fixed4(0,0,0,1)
				#define BORDEROFFSET float2(0.1,0.1)
				
			//
			// Data formats
			//
			struct VertexInput
			{
				float4 pos:POSITION0;
				fixed2 uv:texcoord0;
			
			};
			
			struct FragmentInput
			{
				float4 pos:POSITION0;
				fixed2 uv:texcoord0;
				
			};
			
			
			//
			// Uniforms
			//
			sampler2D _FontText;
			fixed4    _ShadowColor;
			float _Alpha;
			
			//
			// Shaders
			//
			FragmentInput vert(const VertexInput input)
			{
				FragmentInput output = (FragmentInput)0;
				{
					//Calculate pos
					output.pos = input.pos;
					output.pos[0] += BORDEROFFSET[0];
					output.pos[1] += BORDEROFFSET[1];
					
					output.pos = mul(UNITY_MATRIX_MVP,output.pos);
					
					//Calculate uv
					output.uv = input.uv;
				
				}
				
				return output;
			
			}
			
			fixed4 frag(const FragmentInput input) : COLOR0
			{
				fixed4 output = (fixed4)0;
				{
					//Calculate color
					fixed4 texel = tex2D(_FontText, input.uv);
					
					if (texel[3] < ALPHACUTOFF)
						discard;
					else
					{
						output = _ShadowColor;						
						output[3] = _Alpha;
					
					}
				
				}
				
				return output;
			
			}
			
			ENDCG
		
		}
	
		Pass //"BorderBottomLeft"
		{
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#define ALPHACUTOFF fixed(0.3)
				#define BLACK fixed4(0,0,0,1)
				#define BORDEROFFSET float2(-0.1,-0.1)
				
			//
			// Data formats
			//
			struct VertexInput
			{
				float4 pos:POSITION0;
				fixed2 uv:texcoord0;
			
			};
			
			struct FragmentInput
			{
				float4 pos:POSITION0;
				fixed2 uv:texcoord0;
				
			};
			
			
			//
			// Uniforms
			//
			sampler2D _FontText;
			fixed4    _ShadowColor;
			float _Alpha;
			
			//
			// Shaders
			//
			FragmentInput vert(const VertexInput input)
			{
				FragmentInput output = (FragmentInput)0;
				{
					//Calculate pos
					output.pos = input.pos;
					output.pos[0] += BORDEROFFSET[0];
					output.pos[1] += BORDEROFFSET[1];
					
					output.pos = mul(UNITY_MATRIX_MVP,output.pos);
					
					//Calculate uv
					output.uv = input.uv;
				
				}
				
				return output;
			
			}
			
			fixed4 frag(const FragmentInput input) : COLOR0
			{
				fixed4 output = (fixed4)0;
				{
					//Calculate color
					fixed4 texel = tex2D(_FontText, input.uv);
					
					if (texel[3] < ALPHACUTOFF)
						discard;
					else
					{
						output = _ShadowColor;						
						output[3] = _Alpha;
					
					}
				
				}
				
				return output;
			
			}
			
			ENDCG
		
		}
		
		Pass //"BorderBottomRight"
		{
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#define ALPHACUTOFF fixed(0.3)
				#define BLACK fixed4(0,0,0,1)
				#define BORDEROFFSET float2(0.1,-0.1)
				
			//
			// Data formats
			//
			struct VertexInput
			{
				float4 pos:POSITION0;
				fixed2 uv:texcoord0;
			
			};
			
			struct FragmentInput
			{
				float4 pos:POSITION0;
				fixed2 uv:texcoord0;
				
			};
			
			
			//
			// Uniforms
			//
			sampler2D _FontText;
			fixed4    _ShadowColor;
			float _Alpha;
			
			//
			// Shaders
			//
			FragmentInput vert(const VertexInput input)
			{
				FragmentInput output = (FragmentInput)0;
				{
					//Calculate pos
					output.pos = input.pos;
					output.pos[0] += BORDEROFFSET[0];
					output.pos[1] += BORDEROFFSET[1];
					
					output.pos = mul(UNITY_MATRIX_MVP,output.pos);
					
					//Calculate uv
					output.uv = input.uv;
				
				}
				
				return output;
			
			}
			
			fixed4 frag(const FragmentInput input) : COLOR0
			{
				fixed4 output = (fixed4)0;
				{
					//Calculate color
					fixed4 texel = tex2D(_FontText, input.uv);
					
					if (texel[3] < ALPHACUTOFF)
						discard;
					else
					{
						output = _ShadowColor;						
						output[3] = _Alpha;
					
					}
				
				}
				
				return output;
			
			}
			
			ENDCG
		
		}
	
		Pass //"Color fill"
		{
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#define ALPHACUTOFF fixed(0.3)
				#define BLACK fixed4(0,0,0,1)
				
			//
			// Data formats
			//
			struct VertexInput
			{
				float4 pos:POSITION0;
				fixed2 uv:texcoord0;
			
			};
			
			struct FragmentInput
			{
				float4 pos:POSITION0;
				fixed2 uv:texcoord0;
				
			};
			
			
			//
			// Uniforms
			//
			sampler2D _FontText;
			fixed4    _FillColor;
			float _Alpha;
			
			//
			// Shaders
			//
			FragmentInput vert(const VertexInput input)
			{
				FragmentInput output = (FragmentInput)0;
				{
					//Calculate pos
					output.pos = input.pos;
					output.pos = mul(UNITY_MATRIX_MVP,output.pos);
					
					//Calculate uv
					output.uv = input.uv;
				
				}
				
				return output;
			
			}
			
			fixed4 frag(const FragmentInput input) : COLOR0
			{
				fixed4 output = (fixed4)0;
				{
					//Calculate color
					fixed4 texel = tex2D(_FontText, input.uv);
					
					if (texel[3] < ALPHACUTOFF)
						discard;
					else
					{
						output = _FillColor;						
						output[3] = _Alpha;
					
					}
				
				}
				
				return output;
			
			}
			
			ENDCG
		
		}
	
	}

}









