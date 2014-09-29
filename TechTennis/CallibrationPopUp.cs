using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KinectSkeletonApplication2
{
    public partial class CallibrationPopUp : Form
    {
        private bool finishedRUC = false;
        private bool finishedLLC = false;
        public bool calibrated = false;

        public CallibrationPopUp()
        {
            InitializeComponent();
            MainWindow.calibrated = false;
            lKTOKButton.Enabled = false;
            rKTOKButton.Enabled = false;
            rKBOKButton.Enabled = false;
            lKBOKButton.Enabled = false;
        }

        public bool isFinished()
        {
            return finishedLLC&&finishedRUC;
        }


        private void callibrationOK_Click(object sender, EventArgs e)
        {
            int xVal;
            int yVal;
            int zVal;
            try
            {
                xVal = Convert.ToInt32(xBox.Text);
                yVal = Convert.ToInt32(yBox.Text);
                zVal = Convert.ToInt32(zBox.Text);
                MainWindow.socketEmitPosition(xVal,yVal,zVal);
            }
            catch (FormatException)
            {
                Console.WriteLine("X,Y and Z must be numbers");
            }
            catch (OverflowException)
            {
                Console.WriteLine("X,Y or Z is ither too big or too small");
            }
        }

        private void lightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (lightCheckBox.Checked)
            {
                MainWindow.socketEmitColor("#ffffff");
            }
            else
            {
                MainWindow.socketEmitColor("#000000");
            }
        }

        private void tRCOKButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                MainWindow.canvasTRX = Convert.ToInt32(yBox.Text);
                MainWindow.canvasTRY = Convert.ToInt32(zBox.Text);
                tRCOKButton.Enabled = false;
                if (xBox.Enabled)
                {
                    try
                    {
                        MainWindow.abstandToCanvas = Convert.ToInt32(xBox.Text);
                        xBox.Enabled = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Z must be a number");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Z is ither too big or too small");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("X and Y must be numbers");
            }
            catch (OverflowException)
            {
                Console.WriteLine("X or Y is ither too big or too small");
            }
            if (!bLCOKButton.Enabled)
            {
                lKTOKButton.Enabled = true;
                rKTOKButton.Enabled = true;
                rKBOKButton.Enabled = true;
                lKBOKButton.Enabled = true;
            }
           
        }

        private void bLCOKButton_Click(object sender, EventArgs e)
        {
            try
            {
                MainWindow.canvasBLX = Convert.ToInt32(yBox.Text);
                MainWindow.canvasBLY = Convert.ToInt32(zBox.Text);
                bLCOKButton.Enabled = false;
                if (xBox.Enabled)
                {
                    try
                    {
                        MainWindow.abstandToCanvas = Convert.ToInt32(xBox.Text);
                        xBox.Enabled = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Z must be a number");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Z is ither too big or too small");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("X and Y must be numbers");
            }
            catch (OverflowException)
            {
                Console.WriteLine("X or Y is ither too big or too small");
            }

            if (!tRCOKButton.Enabled)
            {
                lKTOKButton.Enabled = true;
                rKTOKButton.Enabled = true;
                rKBOKButton.Enabled = true;
                lKBOKButton.Enabled = true;
            }
        }

        private void ScreenFacingAway_CheckedChanged(object sender, EventArgs e)
        {
            if(ScreenFacingAway.Checked)
                MainWindow.screenFacingAway = true;
            if (!ScreenFacingAway.Checked)
                MainWindow.screenFacingAway = false;
        }

        private void fieldOKCLick(object sender, EventArgs e)
        {
            if (!tRCOKButton.Enabled && !bLCOKButton.Enabled && lKTOKButton.Enabled == false &&
                rKTOKButton.Enabled == false &&
                rKBOKButton.Enabled == false &&
                lKBOKButton.Enabled == false)
            {
                MainWindow.calibrated = true;
                this.Close();
            }
        }

        private void lKTOKButton_Click(object sender, EventArgs e)
        {
            if (MainWindow.leftKRKPos != 0.0)
            {
                MainWindow.leftKTop = MainWindow.leftKRKPos * 100;
                lKTOKButton.Enabled = false;
            }
            else
            {
                Console.WriteLine("Kinect did not get a Skeleton Input yet");
            }
        }

        private void lKBOKButton_Click(object sender, EventArgs e)
        {
            if (MainWindow.leftKRKPos != 0.0)
            {
                MainWindow.leftKBot = MainWindow.leftKRKPos * 100;
                lKBOKButton.Enabled = false;
            }
            else
            {
                Console.WriteLine("Kinect did not get a Skeleton Input yet");
            }
        }

        private void rKTOKButton_Click(object sender, EventArgs e)
        {
            if (MainWindow.rightKRKPos != 0.0)
            {
                MainWindow.rightKTop = MainWindow.rightKRKPos * 100;
                rKTOKButton.Enabled = false;
            }
            else
            {
                rightKinectStatus.Text = "Skeleton Empty";
                Console.WriteLine("Kinect did not get a Skeleton Input yet");
            }
        }

        private void rKBOKButton_Click(object sender, EventArgs e)
        {
            if (MainWindow.rightKRKPos != 0.0)
            {
                MainWindow.rightKBot = MainWindow.rightKRKPos * 100;
                rKBOKButton.Enabled = false;
            }
            else
            {
                rightKinectStatus.Text = "Skeleton Empty";
                Console.WriteLine("Kinect did not get a Skeleton Input yet");
            }
        }

        private void leftKElevBar_Scroll(object sender, EventArgs e)
        {
            MainWindow.sensor1.ElevationAngle = leftKElevBar.Value;
        }

        private void rightKElevBar_Scroll(object sender, EventArgs e)
        {
            MainWindow.sensor2.ElevationAngle = rightKElevBar.Value;
        }

        private void CallibrationPopUp_Load(object sender, EventArgs e)
        {

        }

        private void lastSelectet_Click(object sender, EventArgs e)
        {
            MainWindow.calibrated = true;
        }

        private void showTimeSetter_Click(object sender, EventArgs e)
        {
            MainWindow.leftKTop = 76.031899452209473;
            MainWindow.leftKBot = -13.20858895778656;
            MainWindow.rightKTop = 92.502868175506592;
            MainWindow.rightKBot = 0.35070281010121107;
            MainWindow.canvasTRX = 100;
            MainWindow.canvasTRY = 150;
            MainWindow.canvasBLX = -150;
            MainWindow.canvasBLY = 30;
            MainWindow.calibrated = true;
            MainWindow.sensor1.ElevationAngle = 20;
            MainWindow.sensor2.ElevationAngle = 20;
            this.Close();
        }
    }
}
