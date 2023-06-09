﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Random_Graph_Generator
{
    internal class LineContainer
    {
        public Vertex v1;
        public Vertex v2;
        public Line line;
        public int weight;
        public int weightX;
        public int weightY;
        public TextBlock text;

        public LineContainer(Vertex v1, Vertex v2, Line line, int min, int max, int[,] matrix)
        {
            Random random = new Random();

            this.v1 = v1;
            this.v2 = v2;
            this.line = line;
            weight = random.Next(max - min + 1) + min;
            matrix[v1.vertexNumber, v2.vertexNumber] = weight;
            matrix[v2.vertexNumber, v1.vertexNumber] = weight;

            // tu się dzieje magia, bo nie chciało mi się liczyć prostopadłych punktów, ale działa, więc po co drążyć temat
            if ((v1.X > v2.X && v1.Y > v2.Y) || (v1.X < v2.X && v1.Y < v2.Y)) 
            {
                weightX = ((v1.X + v2.X) / 2) + 10;
                weightY = ((v1.Y + v2.Y) / 2) - 10;
            }
            else if ((v1.X < v2.X && v1.Y > v2.Y) || (v1.X > v2.X && v1.Y < v2.Y)) 
            {
                weightX = ((v1.X + v2.X) / 2) + 10;
                weightY = ((v1.Y + v2.Y) / 2) + 10;
            }
            else
            {
                weightX = ((v1.X + v2.X) / 2) - 10;
                weightY = ((v1.Y + v2.Y) / 2) + 10;
            }
            

            text = new TextBlock();
            text.Text = weight.ToString();
        }
    }
}
