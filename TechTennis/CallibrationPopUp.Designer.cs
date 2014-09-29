namespace KinectSkeletonApplication2
{
    partial class CallibrationPopUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.zLabel = new System.Windows.Forms.Label();
            this.callibrationOK = new System.Windows.Forms.Button();
            this.xBox = new System.Windows.Forms.TextBox();
            this.yBox = new System.Windows.Forms.TextBox();
            this.zBox = new System.Windows.Forms.TextBox();
            this.lightCheckBox = new System.Windows.Forms.CheckBox();
            this.tRCOKButton = new System.Windows.Forms.Button();
            this.bLCOKButton = new System.Windows.Forms.Button();
            this.ScreenFacingAway = new System.Windows.Forms.CheckBox();
            this.lKTOKButton = new System.Windows.Forms.Button();
            this.lKBOKButton = new System.Windows.Forms.Button();
            this.rKTOKButton = new System.Windows.Forms.Button();
            this.rKBOKButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.leftKElevBar = new System.Windows.Forms.TrackBar();
            this.rightKElevBar = new System.Windows.Forms.TrackBar();
            this.leftKinectStatus = new System.Windows.Forms.Label();
            this.rightKinectStatus = new System.Windows.Forms.Label();
            this.lastSettings = new System.Windows.Forms.Button();
            this.showTimeSetter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.leftKElevBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightKElevBar)).BeginInit();
            this.SuspendLayout();
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(40, 12);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(14, 13);
            this.xLabel.TabIndex = 3;
            this.xLabel.Text = "X";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(40, 96);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(14, 13);
            this.yLabel.TabIndex = 4;
            this.yLabel.Text = "Y";
            // 
            // zLabel
            // 
            this.zLabel.AutoSize = true;
            this.zLabel.Location = new System.Drawing.Point(40, 188);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(14, 13);
            this.zLabel.TabIndex = 5;
            this.zLabel.Text = "Z";
            // 
            // callibrationOK
            // 
            this.callibrationOK.Location = new System.Drawing.Point(175, 242);
            this.callibrationOK.Name = "callibrationOK";
            this.callibrationOK.Size = new System.Drawing.Size(79, 21);
            this.callibrationOK.TabIndex = 7;
            this.callibrationOK.Text = "Move";
            this.callibrationOK.UseVisualStyleBackColor = true;
            this.callibrationOK.Click += new System.EventHandler(this.callibrationOK_Click);
            // 
            // xBox
            // 
            this.xBox.Location = new System.Drawing.Point(91, 13);
            this.xBox.Name = "xBox";
            this.xBox.Size = new System.Drawing.Size(163, 20);
            this.xBox.TabIndex = 8;
            // 
            // yBox
            // 
            this.yBox.Location = new System.Drawing.Point(91, 93);
            this.yBox.Name = "yBox";
            this.yBox.Size = new System.Drawing.Size(163, 20);
            this.yBox.TabIndex = 9;
            // 
            // zBox
            // 
            this.zBox.Location = new System.Drawing.Point(91, 185);
            this.zBox.Name = "zBox";
            this.zBox.Size = new System.Drawing.Size(163, 20);
            this.zBox.TabIndex = 10;
            // 
            // lightCheckBox
            // 
            this.lightCheckBox.AutoSize = true;
            this.lightCheckBox.Location = new System.Drawing.Point(43, 242);
            this.lightCheckBox.Name = "lightCheckBox";
            this.lightCheckBox.Size = new System.Drawing.Size(49, 17);
            this.lightCheckBox.TabIndex = 11;
            this.lightCheckBox.Text = "Light";
            this.lightCheckBox.UseVisualStyleBackColor = true;
            this.lightCheckBox.CheckedChanged += new System.EventHandler(this.lightCheckBox_CheckedChanged);
            // 
            // tRCOKButton
            // 
            this.tRCOKButton.Location = new System.Drawing.Point(17, 278);
            this.tRCOKButton.Name = "tRCOKButton";
            this.tRCOKButton.Size = new System.Drawing.Size(75, 37);
            this.tRCOKButton.TabIndex = 12;
            this.tRCOKButton.Text = "Top Right Corner OK";
            this.tRCOKButton.UseVisualStyleBackColor = true;
            this.tRCOKButton.Click += new System.EventHandler(this.tRCOKButton_Click);
            // 
            // bLCOKButton
            // 
            this.bLCOKButton.Location = new System.Drawing.Point(98, 279);
            this.bLCOKButton.Name = "bLCOKButton";
            this.bLCOKButton.Size = new System.Drawing.Size(75, 37);
            this.bLCOKButton.TabIndex = 13;
            this.bLCOKButton.Text = "Bottom Left Corner OK";
            this.bLCOKButton.UseVisualStyleBackColor = true;
            this.bLCOKButton.Click += new System.EventHandler(this.bLCOKButton_Click);
            // 
            // ScreenFacingAway
            // 
            this.ScreenFacingAway.AutoSize = true;
            this.ScreenFacingAway.Location = new System.Drawing.Point(43, 322);
            this.ScreenFacingAway.Name = "ScreenFacingAway";
            this.ScreenFacingAway.Size = new System.Drawing.Size(124, 17);
            this.ScreenFacingAway.TabIndex = 14;
            this.ScreenFacingAway.Text = "Screen Facing Away";
            this.ScreenFacingAway.UseVisualStyleBackColor = true;
            this.ScreenFacingAway.CheckedChanged += new System.EventHandler(this.ScreenFacingAway_CheckedChanged);
            // 
            // lKTOKButton
            // 
            this.lKTOKButton.Location = new System.Drawing.Point(290, 13);
            this.lKTOKButton.Name = "lKTOKButton";
            this.lKTOKButton.Size = new System.Drawing.Size(116, 48);
            this.lKTOKButton.TabIndex = 16;
            this.lKTOKButton.Text = "Left Kinect Top OK";
            this.lKTOKButton.UseVisualStyleBackColor = true;
            this.lKTOKButton.Click += new System.EventHandler(this.lKTOKButton_Click);
            // 
            // lKBOKButton
            // 
            this.lKBOKButton.Location = new System.Drawing.Point(290, 67);
            this.lKBOKButton.Name = "lKBOKButton";
            this.lKBOKButton.Size = new System.Drawing.Size(116, 48);
            this.lKBOKButton.TabIndex = 17;
            this.lKBOKButton.Text = "Left Kinect Bottom OK";
            this.lKBOKButton.UseVisualStyleBackColor = true;
            this.lKBOKButton.Click += new System.EventHandler(this.lKBOKButton_Click);
            // 
            // rKTOKButton
            // 
            this.rKTOKButton.Location = new System.Drawing.Point(290, 185);
            this.rKTOKButton.Name = "rKTOKButton";
            this.rKTOKButton.Size = new System.Drawing.Size(116, 48);
            this.rKTOKButton.TabIndex = 18;
            this.rKTOKButton.Text = "Right Kinect Top OK";
            this.rKTOKButton.UseVisualStyleBackColor = true;
            this.rKTOKButton.Click += new System.EventHandler(this.rKTOKButton_Click);
            // 
            // rKBOKButton
            // 
            this.rKBOKButton.Location = new System.Drawing.Point(290, 242);
            this.rKBOKButton.Name = "rKBOKButton";
            this.rKBOKButton.Size = new System.Drawing.Size(116, 48);
            this.rKBOKButton.TabIndex = 19;
            this.rKBOKButton.Text = "Right Kinect Bottom OK";
            this.rKBOKButton.UseVisualStyleBackColor = true;
            this.rKBOKButton.Click += new System.EventHandler(this.rKBOKButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 38);
            this.button1.TabIndex = 15;
            this.button1.Text = "Field OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.fieldOKCLick);
            // 
            // leftKElevBar
            // 
            this.leftKElevBar.Location = new System.Drawing.Point(431, 13);
            this.leftKElevBar.Maximum = 27;
            this.leftKElevBar.Minimum = -27;
            this.leftKElevBar.Name = "leftKElevBar";
            this.leftKElevBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.leftKElevBar.Size = new System.Drawing.Size(45, 104);
            this.leftKElevBar.TabIndex = 20;
            this.leftKElevBar.Scroll += new System.EventHandler(this.leftKElevBar_Scroll);
            // 
            // rightKElevBar
            // 
            this.rightKElevBar.Location = new System.Drawing.Point(431, 188);
            this.rightKElevBar.Maximum = 27;
            this.rightKElevBar.Minimum = -27;
            this.rightKElevBar.Name = "rightKElevBar";
            this.rightKElevBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.rightKElevBar.Size = new System.Drawing.Size(45, 104);
            this.rightKElevBar.TabIndex = 21;
            this.rightKElevBar.Scroll += new System.EventHandler(this.rightKElevBar_Scroll);
            // 
            // leftKinectStatus
            // 
            this.leftKinectStatus.AutoSize = true;
            this.leftKinectStatus.Location = new System.Drawing.Point(290, 122);
            this.leftKinectStatus.Name = "leftKinectStatus";
            this.leftKinectStatus.Size = new System.Drawing.Size(10, 13);
            this.leftKinectStatus.TabIndex = 22;
            this.leftKinectStatus.Text = " ";
            // 
            // rightKinectStatus
            // 
            this.rightKinectStatus.AutoSize = true;
            this.rightKinectStatus.Location = new System.Drawing.Point(290, 303);
            this.rightKinectStatus.Name = "rightKinectStatus";
            this.rightKinectStatus.Size = new System.Drawing.Size(0, 13);
            this.rightKinectStatus.TabIndex = 23;
            // 
            // lastSettings
            // 
            this.lastSettings.Location = new System.Drawing.Point(290, 316);
            this.lastSettings.Name = "lastSettings";
            this.lastSettings.Size = new System.Drawing.Size(78, 34);
            this.lastSettings.TabIndex = 24;
            this.lastSettings.Text = "Take Last Settings";
            this.lastSettings.UseVisualStyleBackColor = true;
            this.lastSettings.Click += new System.EventHandler(this.lastSelectet_Click);
            // 
            // showTimeSetter
            // 
            this.showTimeSetter.Location = new System.Drawing.Point(374, 316);
            this.showTimeSetter.Name = "showTimeSetter";
            this.showTimeSetter.Size = new System.Drawing.Size(75, 34);
            this.showTimeSetter.TabIndex = 25;
            this.showTimeSetter.Text = "Showtime Settings";
            this.showTimeSetter.UseVisualStyleBackColor = true;
            this.showTimeSetter.Click += new System.EventHandler(this.showTimeSetter_Click);
            // 
            // CallibrationPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 362);
            this.ControlBox = false;
            this.Controls.Add(this.showTimeSetter);
            this.Controls.Add(this.lastSettings);
            this.Controls.Add(this.rightKinectStatus);
            this.Controls.Add(this.leftKinectStatus);
            this.Controls.Add(this.rightKElevBar);
            this.Controls.Add(this.leftKElevBar);
            this.Controls.Add(this.rKBOKButton);
            this.Controls.Add(this.rKTOKButton);
            this.Controls.Add(this.lKBOKButton);
            this.Controls.Add(this.lKTOKButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ScreenFacingAway);
            this.Controls.Add(this.bLCOKButton);
            this.Controls.Add(this.tRCOKButton);
            this.Controls.Add(this.lightCheckBox);
            this.Controls.Add(this.zBox);
            this.Controls.Add(this.yBox);
            this.Controls.Add(this.xBox);
            this.Controls.Add(this.callibrationOK);
            this.Controls.Add(this.zLabel);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.xLabel);
            this.Name = "CallibrationPopUp";
            this.ShowIcon = false;
            this.Text = "Callibration       Everything in cm";
            this.Load += new System.EventHandler(this.CallibrationPopUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.leftKElevBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightKElevBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label zLabel;
        private System.Windows.Forms.Button callibrationOK;
        private System.Windows.Forms.TextBox xBox;
        private System.Windows.Forms.TextBox yBox;
        private System.Windows.Forms.TextBox zBox;
        private System.Windows.Forms.CheckBox lightCheckBox;
        private System.Windows.Forms.Button tRCOKButton;
        private System.Windows.Forms.Button bLCOKButton;
        private System.Windows.Forms.CheckBox ScreenFacingAway;
        private System.Windows.Forms.Button lKTOKButton;
        private System.Windows.Forms.Button lKBOKButton;
        private System.Windows.Forms.Button rKTOKButton;
        private System.Windows.Forms.Button rKBOKButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar leftKElevBar;
        private System.Windows.Forms.TrackBar rightKElevBar;
        private System.Windows.Forms.Label leftKinectStatus;
        private System.Windows.Forms.Label rightKinectStatus;
        private System.Windows.Forms.Button lastSettings;
        private System.Windows.Forms.Button showTimeSetter;


    }
}