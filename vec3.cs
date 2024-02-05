using System;

public class vec3{
	public float x, y, z;

	public vec3(float x, float y, float z){
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public float modul(){
		return (float)Math.Sqrt(this.x*this.x+this.y*this.y+this.z*this.z);
	}

	public float dot(vec3 v){
		return this.x*v.x+this.y*v.y+this.z*v.z;
	}

	public static vec3 operator +(vec3 left, vec3 right) {
        return new vec3(left.x + right.x, left.y + right.y, left.z + right.z);
    }

    public static vec3 operator *(vec3 left, vec3 right) {
        return new vec3(left.x * right.x, left.y * right.y, left.z * right.z);
    }
};