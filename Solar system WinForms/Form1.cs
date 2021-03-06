﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solar_system_WinForms
{
    public partial class Form1 : Form
    {
        Planet mercury;
        Planet venus;
        Planet earth;
        Planet mars;
        Planet jupiter;
        Planet saturn;
        Planet uranus;
        Planet neptun;
        Planet pluton;
        Satelite moon;
        Satelite phobos;
        Satelite deimos;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mercury = new Planet(mercuryImage, Height / 2 - mercuryImage.Location.Y, 4.75);
            venus = new Planet(venusImage, Height / 2 - venusImage.Location.Y, 5.48);
            earth = new Planet(earthImage, Height / 2 - earthImage.Location.Y, 6.84);
            mars = new Planet(marsImage, Height / 2 - marsImage.Location.Y, 9.67);
            jupiter = new Planet(jupiterImage, Height / 2 - jupiterImage.Location.Y, 13.07);
            saturn = new Planet(saturnImage, Height / 2 - saturnImage.Location.Y, 24.13);
            uranus = new Planet(uranusImage, Height / 2 - uranusImage.Location.Y, 29.76);
            neptun = new Planet(neptunImage, Height / 2 - neptunImage.Location.Y, 35.02);
            pluton = new Planet(plutonImage, Height / 2 - plutonImage.Location.Y, 47.87);
            moon = new Satelite(moonImage, earthImage.Location.X + earthImage.Width / 2 - moonImage.Location.X + moonImage.Width / 2, 3);
            phobos = new Satelite(phobosImage, marsImage.Location.X + marsImage.Width / 2 - phobosImage.Location.X + phobosImage.Width / 2, 3);
            deimos = new Satelite(deimosImage, marsImage.Location.X + marsImage.Width / 2 - deimosImage.Location.X + deimosImage.Width / 2, 4);
            /*do
            {
                mercury.Move();
                venus.Move();
                earth.Move();
                moon.Move(earth);
                mars.Move();
                phobos.Move(mars);
                deimos.Move(mars);
                jupiter.Move();
                saturn.Move();
                uranus.Move();
                neptun.Move();
                pluton.Move();
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
            } while (true);*/
            timer1.Start();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void uranusImage_Click(object sender, EventArgs e)
        {

        }

        private void neptunImage_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mercury.Move();
            venus.Move();
            earth.Move();
            moon.Move(earth);
            mars.Move();
            phobos.Move(mars);
            deimos.Move(mars);
            jupiter.Move();
            saturn.Move();
            uranus.Move();
            neptun.Move();
            pluton.Move();
        }
    }


    class Planet
    {
        protected double speed;
        protected int distanceToSun;
        protected double angle;
        protected PictureBox imageObject;
        Point startLocation;

        public int X { get; set; }
        public int Y { get; set; }
        
        public Planet(PictureBox imagePlanet, int rotateRadius, double speed)
        {
            this.speed = speed;
            angle = -190;
            distanceToSun = rotateRadius;
            imageObject = imagePlanet;
            startLocation = imageObject.Location;
        }
        public void Move()
        {
            angle += Math.PI / speed;
            X = 540 + (int)(distanceToSun * Math.Cos(angle));
            Y = 390 + (int)(distanceToSun * Math.Sin(angle));
            imageObject.Location = new Point(X, Y);

        }
    }

    class Satelite : Planet 
    {
        public Satelite (PictureBox imagePlanet, int rotateRadius, double speed) 
            : base (imagePlanet, rotateRadius, speed)
        { }
        public void Move(Planet planet)
        {
            angle += Math.PI / speed;
            X = planet.X + (int)(distanceToSun * Math.Cos(angle));
            Y = planet.Y + (int)(distanceToSun * Math.Sin(angle));
            imageObject.Location = new Point(X, Y);
        }
    }
}
