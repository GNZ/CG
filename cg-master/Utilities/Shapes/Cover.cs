using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Utilities.Shaders;

namespace Utilities
{
    public class Cover : Sweep
    {
        public float aux = 0.15f;

        public Cover(float height, float width, float lenght,float radius, int num_steps, ProgramObject program)
            : base(num_steps, program)
        {
            float x = width / 2;
            float y = lenght / 2;
            Vertex[] vertices = new Vertex[]{
               new Vertex(-x, -y + radius, 0, 1.0f),
               new Vertex(-x + radius, -y, 0, 1.0f),
               new Vertex(x - radius, -y, 0, 1.0f),
               new Vertex(x, -y + radius, 0, 1.0f),
               new Vertex(x, y - radius, 0, 1.0f),
               new Vertex(x - radius, y, 0, 1),
               new Vertex(-x + radius, y, 0, 1.0f),
               new Vertex(-x, y - radius, 0, 1.0f)
            };

            Vector2[][] textures = new Vector2[vertices.Length][];
            for (int i = 0; i < vertices.Length; i++)
            {
                textures[i] = new Vector2[4];
                textures[i][0] = new Vector2((i % 2) / 2, 0);
                textures[i][1] = new Vector2((i % 2) / 2 + 0.5f, 0);
                textures[i][2] = new Vector2((i % 2) / 2, 1f);
                textures[i][3] = new Vector2((i % 2) / 2 + 0.5f, 1f);
            }

            float height_step = height / num_steps;

            createSweep(vertices, new Vector4(0, 1f, 0, 1f),
                new Func<int, int, Matrix4>(
                    delegate(int current, int steps)
                    {
                        return Matrix4.CreateTranslation(new Vector3(0, 0, height_step));
                    }
                ),
                new Func<int, int, Matrix4>(
                    delegate(int current, int steps)
                    {
                        return Matrix4.Identity;
                    }
                ),
                new Func<int, int, Matrix4>(
                    delegate(int current, int steps)
                    {
                        return Matrix4.Identity;
                    }
                )
                , textures);
        }

    }
}
