#VERTEX_BEGIN
#version 330 core
layout (location = 0) in vec2 position; // vec2 position
layout (location = 1) in vec4 color; // vec4 

out vec4 vertexColor;
out vec2 fragPos;

uniform mat4 model;
uniform mat4 projection;

void main()
{
	fragPos = vec2((model * vec4(position.xy, 0.0, 1.0)).xy);
	vertexColor = color;
    gl_Position = projection * model * vec4(position.xy, 0.0, 1.0);
}
#VERTEX_END

#FRAGMENT_BEGIN
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
#FRAGMENT_END