using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MarkerPositions
{
    public class MarkerMediator
    {
        List<Marker> markers = new List<Marker>();

        public Marker CreateMarker()
        {
            var marker = new Marker();
            marker.SetMediator(this);
            markers.Add(marker);
            return marker;
        }
        public void Send(Point location, Marker marker)
        {
            markers.Where(m => m != marker).ToList().ForEach(m => m.ReceiveLocation(location));
        }
    }
}
