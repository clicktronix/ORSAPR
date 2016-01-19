namespace GasketModelGUI
{
    partial class UserInterfaceForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.RunInventorButton = new System.Windows.Forms.Button();
            this.CreateModelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.DepthOfNotchInTheStern = new GasketModelGUI.ParameterObjectControl();
            this.FromStartToCenterNose = new GasketModelGUI.ParameterObjectControl();
            this.GasketLenght = new GasketModelGUI.ParameterObjectControl();
            this.GasketHeight = new GasketModelGUI.ParameterObjectControl();
            this.GasketWidth = new GasketModelGUI.ParameterObjectControl();
            this.BetweenCentRad = new GasketModelGUI.ParameterObjectControl();
            this.BeforeShear = new GasketModelGUI.ParameterObjectControl();
            this.CenterToTheEdge = new GasketModelGUI.ParameterObjectControl();
            this.AbaloneAround = new GasketModelGUI.ParameterObjectControl();
            this.RadiusEdges = new GasketModelGUI.ParameterObjectControl();
            this.RadiusProw = new GasketModelGUI.ParameterObjectControl();
            this.RadiusStern = new GasketModelGUI.ParameterObjectControl();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // RunInventorButton
            // 
            this.RunInventorButton.Location = new System.Drawing.Point(4, 9);
            this.RunInventorButton.Name = "RunInventorButton";
            this.RunInventorButton.Size = new System.Drawing.Size(91, 40);
            this.RunInventorButton.TabIndex = 11;
            this.RunInventorButton.Text = "Запустить Inventor";
            this.RunInventorButton.UseVisualStyleBackColor = true;
            this.RunInventorButton.Click += new System.EventHandler(this.RunInventorButton_Click);
            // 
            // CreateModelButton
            // 
            this.CreateModelButton.Location = new System.Drawing.Point(4, 66);
            this.CreateModelButton.Name = "CreateModelButton";
            this.CreateModelButton.Size = new System.Drawing.Size(91, 40);
            this.CreateModelButton.TabIndex = 12;
            this.CreateModelButton.Text = "Построить деталь";
            this.CreateModelButton.UseVisualStyleBackColor = true;
            this.CreateModelButton.Click += new System.EventHandler(this.CreateModelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Радиус выреза на корме";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Радиус выреза на носу";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Радиусы вырезов по краям";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Ширина носовой части";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Расстояние от центров вырезов до края";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Расстояние от начала детали до среза";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Расстояние между вырезами";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Ширина детали";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Высота детали";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 271);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Длина детали";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GasketModelGUI.Properties.Resources._3Da;
            this.pictureBox1.Location = new System.Drawing.Point(164, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(110, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Пример:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.DepthOfNotchInTheStern);
            this.panel1.Controls.Add(this.FromStartToCenterNose);
            this.panel1.Controls.Add(this.GasketLenght);
            this.panel1.Controls.Add(this.GasketHeight);
            this.panel1.Controls.Add(this.GasketWidth);
            this.panel1.Controls.Add(this.BetweenCentRad);
            this.panel1.Controls.Add(this.BeforeShear);
            this.panel1.Controls.Add(this.CenterToTheEdge);
            this.panel1.Controls.Add(this.AbaloneAround);
            this.panel1.Controls.Add(this.RadiusEdges);
            this.panel1.Controls.Add(this.RadiusProw);
            this.panel1.Controls.Add(this.RadiusStern);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 397);
            this.panel1.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 327);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(177, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Глубина выреза на корме детали";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 299);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(193, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "От начала до центра выреза на носу";
            // 
            // DepthOfNotchInTheStern
            // 
            this.DepthOfNotchInTheStern.Location = new System.Drawing.Point(223, 327);
            this.DepthOfNotchInTheStern.Name = "DepthOfNotchInTheStern";
            this.DepthOfNotchInTheStern.Parameter = null;
            this.DepthOfNotchInTheStern.Size = new System.Drawing.Size(93, 22);
            this.DepthOfNotchInTheStern.TabIndex = 34;
            // 
            // FromStartToCenterNose
            // 
            this.FromStartToCenterNose.Location = new System.Drawing.Point(223, 299);
            this.FromStartToCenterNose.Name = "FromStartToCenterNose";
            this.FromStartToCenterNose.Parameter = null;
            this.FromStartToCenterNose.Size = new System.Drawing.Size(93, 22);
            this.FromStartToCenterNose.TabIndex = 33;
            // 
            // GasketLenght
            // 
            this.GasketLenght.Location = new System.Drawing.Point(222, 271);
            this.GasketLenght.Name = "GasketLenght";
            this.GasketLenght.Parameter = null;
            this.GasketLenght.Size = new System.Drawing.Size(93, 22);
            this.GasketLenght.TabIndex = 32;
            // 
            // GasketHeight
            // 
            this.GasketHeight.Location = new System.Drawing.Point(223, 243);
            this.GasketHeight.Name = "GasketHeight";
            this.GasketHeight.Parameter = null;
            this.GasketHeight.Size = new System.Drawing.Size(93, 22);
            this.GasketHeight.TabIndex = 31;
            // 
            // GasketWidth
            // 
            this.GasketWidth.Location = new System.Drawing.Point(222, 215);
            this.GasketWidth.Name = "GasketWidth";
            this.GasketWidth.Parameter = null;
            this.GasketWidth.Size = new System.Drawing.Size(93, 22);
            this.GasketWidth.TabIndex = 30;
            // 
            // BetweenCentRad
            // 
            this.BetweenCentRad.Location = new System.Drawing.Point(222, 187);
            this.BetweenCentRad.Name = "BetweenCentRad";
            this.BetweenCentRad.Parameter = null;
            this.BetweenCentRad.Size = new System.Drawing.Size(93, 22);
            this.BetweenCentRad.TabIndex = 29;
            // 
            // BeforeShear
            // 
            this.BeforeShear.Location = new System.Drawing.Point(223, 159);
            this.BeforeShear.Name = "BeforeShear";
            this.BeforeShear.Parameter = null;
            this.BeforeShear.Size = new System.Drawing.Size(93, 22);
            this.BeforeShear.TabIndex = 28;
            // 
            // CenterToTheEdge
            // 
            this.CenterToTheEdge.Location = new System.Drawing.Point(223, 131);
            this.CenterToTheEdge.Name = "CenterToTheEdge";
            this.CenterToTheEdge.Parameter = null;
            this.CenterToTheEdge.Size = new System.Drawing.Size(93, 22);
            this.CenterToTheEdge.TabIndex = 27;
            // 
            // AbaloneAround
            // 
            this.AbaloneAround.Location = new System.Drawing.Point(223, 103);
            this.AbaloneAround.Name = "AbaloneAround";
            this.AbaloneAround.Parameter = null;
            this.AbaloneAround.Size = new System.Drawing.Size(93, 22);
            this.AbaloneAround.TabIndex = 26;
            // 
            // RadiusEdges
            // 
            this.RadiusEdges.Location = new System.Drawing.Point(223, 75);
            this.RadiusEdges.Name = "RadiusEdges";
            this.RadiusEdges.Parameter = null;
            this.RadiusEdges.Size = new System.Drawing.Size(93, 22);
            this.RadiusEdges.TabIndex = 25;
            // 
            // RadiusProw
            // 
            this.RadiusProw.Location = new System.Drawing.Point(223, 47);
            this.RadiusProw.Name = "RadiusProw";
            this.RadiusProw.Parameter = null;
            this.RadiusProw.Size = new System.Drawing.Size(93, 22);
            this.RadiusProw.TabIndex = 24;
            // 
            // RadiusStern
            // 
            this.RadiusStern.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RadiusStern.Location = new System.Drawing.Point(223, 19);
            this.RadiusStern.Name = "RadiusStern";
            this.RadiusStern.Parameter = null;
            this.RadiusStern.Size = new System.Drawing.Size(93, 22);
            this.RadiusStern.TabIndex = 23;
            this.RadiusStern.Load += new System.EventHandler(this.RadiusStern_Load);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.CreateModelButton);
            this.panel2.Controls.Add(this.RunInventorButton);
            this.panel2.Location = new System.Drawing.Point(15, 432);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(329, 116);
            this.panel2.TabIndex = 27;
            // 
            // UserInterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 587);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UserInterfaceForm";
            this.Text = "Инжекторная прокладка";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button RunInventorButton;
        private System.Windows.Forms.Button CreateModelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ParameterObjectControl RadiusStern;
        private ParameterObjectControl RadiusProw;
        private ParameterObjectControl RadiusEdges;
        private ParameterObjectControl AbaloneAround;
        private ParameterObjectControl CenterToTheEdge;
        private ParameterObjectControl BetweenCentRad;
        private ParameterObjectControl BeforeShear;
        private ParameterObjectControl GasketWidth;
        private ParameterObjectControl GasketHeight;
        private ParameterObjectControl GasketLenght;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private ParameterObjectControl DepthOfNotchInTheStern;
        private ParameterObjectControl FromStartToCenterNose;
    }
}

