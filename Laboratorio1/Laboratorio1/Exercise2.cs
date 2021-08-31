using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Laboratorio1
{
    public partial class Exercise2 : XtraForm
    {
        public Exercise2()
        {
            InitializeComponent();
        }
        /*    Declaramos el arreglo del tipo de  la clase Employee y     *
         *   la variable Position que es la que nos va a estar ayudando  *
         *               a controlar la posicion actual                  */
        private employee[] dataEmployee;
        int position = 0;
        ValidateTextBox validate = new ValidateTextBox();
        OrderMethod order = new OrderMethod();
        private void btnCreate_Click(object sender, EventArgs e)
        {
           try
            {
                //Se manda a validar los datos ingresados
                validateDataEmployee();
                //Se manda a comprobar que no exista ya un usuario con esa cedula
                isAlredaryRegistered();
                //Si los datos son correctos procedemos a guardar y aumentamos el arreglo de la clase
                Array.Resize(ref dataEmployee, position + 1);
                getDataEmployee(position);
                position++;
                salaryIncrease();
                //Mandamos a limpiar los textBox  
                clearTextBoxes();
                //Convertimos los datos en una lista para mandar a imprimir en el grid 
                gcEmployees.DataSource = dataEmployee.ToList();
            }
            catch(Exception ex)
            {
               XtraMessageBox.Show(ex.Message);
            }
            
        }
        private void BtnRead_Click(object sender, EventArgs e)
        {
            try
            {
                if (search()>-1)
                {
                    //La posicion que en lo encontramos es la que se muestra
                    gcEmployees.DataSource = null;
                    employee[] aux = new employee[1];
                    aux[0] = dataEmployee[search()];
                    gcEmployees.DataSource = aux.ToList();
                }
                else
                {
                    throw new Exception("Usuario no encontrado");
                }
                    
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (search() > -1)
                {
                    validateDataEmployee();
                    getDataEmployee(search());
                    MessageBox.Show("La persona con Id = " + dataEmployee[search()].id + " se actualizo");
                    clearTextBoxes();
                    gcEmployees.DataSource = dataEmployee.ToList();
                }
                else
                {
                    throw new Exception("Usuario no encontrado");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
               int k = search();
               for (int i = k; i < position-1; i++)
                    dataEmployee[i] = dataEmployee[i + 1];
               position--;
               dataEmployee[position] = new student();
               salaryIncrease();
               gcEmployees.DataSource = null;
               gcEmployees.DataSource = dataEmployee.ToList();
               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        public int search()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
                throw new Exception("La cedula es requerida");
            else if (position>0)
            {
                for (int i = 0; i < dataEmployee.Length; i++)
                {
                    if (txtId.Text == dataEmployee[i].id)
                    {
                        return i;
                    }
                }
            }
            throw new Exception("usuario no encontrado");
            
        }
        public void isAlredaryRegistered()
        {
            //Que no este repetido el ID siempre y cuando no sea el primer registro
            if (position > 0)
            {
                for (int i = 0; i < dataEmployee.Length; i++)
                {
                    if (txtId.Text == dataEmployee[i].id)
                        throw new Exception("Ya existe un usuario con esa cedula");
                }
            }
        }
        public void validateDataEmployee()
        {
            //Que Los campos no esten vacios
            if (string.IsNullOrWhiteSpace(txtId.Text)|| string.IsNullOrWhiteSpace(txtNames.Text)||string.IsNullOrWhiteSpace(txtLastNames.Text)||string.IsNullOrWhiteSpace(txtSons.Text)|| string.IsNullOrWhiteSpace(txtSalary.Text))
                throw new Exception("Todos los campos son requeridos");
            
            //Que los datos sean del tipo correcto
            if (!double.TryParse(txtSalary.Text, out double exi))
                throw new Exception($"El valor: \"{txtSalary.Text}\" en Salario es invalido!");
            if (!int.TryParse(txtSons.Text, out int exi2))
                throw new Exception($"El valor: \"{txtSons.Text}\" en Hijos es invalido!");
        }
        public void getDataEmployee(int position)
        {
            dataEmployee[position] = new employee()
            {
                id = txtId.Text,
                names = txtNames.Text,
                lastNames = txtLastNames.Text,
                finalNotes = double.Parse(txtSalary.Text),
                sons = int.Parse(txtSons.Text),
                bonus = 0,
            };
           
        }
        public void salaryIncrease()
        {
            double average = 0;
            //Sacamos el promedio del salario de los empledos que estan registrados actualmente
            for (int i = 0; i < position; i++)
                average += dataEmployee[i].finalNotes / position;
            //Peguntamos si el salario es menos que el promedio o mayor para si aumentarle
            for (int i = 0; i < position; i++)
            {
                if (dataEmployee[i].finalNotes < average)
                    dataEmployee[i].bonus = dataEmployee[i].finalNotes * .1;
                else
                    dataEmployee[i].bonus = 0;

            }
        }
        public void clearTextBoxes()
        {
            txtId.Clear();
            txtNames.Clear();
            txtLastNames.Clear();
            txtSalary.Clear();
            txtSons.Clear();
            txtId.Focus();
        }
        // Delimitando las entradas
        private void TxtNames_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.justLetters(e);
        }
        private void TxtLastNames_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.justLetters(e);
        }
        private void TxtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.allowDecimals(e);
        }
        private void TxtSons_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.justNumbers(e);
        }
        //Colocamos las opciones de ordenamiento del combo box 
        private void Exercise2_Load(object sender, EventArgs e)
        {
            cbOrder.DropDownStyle = ComboBoxStyle.DropDownList;
            cbOrder.Items.Add("Burbuja Menor");
            cbOrder.Items.Add("Burbuja Mayor");
            cbOrder.Items.Add("Burbuja Bandera");
            cbOrder.Items.Add("Sacudida");
            cbOrder.Items.Add("Inserccion Directa");
            cbOrder.Items.Add("Inserccion Decreciente");

        }

        private void CbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbOrder.SelectedIndex == 0)
                {
                    order.minorBubleSort(dataEmployee);
                    gcEmployees.DataSource = dataEmployee.ToList();
                }
                else if (cbOrder.SelectedIndex == 1)
                {
                    order.majorBubleSort(dataEmployee);
                    gcEmployees.DataSource = dataEmployee.ToList();
                }
                else if (cbOrder.SelectedIndex == 2)
                {
                    order.signalBubleSort(dataEmployee);
                    gcEmployees.DataSource = dataEmployee.ToList();
                }
                else if (cbOrder.SelectedIndex == 3)
                {
                    order.shakeSort(dataEmployee);
                    gcEmployees.DataSource = dataEmployee.ToList();
                }
                else if (cbOrder.SelectedIndex == 4)
                {
                    order.directInsertSort(dataEmployee);
                    gcEmployees.DataSource = dataEmployee.ToList();
                }
                else if (cbOrder.SelectedIndex == 5)
                {
                    order.decreaseInsertSort(dataEmployee);
                    gcEmployees.DataSource = dataEmployee.ToList();
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("No hay registros para ordernar");
            }
            
        }
    }
}