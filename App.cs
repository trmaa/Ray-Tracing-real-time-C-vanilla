using System;
using System.Windows.Forms;

public class App {
    public static Window window = new Window("Renderer",new vec2(1280,720));
    public static Camara camara = new Camara();

    public static Sphere sphere = new Sphere(new vec3(0,0,5),2);
    public static Sphere sphere2 = new Sphere(new vec3(20,15,10),5);

    public static void Main(){
        Timer timer = new Timer();
        timer.Interval = 16;
        timer.Tick += (sender, e) => update();
        timer.Start();
    
        Application.Run(window);
    }

    private static void update(){
        App.camara.move();
        App.window.Invalidate();
    }
};