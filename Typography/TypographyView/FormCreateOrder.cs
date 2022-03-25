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


namespace TypographyView
{
    public partial class FormCreateOrder : Form
    {
        private readonly IPrintedLogic logicPrinted;

        private readonly IOrderLogic logicOrder;

        public FormCreateOrder(IPrintedLogic logicP, IOrderLogic logicO)
        {
            InitializeComponent();
            logicPrinted = logicP;
            logicOrder = logicO;
        }
        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<PrintedViewModel> list = logicPrinted.Read(null);
                if (list != null)
                {
                    comboBoxPrinted.DisplayMember = "PrintedName";
                    comboBoxPrinted.ValueMember = "Id";
                    comboBoxPrinted.DataSource = list;
                    comboBoxPrinted.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalcSum()
        {
            if (comboBoxPrinted.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxPrinted.SelectedValue);
                    PrintedViewModel printed = logicPrinted.Read(new PrintedBindingModel { Id = id })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * printed?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ComboBoxPrinted_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxPrinted.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicOrder.CreateOrder(new CreateOrderBindingModel
                {
                    PrintedId = Convert.ToInt32(comboBoxPrinted.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
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
