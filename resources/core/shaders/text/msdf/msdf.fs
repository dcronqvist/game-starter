#version 330 core
out vec4 FragColor;
in vec2 TexCoords;

uniform sampler2D msdf;
uniform vec4 bgColor;
uniform vec4 fgColor;
uniform float pxRange; // set to distance field's pixel range

float median(float r, float g, float b) {
    return max(min(r, g), min(max(r, g), b));
}


float screenPxRange() {
    vec2 unitRange = vec2(pxRange)/vec2(textureSize(msdf, 0));
    vec2 screenTexSize = vec2(1.0)/fwidth(TexCoords);
    return max(0.5*dot(unitRange, screenTexSize), 1.0);
}

void main() {
    vec3 msd = texture(msdf, TexCoords).rgb;
    float sd = median(msd.r, msd.g, msd.b);
    float screenPxDistance = screenPxRange()*(sd - 0.5);
    float opacity = clamp(screenPxDistance + 0.5, 0.0, 1.0);
    FragColor = mix(bgColor, fgColor, opacity);
}