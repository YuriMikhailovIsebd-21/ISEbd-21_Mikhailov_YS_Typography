
namespace TypographyView
{
    partial class FormPrinted
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.groupBoxComponents = new System.Windows.Forms.GroupBox();
            this.dataGridViewPrinteds = new System.Windows.Forms.DataGridView();
            this.ComponentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComponentCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinteds)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(45, 30);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(65, 15);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название: ";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(45, 66);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(41, 15);
            this.labelPrice.TabIndex = 1;
            this.labelPrice.Text = "Цена: ";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(129, 30);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(195, 23);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(129, 63);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(100, 23);
            this.textBoxPrice.TabIndex = 3;
            // 
            // groupBoxComponents
            // 
            this.groupBoxComponents.Controls.Add(this.dataGridViewPrinteds);
            this.groupBoxComponents.Controls.Add(this.buttonUpdate);
            this.groupBoxComponents.Controls.Add(this.buttonDelete);
            this.groupBoxComponents.Controls.Add(this.buttonChange);
            this.groupBoxComponents.Controls.Add(this.buttonAdd);
            this.groupBoxComponents.Location = new System.Drawing.Point(45, 92);
            this.groupBoxComponents.Name = "groupBoxComponents";
            this.groupBoxComponents.Size = new System.Drawing.Size(720, 329);
            this.groupBoxComponents.TabIndex = 4;
            this.groupBoxComponents.TabStop = false;
            this.groupBoxComponents.Text = "Компоненты";
            // 
            // dataGridViewPrinteds
            // 
            this.dataGridViewPrinteds.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewPrinteds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrinteds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ComponentId,
            this.NameComponent,
            this.ComponentCount});
            this.dataGridViewPrinteds.Location = new System.Drawing.Point(0, 22);
            this.dataGridViewPrinteds.Name = "dataGridViewPrinteds";
            this.dataGridViewPrinteds.RowTemplate.Height = 25;
            this.dataGridViewPrinteds.Size = new System.Drawing.Size(544, 301);
            this.dataGridViewPrinteds.TabIndex = 4;
            // 
            // ComponentId
            // 
            this.ComponentId.HeaderText = "";
            this.ComponentId.Name = "ComponentId";
            this.ComponentId.Visible = false;
            // 
            // NameComponent
            // 
            this.NameComponent.HeaderText = "Компонент";
            this.NameComponent.Name = "NameComponent";
            this.NameComponent.Width = 400;
            // 
            // ComponentCount
            // 
            this.ComponentCount.HeaderText = "Количество";
            this.ComponentCount.Name = "ComponentCount";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(576, 204);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(84, 30);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(576, 154);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(84, 30);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(576, 59);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(84, 29);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(576, 106);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(84, 30);
            this.buttonChange.TabIndex = 1;
            this.buttonChange.Text = "Изменить";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(564, 427);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(83, 34);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(664, 427);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 34);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormPrinted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 473);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxComponents);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelName);
            this.Name = "FormPrinted";
            this.Text = "Изделие";
            this.Load += new System.EventHandler(this.FormPrinted_Load);
            this.groupBoxComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinteds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.GroupBox groupBoxComponents;
        private System.Windows.Forms.DataGridView dataGridViewPrinteds;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComponentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComponentCount;
    }
}