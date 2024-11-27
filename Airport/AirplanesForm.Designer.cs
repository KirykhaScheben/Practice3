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
            // AirplanesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
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
    }
}