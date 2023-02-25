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