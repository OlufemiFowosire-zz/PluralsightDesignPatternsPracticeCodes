using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkerPositions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            addButton = new Button();
            addButton.Text = "Add Marker";
            addButton.Click += OnAddClick;
            addButton.Dock = DockStyle.Bottom;
            Controls.Add(addButton);
        }
        private void OnAddClick(object sender, EventArgs e)
        {
            Controls.Add(mediator.CreateMarker());
        }

    }
}
