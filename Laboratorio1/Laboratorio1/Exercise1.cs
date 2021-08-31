using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Laboratorio1
{
    public partial class Exercise1 : XtraForm
    {
        public Exercise1()
        {
            InitializeComponent();
        }
        private student[] dataStudent;
        int position = 0;
        ValidateTextBox validate = new ValidateTextBox();
        OrderMethodStudent order = new OrderMethodStudent();
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                //Se manda a validar los datos ingresados
                validateDataStudent();
                //Se manda a comprobar que no exista ya un usuario con esa cedula
                isAlredaryRegistered();
                //Si los datos son correctos procedemos a guardar y aumentamos el arreglo de la clase
                Array.Resize(ref dataStudent, position + 1);
                getDataStudent(position);
                position++;
                //Mandamos a limpiar los textBox  
                clearTextBoxes();
                // Calculamos el mejor estudiante 
                theBestStudent();
                // El promedio General de la clase
                studentGeneralAverage();
                //Convertimos los datos en una lista para mandar a imprimir en el grid 
                gcStudents.DataSource = dataStudent.ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
           
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            try
            {
                if (search() > -1)
                {
                    //La posicion que en lo encontramos es la que se muestra
                    gcStudents.DataSource = null;
                    student[] aux = new student[1];
                    aux[0] = dataStudent[search()];
                    gcStudents.DataSource = aux.ToList();
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
                    validateDataStudent();
                    getDataStudent(search());
                    MessageBox.Show("La persona con Id = " + dataStudent[search()].idStudent + " se actualizo");
                    clearTextBoxes();
                    // Calculamos el mejor estudiante 
                    theBestStudent();
                    // El promedio General de la clase
                    studentGeneralAverage();
                    gcStudents.DataSource = dataStudent.ToList();
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
                for (int i = k; i < position - 1; i++)
                    dataStudent[i] = dataStudent[i + 1];
                position--;
                dataStudent[position] = new student();
                gcStudents.DataSource = null;
                // Calculamos el mejor estudiante 
                theBestStudent();
                // El promedio General de la clase
                studentGeneralAverage();
                gcStudents.DataSource = dataStudent.ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        public int search()
        {
            if (string.IsNullOrWhiteSpace(txtIdStudent.Text))
                throw new Exception("El Carnet es requerido");
            else if (position > 0)
            {
                for (int i = 0; i < dataStudent.Length; i++)
                {
                    if (txtIdStudent.Text == dataStudent[i].idStudent)
                    {
                        return i;
                    }
                }
            }
            throw new Exception("Estudiante no encontrado");

        }
        public void isAlredaryRegistered()
        {
            //Que no este repetido el ID siempre y cuando no sea el primer registro
            if (position > 0)
            {
                for (int i = 0; i < dataStudent.Length; i++)
                {
                    if (txtIdStudent.Text == dataStudent[i].idStudent)
                        throw new Exception("Ya existe un estudiante con ese carnet");
                }
            }
        }
        public void validateDataStudent()
        {
            //Que Los campos no esten vacios
            if (string.IsNullOrWhiteSpace(txtIdStudent.Text) || string.IsNullOrWhiteSpace(txtNames.Text) || string.IsNullOrWhiteSpace(txtLastNames.Text) || string.IsNullOrWhiteSpace(txtIP.Text) || string.IsNullOrWhiteSpace(txtIIP.Text ) || string.IsNullOrWhiteSpace(txtEvaluation.Text))
                throw new Exception("Todos los campos son requeridos");

            //Que los datos sean del tipo correcto
            if (!double.TryParse(txtIP.Text, out double exi) || !int.TryParse(txtIIP.Text, out int exi2) || !int.TryParse(txtEvaluation.Text, out int exi3))
                throw new Exception($"El valor introducido en las notas es invalido!");
        }
        // Mandamos a giardar en la clase
        public void getDataStudent(int position)
        {
            dataStudent[position] = new student()
            {
                idStudent = txtIdStudent.Text,
                names = txtNames.Text,
                lastNames = txtLastNames.Text,
                ip = int.Parse(txtIP.Text),
                iip = int.Parse(txtIIP.Text),
                evaluation = int.Parse(txtEvaluation.Text),
                finalNote = int.Parse(txtIP.Text)+ int.Parse(txtIIP.Text)+ int.Parse(txtEvaluation.Text),
            };
        }
        public void studentGeneralAverage()
        {
            double average = 0;
           // Obtenemos el promedio general de la clase
            for (int i = 0; i < position; i++)
                average += dataStudent[i].finalNote / position;
            txtAverage.Text = " "+average;
        }
        public void theBestStudent()
        {
            string name="";
            int mayor =0;
            for (int i = 0; i < dataStudent.Length; i++)
            {
                if (dataStudent[i].finalNote > mayor)
                {
                    mayor = dataStudent[i].finalNote;
                    name = dataStudent[i].names;
                }
            }
            txtTbStudent.Text = name + " con "+mayor;
        }
        public void clearTextBoxes()
        {
            txtIdStudent.Text = null;
            txtNames.Text = null;
            txtLastNames = null;
            txtIP.Text = null;
            txtIIP.Text = null;
            txtEvaluation.Text = null;
        }

        private void TxtNames_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.justLetters(e);
        }

        private void TxtLastNames_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.justLetters(e);
        }

        private void TxtIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.justNumbers(e);
        }

        private void TxtIIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.justNumbers(e);
        }

        private void TxtEvaluation_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.justNumbers(e);
        }

        private void CbOrderNotes_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (cbOrderNotes.SelectedIndex == 0)
                {
                    order.minorBubleSort(dataStudent);
                    gcStudents.DataSource = dataStudent.ToList();
                }
                else if (cbOrderNotes.SelectedIndex == 1)
                {
                    order.majorBubleSort(dataStudent);
                    gcStudents.DataSource = dataStudent.ToList();
                }
                else if (cbOrderNotes.SelectedIndex == 2)
                {
                    order.signalBubleSort(dataStudent);
                    gcStudents.DataSource = dataStudent.ToList();
                }
                else if (cbOrderNotes.SelectedIndex == 3)
                {
                    order.shakeSort(dataStudent);
                    gcStudents.DataSource = dataStudent.ToList();
                }
                else if (cbOrderNotes.SelectedIndex == 4)
                {
                    order.directInsertSort(dataStudent);
                    gcStudents.DataSource = dataStudent.ToList();
                }
                else if (cbOrderNotes.SelectedIndex == 5)
                {
                    order.decreaseInsertSort(dataStudent);
                    gcStudents.DataSource = dataStudent.ToList();
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("No hay registros para ordernar");
            }

        }

        private void Exercise1_Load(object sender, EventArgs e)
        {
           /* cbOrderNotes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbOrderNotes.Items.Add("Burbuja Menor");
            cbOrderNotes.Items.Add("Burbuja Mayor");
            cbOrderNotes.Items.Add("Burbuja Bandera");
            cbOrderNotes.Items.Add("Sacudida");
            cbOrderNotes.Items.Add("Inserccion Directa");
            cbOrderNotes.Items.Add("Inserccion Decreciente");*/
        }
    }
       
}
