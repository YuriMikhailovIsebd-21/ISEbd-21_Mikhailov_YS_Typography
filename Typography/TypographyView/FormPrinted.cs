using System;
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
using TypographyContracts.ViewModels;

using Unity;

namespace TypographyView
{
    public partial class FormPrinted : Form
    {
        public int Id { set { id = value; } }

        private readonly IPrintedLogic _logic;

        private int? id;

        private Dictionary<int, (string, int)> printedComponents;

        public FormPrinted(IPrintedLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }
        private void FormPrinted_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    PrintedViewModel view = _logic.Read(new PrintedBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.PrintedName;
                        textBoxPrice.Text = view.Price.ToString();
                        printedComponents = view.PrintedComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                printedComponents = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (printedComponents != null)
                {
                    dataGridViewPrinteds.Rows.Clear();
                    foreach (var pc in printedComponents)
                    {
                        dataGridViewPrinteds.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormPrintedComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (printedComponents.ContainsKey(form.Id))
                {
                    printedComponents[form.Id] = (form.ComponentName, form.Count);
                }
                else
                {
                    printedComponents.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }
        private void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrinteds.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormPrintedComponent>();
                int id = Convert.ToInt32(dataGridViewPrinteds.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = printedComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    printedComponents[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrinteds.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        printedComponents.Remove(Convert.ToInt32(dataGridViewPrinteds.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (printedComponents == null || printedComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new PrintedBindingModel
                {
                    Id = id,
                    PrintedName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    PrintedComponents = printedComponents
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
