using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using Utilities.Shaders;
using Utilities;
using OpenTK;

namespace Lab5
{
    public partial class Form1 : Form
    {

        float distance;
        float size;
        int steps;
        float aux;

        public Form1()
        {
            InitializeComponent();
            distance = 25;
            size = 20;
            steps = 15;
            aux = 0.5f;
        }

        private void OpenGLcontrol_load(object sender, EventArgs e)
        {
            ProgramObject prog = new ProgramObject(
                new VertexShader(Shaders.VERTEX_SHADER_TEXTURE),
                    new FragmentShader(Shaders.FRAGMENT_SHADER_ILLUMINATION));

            //Draw draw = new Draw(prog, BeginMode.LineLoop);

            /*Vertex[] vertices = new Vertex[]{
                new Vertex(new Vector4(0.5f, -0.5f, 0, 1f)),
                new Vertex(new Vector4(-0.5f, -0.5f, 0, 1f)),
                new Vertex(new Vector4(-0.5f, 0.5f, 0, 1f)),
                new Vertex(new Vector4(0.5f, 0.5f, 0, 1f)),
            };*/


           Cylinder sweepF = new Cylinder(50f,0.1f,4,new Vector4(1f, 0,0,1f),prog);
            openGLControl1.objects.Add(sweepF);


          Cover[] sweeps = new Cover[9];


            for (int i = 0; i < 9; i++)
            {
                sweeps[i] = new Cover(15, size, size, aux, 1, prog);
                sweeps[i].colored = true;
                openGLControl1.objects.Add(sweeps[i]);
            }

            //openGLControl1.objects.Add(sweep);

            //sweep.transformation = Matrix4.CreateTranslation(0, -0.65f, 0);
            //sweep2.transformation = Matrix4.CreateTranslation(0, 0, 0);
            sweeps[1].transformation = Matrix4.CreateTranslation(distance, 0.0f, 0.0f);
            sweeps[2].transformation = Matrix4.CreateTranslation(-distance, 0.0f, 0.0f);
            sweeps[3].transformation = Matrix4.CreateTranslation(0.0f, distance, 0);
            sweeps[4].transformation = Matrix4.CreateTranslation(0.0f, -distance, 0);
            sweeps[5].transformation = Matrix4.CreateTranslation(distance, distance, 0);
            sweeps[6].transformation = Matrix4.CreateTranslation(-distance, distance, 0);
            sweeps[7].transformation = Matrix4.CreateTranslation(-distance, -distance, 0);
            sweeps[8].transformation = Matrix4.CreateTranslation(distance, -distance, 0);

            openGLControl1.load();
        }

    }
}
