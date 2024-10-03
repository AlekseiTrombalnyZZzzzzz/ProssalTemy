using System.ComponentModel;

namespace ProssalTemy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black);

            int x = 100;
            int y = 100;

            List<command> cmds = new List<command>()
            {
                new command("forward", "100"),
                new command("right", "90"),
                new command("forward", "100"),
                new command("right", "90"),
                new command("forward", "100"),
                new command("left", "-90"),
                new command("up", "-100"),
                new command("left", "90"),
                new command("forward", "50"),
                new command("right", "165"),
                new command("forward", "100"),
                new command("left", "30"),
                new command("forward", "100"),
                new command("left", "165"),
                new command("forward", "50"),
            };

            double a = 0;
            double[] angle = {0, 90, -90, 0};
            int forv = 100;

            for (int i = 0; i < cmds.Count; i++)
            {
                Point point1 = new(x, y);

                if (cmds[i].key == "right")
                    a += double.Parse(cmds[i].value);

                if (cmds[i].key == "left")
                    a += double.Parse(cmds[i].value);

                if (cmds[i].key == "forward")
                    forv = int.Parse(cmds[i].value);

                if (cmds[i].key == "up")
                    forv = int.Parse(cmds[i].value);

                if (cmds[i].key == "cler")
                    x = int.Parse(cmds[i].value); 

                x += (int)(forv * Math.Cos(a / 180 * Math.PI));
                y += (int)(forv * Math.Sin(a / 180 * Math.PI));

                Point point2 = new(x, y);

                e.Graphics.DrawLine(pen, point1, point2);

                forv = 0;
            }
        }
        public class command
        {
            public string key;
            public string value;
            public command(string key, string value) 
            {
                this.key = key;
                this.value = value;
            }
        }
    }
}
