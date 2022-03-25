﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TypographyContracts.BindingModels;
using TypographyContracts.BusinessLogicsContracts;
using Unity;

namespace TypographyView
{
    public partial class FormPrinteds : Form
    {
        private readonly IPrintedLogic logic;

        public FormPrinteds(IPrintedLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);
                if (list != null)
                {
                    dataGridViewPrinteds.DataSource = list;
                    dataGridViewPrinteds.Columns[0].Visible = false;
                    dataGridViewPrinteds.Columns[3].Visible = false;
                    dataGridViewPrinteds.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormPrinteds_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormPrinted>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrinteds.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormPrinted>();
                form.Id = Convert.ToInt32(dataGridViewPrinteds.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrinteds.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewPrinteds.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new PrintedBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
