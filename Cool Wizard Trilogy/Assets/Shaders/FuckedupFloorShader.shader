Shader "DISPLACEMENTFLOOR" {
   Properties {
   		_DISPVALUE ("DISP", range(-1,1)) = 0
   		_XPOS ("XPOS", float) = 0
   		_YPOS ("YPOS", float) = 0
   		_ZPOS ("ZPOS", float) = 0
   		_MOVE ("Move", float) = 0
   }
   SubShader {
   
      Pass {	
      	 Tags { "LightMode" = "ForwardBase" "Queue" = "Geometry" }

	     CGPROGRAM

	     #pragma vertex vert  
	     #pragma fragment frag 

		 #include "UnityCG.cginc"
		 #pragma target 3.0
 
 		uniform float4 _DiffuseColor;
 		uniform float4 _SpecularColor;
 		uniform float _Shininess;
 		uniform float _DISPVALUE;
 		uniform float _XPOS;
 		uniform float _YPOS;
 		uniform float _ZPOS;
 		uniform float _MOVE;
 		uniform bool _COLORBOOL;
 		
 			
         struct vertexInput {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
            
         };
         struct vertexOutput {
			float4 pos : SV_POSITION;
			float4 normal : TEXCOORD0;
			float4 worldPos: TEXCOORD1;
			float4 posInObjectCoords : TEXCOORD2;
			float4 col : COLOR;
         };
 
         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output;
            
            float4x4 modelMatrix = _Object2World;
            float4x4 viewMatrix = UNITY_MATRIX_V; 
            float4x4 projectionMatrix = UNITY_MATRIX_P;
            
            //Find the world position
            output.worldPos = mul(_Object2World,input.vertex);
            
            //Find the normals in world coordinates
            float4x4 modelMatrixInverse = _World2Object;
            output.normal = float4(normalize(mul(float4(input.normal,0),modelMatrixInverse).xyz),0);
            
            output.pos = mul(projectionMatrix,mul(viewMatrix,mul(modelMatrix,input.vertex)));
            
           // output.posInObjectCoords = input.vertex;
           
          // if(input.vertex.y > _DISPVALUE){ //THE BADASS ONE.
           
			 output.pos = mul(UNITY_MATRIX_MVP,input.vertex);
           
           
       		//float offsets = sin(2*_Time.y)+0.4; //float offsets = cos(2*_Time.y)*0.01+0.0;
       		
       		//output.col = float4(_XPOS,_YPOS,_ZPOS,1);
       		//output.col = input.vertex*offsets;
            
            
            return output;
         }
 
         float4 frag(vertexOutput input) : COLOR
         {
        //     float4 coloor = float4(1,1,0,1);
            return float4(_DISPVALUE*(_XPOS*0.1),_DISPVALUE*(_YPOS*0.1),_DISPVALUE*(_ZPOS*0.1),1);;
           // return output;
            
         }
         ENDCG
      }
   }
}