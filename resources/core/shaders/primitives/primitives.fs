#version 330 core
out vec4 FragColor;
in vec4 vertexColor;
in vec2 fragPos;

uniform vec2 middlePos;
uniform float distToMid;
uniform bool useFalloff;

void main()
{
	if(useFalloff)
	{
		float dist = length(fragPos - middlePos) / distToMid;
		
		float A = 30;
		
		//float factor = 1.0 - exp(A * dist - A + (A / 10.0));
		
		float factor = 1.0 / (1.0 + (exp(A * dist - (A / 4.0))));
		
		FragColor = vec4(vertexColor.rgb, (factor) * vertexColor.a);
	}
	else
	{
		FragColor = vertexColor;
	}
} 