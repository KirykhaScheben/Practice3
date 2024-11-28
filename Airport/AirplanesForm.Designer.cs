namespace Airport
{
    partial class AirplanesForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoadFlights = new System.Windows.Forms.Button();
            this.btnLoadRoutes = new System.Windows.Forms.Button();
            this.btnLoadAirplanes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(79, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(642, 303);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnLoadFlights
            // 
            this.btnLoadFlights.Location = new System.Drawing.Point(666, 453);
            this.btnLoadFlights.Name = "btnLoadFlights";
            this.btnLoadFlights.Size = new System.Drawing.Size(106, 35);
            this.btnLoadFlights.TabIndex = 6;
            this.btnLoadFlights.Text = "Информация о рейсах";
            this.btnLoadFlights.UseVisualStyleBackColor = true;
            this.btnLoadFlights.Click += new System.EventHandler(this.btnLoadFlights_Click);
            // 
            // btnLoadRoutes
            // 
            this.btnLoadRoutes.Location = new System.Drawing.Point(666, 508);
            this.btnLoadRoutes.Name = "btnLoadRoutes";
            this.btnLoadRoutes.Size = new System.Drawing.Size(106, 35);
            this.btnLoadRoutes.TabIndex = 5;
            this.btnLoadRoutes.Text = "Информация о маршрутах";
            this.btnLoadRoutes.UseVisualStyleBackColor = true;
            this.btnLoadRoutes.Click += new System.EventHandler(this.btnLoadRoutes_Click);
            // 
            // btnLoadAirplanes
            // 
            this.btnLoadAirplanes.Location = new System.Drawing.Point(666, 395);
            this.btnLoadAirplanes.Name = "btnLoadAirplanes";
            this.btnLoadAirplanes.Size = new System.Drawing.Size(106, 35);
            this.btnLoadAirplanes.TabIndex = 7;
            this.btnLoadAirplanes.Text = "Информация о самолётах";
            this.btnLoadAirplanes.UseVisualStyleBackColor = true;
            this.btnLoadAirplanes.Click += new System.EventHandler(this.btnLoadAirplanes_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "Время полёта";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(138, 395);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 35);
            this.button2.TabIndex = 9;
            this.button2.Text = "Часто летающий самолёт";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(138, 453);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 35);
            this.button3.TabIndex = 10;
            this.button3.Text = "Недозагруженные маршруты";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 453);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 35);
            this.button4.TabIndex = 11;
            this.button4.Text = "Свободные места на рейс 870";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // AirplanesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLoadAirplanes);
            this.Controls.Add(this.btnLoadFlights);
            this.Controls.Add(this.btnLoadRoutes);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AirplanesForm";
            this.Text = "AirplanesForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoadFlights;
        private System.Windows.Forms.Button btnLoadRoutes;
        private System.Windows.Forms.Button btnLoadAirplanes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}