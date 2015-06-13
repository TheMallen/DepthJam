/// <summary>
/// Project: hmmm
/// Name: Unlit/Transparent
/// Description: Used for GUI.
/// Author: Joseph Cameron
/// </summary>

//#region change log
//Name: Joseph Cameron
//Description: initial implementation
//Date: April 17th, 2015
//#endregion

//Move from _TIME to timeheld which is passed in while animating.

Shader "Renderer/CharacterAnimator" 
{
	Properties 
	{
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_Color   ("Material color", Color   ) = (1,1,1,1)
	
	}

	SubShader 
	{
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		
		LOD 0
	
		ZWrite On
		Blend SrcAlpha OneMinusSrcAlpha
		cull off 
	
		//
		// Shadow pass
		//
		Pass 
		{  
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 3.0
				#include "UnityCG.cginc"
				
				//********************
				// Animation constants
				//********************
				#define FRAMESIZE fixed(0.125)
				//Animation aliases
				#define WALK int(0)
				#define RUN  int(1)
				//Walk
				#define WALKSPEED float(0.15)
				#define WALKANIMATIONSIZE int(3)
				//Run
				#define RUNSPEED float(0.205)
				#define RUNANIMATIONSIZE int(6)
				

			//************************
			// Data formats & uniforms
			//************************
			uniform sampler2D _MainTex    ;
			uniform float4    _MainTex_ST ; //TODO REMOVE THIS UNIFORM
			uniform fixed4    _Color      ;
			
			uniform int  _CurrentAnimation;
			uniform float2 _Dir;
			uniform int  _AnimationTime;
			
			struct VertexInput 
			{
				float4 pos         : POSITION0 ;
				float2 uv          : TEXCOORD0 ;
				float2 modelCenter : TEXCOORD1 ;
				
			};

			struct FragmentInput 
			{
				float4 pos : POSITION0 ;
				half2  uv  : TEXCOORD0 ;
				
			};

			//*********************
			// Forward declarations
			//*********************
			fixed2 animate(const fixed2 aUV);

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
					output.pos = input.pos;
					
					//
					//Apply drop shadow effect
					//
					float4 aPos = output.pos;
					{
						if (aPos[1] > 0)
						{
							aPos[0] += 0.25;
							aPos[1] -= 0.75;
						
						}
						
						aPos[1] += 0.075;
						aPos[2] = 100;//TODO: this should be 100, which should be a def in an include. Move depth calc to shader
						
					}
					output.pos = aPos;
					
					
					output.pos = mul(UNITY_MATRIX_MVP, output.pos);
					
					
					output.uv  = TRANSFORM_TEX(input.uv, _MainTex);
				
				}
				
				return output;
				
			}
			
			fixed4 frag (const FragmentInput input) : COLOR0
			{
				fixed4 output = (fixed4)0;
				{
					fixed2 uv = animate(input.uv);
					output  = tex2D(_MainTex, uv);
					output *= _Color;
					
					if(output.a <= 0)
						discard;
					
					output.rgb = 0;
					output.a = 0.5;
											
				}
				
				return output;
				
			}
			
			//
			//
			//
			fixed2 animate(const fixed2 aUV)
			{
				fixed2 output = aUV;
				{
					//============================
					// Determine current direction
					//============================
					if (_Dir.x < -0.6)
					{
						output[1] -= FRAMESIZE*2;
					
					}
					else if (_Dir.x > 0.6)
					{
						output[1] -= FRAMESIZE*3;
					
					}
					else if (_Dir.y > 0)
					{
						output[1] -= FRAMESIZE;
						
					}
					
					//=======================
					// Calculate frame offset
					//=======================
					if (_CurrentAnimation == WALK)
					{
						//Periodic animation
						int frameIndex = round(sin(_AnimationTime*WALKSPEED)*0.75);
						float uvOffset = frameIndex * FRAMESIZE;
						
						output[0] += FRAMESIZE + uvOffset;
					
					}
					else if (_CurrentAnimation == RUN)
					{
						output[1] -= FRAMESIZE*4;
					
						//Linear animation
						int   frameIndex  = floor(_AnimationTime*RUNSPEED);
						float repetitions = floor(frameIndex/RUNANIMATIONSIZE);
						
						frameIndex -= repetitions*RUNANIMATIONSIZE;
						float uvOffset   = frameIndex*FRAMESIZE;
						
						output[0] += uvOffset;
					
					}
					
				}
			
				return output;
			
			}
			
			ENDCG
			
		}
	
		//
		//Character pass
		//
		Pass 
		{  
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"
				
				//********************
				// Animation constants
				//********************
				#define FRAMESIZE fixed(0.125)
				//Animation aliases
				#define WALK int(0)
				#define RUN  int(1)
				//Walk
				#define WALKSPEED float(0.15)
				#define WALKANIMATIONSIZE int(3)
				//Run
				#define RUNSPEED float(0.205)
				#define RUNANIMATIONSIZE int(6)
				

			//************************
			// Data formats & uniforms
			//************************
			uniform sampler2D _MainTex    ;
			uniform float4    _MainTex_ST ; //TODO REMOVE THIS UNIFORM
			uniform fixed4    _Color      ;
			
			uniform int    _CurrentAnimation;
			uniform float2 _Dir;
			uniform int    _AnimationTime;
			
			struct VertexInput 
			{
				float4 pos         : POSITION0 ;
				float2 uv          : TEXCOORD0 ;
				float2 modelCenter : TEXCOORD1 ;
				
			};

			struct FragmentInput 
			{
				float4 pos : POSITION0 ;
				half2  uv  : TEXCOORD0 ;
				
			};

			//*********************
			// Forward declarations
			//*********************
			fixed2 animate(const fixed2 aUV);

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
					output.pos = input.pos;
					
					//Space out middle layer
					//output.pos[2] += mul(_Object2World,float3(input.modelCenter[0],input.modelCenter[1],0))[1]; //TODO: think of gpu solution
					
					output.pos.xy = input.modelCenter + float2(-0.5,-0.5);
					
					//SORT DEPTH TODO: Works but needs clean up (not very legible)
					float4 test = input.pos;
					//test[1] = -0.375;
					test[1] = -0.35625;
					output.pos.z = 1 * mul(_Object2World,test).y;
					
					output.pos = mul(UNITY_MATRIX_MVP, output.pos);
					
					
					output.uv  = TRANSFORM_TEX(input.uv, _MainTex);
				
				}
				
				return output;
				
			}
			
			fixed4 frag (const FragmentInput input) : COLOR0
			{
				fixed4 output = (fixed4)0;
				{
					fixed2 uv = animate(input.uv);
					output  = tex2D(_MainTex, uv);
					output *= _Color;
					
					if(output.a <= 0)
						discard;
							
				}
				
				return output;
				
			}
			
			//
			//
			//
			fixed2 animate(const fixed2 aUV)
			{
				fixed2 output = aUV;
				{
					//============================
					// Determine current direction
					//============================
					if (_Dir.x < -0.6)
					{
						output[1] -= FRAMESIZE*2;
					
					}
					else if (_Dir.x > 0.6)
					{
						output[1] -= FRAMESIZE*3;
					
					}
					else if (_Dir.y > 0)
					{
						output[1] -= FRAMESIZE;
						
					}
					
					//=======================
					// Calculate frame offset
					//=======================
					if (_CurrentAnimation == WALK)
					{
						//Periodic animation
						int frameIndex = round(sin(_AnimationTime*WALKSPEED)*0.75);
						float uvOffset = frameIndex * FRAMESIZE;
						
						output[0] += FRAMESIZE + uvOffset;
					
					}
					else if (_CurrentAnimation == RUN)
					{
						output[1] -= FRAMESIZE*4;
					
						//Linear animation
						int   frameIndex  = floor(_AnimationTime*RUNSPEED);
						float repetitions = floor(frameIndex/RUNANIMATIONSIZE);
						
						frameIndex -= repetitions*RUNANIMATIONSIZE;
						float uvOffset   = frameIndex*FRAMESIZE;
						
						output[0] += uvOffset;
					
					}
					
				}
			
				return output;
			
			}
			
			ENDCG
			
		}
		
	}

}










