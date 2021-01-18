using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MarkerPositions
{
    public class Marker:Label
    {
        private MarkerMediator mediator;
        private Point mouseDownLocation;
        public Marker()
        {
            Text = "Drag me";
            TextAlign = ContentAlignment.MiddleCenter;
            MouseDown += OnMouseDown;
            MouseMove += OnMouseMove;
        }
        public void SetMediator(MarkerMediator mediator)
        {
            this.mediator = mediator;
        }
        public void Send(Point location)
        {
            mediator.Send(location, this);
        }
        internal void ReceiveLocation(Point location)
        {
            var distance = CalculateDistance(location);
            if (distance < 100 && BackColor != Color.Red)
                BackColor = Color.Red;
            else if (distance >= 100 && BackColor != Color.Green)
                BackColor = Color.Green;
            double CalculateDistance(Point point) => Math.Sqrt(Math.Pow((point.X - Location.X), 2) + Math.Pow((point.Y - Location.Y), 2));
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mouseDownLocation = e.Location;
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Text = Location.ToString();
                Left = e.X - mouseDownLocation.X + Left;
                Top = e.Y + Top - mouseDownLocation.Y;
                mediator.Send(Location, this);
            }
        }
    }
}
