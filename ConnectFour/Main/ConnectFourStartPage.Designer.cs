namespace ConnectFour
{
  partial class ConnectFourStartPage
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
        _gameBoard.Dispose();
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
      this.AIVsAI = new System.Windows.Forms.Button();
      this.PlayerVsAI = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // AIVsAI
      // 
      this.AIVsAI.BackColor = System.Drawing.Color.Transparent;
      this.AIVsAI.Font = new System.Drawing.Font("Nunito Sans Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.AIVsAI.Location = new System.Drawing.Point(322, 5);
      this.AIVsAI.Name = "AIVsAI";
      this.AIVsAI.Size = new System.Drawing.Size(300, 300);
      this.AIVsAI.TabIndex = 0;
      this.AIVsAI.Text = "AI vs. AI";
      this.AIVsAI.UseVisualStyleBackColor = false;
      this.AIVsAI.Click += new System.EventHandler(this.AIVsAI_Click);
      // 
      // PlayerVsAI
      // 
      this.PlayerVsAI.BackColor = System.Drawing.Color.Transparent;
      this.PlayerVsAI.Font = new System.Drawing.Font("Nunito Sans Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.PlayerVsAI.Location = new System.Drawing.Point(12, 5);
      this.PlayerVsAI.Name = "PlayerVsAI";
      this.PlayerVsAI.Size = new System.Drawing.Size(300, 300);
      this.PlayerVsAI.TabIndex = 1;
      this.PlayerVsAI.Text = "Player vs. AI";
      this.PlayerVsAI.UseVisualStyleBackColor = false;
      this.PlayerVsAI.Click += new System.EventHandler(this.PlayerVsAI_Click);
      // 
      // ConnectFourStartPage
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(634, 311);
      this.Controls.Add(this.PlayerVsAI);
      this.Controls.Add(this.AIVsAI);
      this.Name = "ConnectFourStartPage";
      this.Text = "Let\'s Play Connect Four!";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button AIVsAI;
    private System.Windows.Forms.Button PlayerVsAI;
  }
}

