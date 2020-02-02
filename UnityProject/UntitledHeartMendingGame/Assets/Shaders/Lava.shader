// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Rod/Lava"
{
	Properties
	{
		_Intensity("Intensity", Float) = 1.99
		_Speed("Speed", Float) = 0.25
		[HDR]_Color("Color", Color) = (0,1,0.8358741,0)
		_NoiseScale("NoiseScale", Float) = 5
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float _Intensity;
		uniform float4 _Color;
		uniform float _Speed;
		uniform float _NoiseScale;


		float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }

		float snoise( float2 v )
		{
			const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
			float2 i = floor( v + dot( v, C.yy ) );
			float2 x0 = v - i + dot( i, C.xx );
			float2 i1;
			i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
			float4 x12 = x0.xyxy + C.xxzz;
			x12.xy -= i1;
			i = mod2D289( i );
			float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
			float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
			m = m * m;
			m = m * m;
			float3 x = 2.0 * frac( p * C.www ) - 1.0;
			float3 h = abs( x ) - 0.5;
			float3 ox = floor( x + 0.5 );
			float3 a0 = x - ox;
			m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
			float3 g;
			g.x = a0.x * x0.x + h.x * x0.y;
			g.yz = a0.yz * x12.xz + h.yz * x12.yw;
			return 130.0 * dot( m, g );
		}


		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 temp_cast_0 = (_Speed).xx;
			float2 panner2 = ( 1.0 * _Time.y * temp_cast_0 + float2( 0,0 ));
			float simplePerlin2D3 = snoise( ( i.uv_texcoord + panner2 )*_NoiseScale );
			simplePerlin2D3 = simplePerlin2D3*0.5 + 0.5;
			float2 uv_TexCoord10 = i.uv_texcoord * float2( -1,-1 );
			float2 temp_cast_1 = (_Speed).xx;
			float2 panner11 = ( 1.0 * _Time.y * temp_cast_1 + float2( 0,0 ));
			float simplePerlin2D15 = snoise( ( uv_TexCoord10 + panner11 )*_NoiseScale );
			simplePerlin2D15 = simplePerlin2D15*0.5 + 0.5;
			o.Emission = ( _Intensity * ( _Color * ( ( simplePerlin2D3 * simplePerlin2D15 ) * 1.1 ) ) ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17700
0;4;1451;991;3472.631;2044.415;3.251284;True;False
Node;AmplifyShaderEditor.RangedFloatNode;7;-2041.128,183.5591;Inherit;False;Property;_Speed;Speed;1;0;Create;True;0;0;False;0;0.25;0.05;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;4;-1559.255,-249.427;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PannerNode;2;-1522.255,-61.42699;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;11;-1577.183,428.3594;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;10;-1614.183,240.3594;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;-1,-1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;5;-1282.255,-303.4269;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;27;-1422.272,97.7814;Inherit;False;Property;_NoiseScale;NoiseScale;3;0;Create;True;0;0;False;0;5;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;9;-1337.183,186.3595;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;15;-1169.381,303.5879;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;3;-1113.453,-186.1985;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;18;-824.3682,110.3032;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;21;-528.3688,337.5033;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;1.1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;23;-541.1687,39.90319;Inherit;False;Property;_Color;Color;2;1;[HDR];Create;True;0;0;False;0;0,1,0.8358741,0;1,0.4262067,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;24;-249.9689,255.9032;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;1.1;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;26;-217.969,-3.29691;Inherit;False;Property;_Intensity;Intensity;0;0;Create;True;0;0;False;0;1.99;10;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;25;-11.56902,86.30306;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;1.1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;297.6,78.39999;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Rod/Lava;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;2;2;7;0
WireConnection;11;2;7;0
WireConnection;5;0;4;0
WireConnection;5;1;2;0
WireConnection;9;0;10;0
WireConnection;9;1;11;0
WireConnection;15;0;9;0
WireConnection;15;1;27;0
WireConnection;3;0;5;0
WireConnection;3;1;27;0
WireConnection;18;0;3;0
WireConnection;18;1;15;0
WireConnection;21;0;18;0
WireConnection;24;0;23;0
WireConnection;24;1;21;0
WireConnection;25;0;26;0
WireConnection;25;1;24;0
WireConnection;0;2;25;0
ASEEND*/
//CHKSM=CEB052828DEBF1C05D648FC0028ED157D5D2C780