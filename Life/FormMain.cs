using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Life {
    public partial class FormMain : Form {
        public FormMain() {
            InitializeComponent();
            place = new Life.LifePlace(50, 50);
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e) {
            place.Step();
            FormMain_Paint(this, null);
            //for (int i = 0; i < place.Width; i++)
            //    for (int j = 0; j < place.Height; j++)
        }

        LifePlace place;

        private void FormMain_Paint(object sender, PaintEventArgs e) {
            int m = 5;
            using (SolidBrush redBrush = new SolidBrush(Color.Red)) {
                using (SolidBrush blackBrush = new SolidBrush(Color.Black)) {
                    using (Graphics formGraphics = this.CreateGraphics()) {
                        formGraphics.FillRectangle(redBrush, new Rectangle(0, 0, place.Width * m, place.Height * m));
                        for (int i = 0; i < place.Width; i++)
                            for (int j = 0; j < place.Height; j++)
                                if (place.Place[i, j].Alive) {
                                    formGraphics.FillRectangle(redBrush, new Rectangle(m * i, m * j, m - 1, m - 1));
                                }
                                else {
                                    formGraphics.FillRectangle(blackBrush, new Rectangle(m * i, m * j, m - 1, m - 1));
                                }
                    }
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e) {
            timer1.Enabled = true;
        }

        private void FormMain_DoubleClick(object sender, EventArgs e) {
            timer1.Enabled = false;
            place.Populate();
            FormMain_Paint(this, null);
            timer1.Enabled = true;
        }
    }
}
