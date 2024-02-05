using System;

public class Camara {
    public vec3 position = new vec3(0,0,0);
    public vec2 angle = new vec2(0,(float)Math.PI/2);

    public Ray[] ray;

    public Camara(){
        this.ray = new Ray[App.window.pixel.Length];

        foreach (var p in App.window.pixel) {
            this.ray[(int)(p.id.x + p.id.y * App.window.ClientSize.Width)] = new Ray(
                this.position,
                new vec3(p.id.x-(int)(App.window.ClientSize.Width*0.5),p.id.y-(int)(App.window.ClientSize.Height*0.5), 1)
            );
        }
    }

    public double distance(vec3 point){
        return Math.Sqrt(
            Math.Pow(point.x - App.camara.position.x, 2) +
            Math.Pow(point.y - App.camara.position.y, 2) +
            Math.Pow(point.z - App.camara.position.z, 2)
        );
    }

    public vec3 translete(vec3 point) {
        // para angulo y (x,z)
        double a = Math.Atan2(point.x - App.camara.position.x, point.z - App.camara.position.z);
        double b = Math.PI-a-Math.PI/2;
        double c = App.camara.angle.y - Math.PI/2 - b;

        double h = (point.z - App.camara.position.z) / Math.Cos(a);

        // para angulo x (y)
        double d = Math.Atan2(h, point.y - App.camara.position.y);
        double e = Math.PI-d-Math.PI/2;
        double f = App.camara.angle.x - Math.PI/2 - e;

        double i = (point.y - App.camara.position.y) / Math.Cos(d);

        return new vec3(
                (float)(Math.Cos(c) * h),
                (float)(Math.Cos(f) * i),
                (float)(Math.Sin(c) * h));
    }

    public vec2 project(vec3 point) {
        vec3 p = App.camara.translete(point);
        if (p.z <= 0)
            return new vec2(
                    (float)(p.x*(12800/App.camara.distance(point)*0.1f))+(int)(App.window.ClientSize.Width*0.5),
                    (float)(p.y*(12800/App.camara.distance(point)*0.1f))+(int)(App.window.ClientSize.Height*0.5));
        else
            return new vec2(1000, 1000);
    }
};