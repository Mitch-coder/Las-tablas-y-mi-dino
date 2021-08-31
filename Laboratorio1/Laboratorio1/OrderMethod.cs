using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio1
{
    class OrderMethod
    {
        int size = 0;
        employee[] aux = new employee[1];
        //A cada uno de los algoritmos le pasaremos el arreglo a ordenar
        public void minorBubleSort(student[] employee)
        {
            size = employee.Length;
            for (int i = 1; i < size; i++)
            {
                for (int j = size - 1; j > 0; j--)
                {
                    if (employee[j - 1].finalNot > employee[j].finalNotes)
                    {
                        aux[0] = employee[j - 1];
                        employee[j - 1] = employee[j];
                        employee[j] = aux[0];
                    }
                }
            }
        }
        public void majorBubleSort(student[] employee)
        {
            size = employee.Length;
            for (int i = size - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (employee[j].finalNotes > employee[j + 1].finalNotes)
                    {
                        aux[0] = employee[j];
                        employee[j] = employee[j + 1];
                        employee[j + 1] = aux[0];
                    }
                }
            }
        }
        public void signalBubleSort(student[] employee)
        {
            size = employee.Length;
            int i = 0;
            bool flat = false;
            while (i < size - 1 && flat == false)
            {
                flat = true;
                for (int j = 0; j < size - 1; j++)
                {
                    if (employee[j].finalNotes > employee[j + 1].finalNotes)
                    {
                        aux[0] = employee[j];
                        employee[j] = employee[j + 1];
                        employee[j + 1] = aux[0];
                        flat = false;
                    }
                }
                i = i + 1;
            }
        }
        public void shakeSort(student[] employee)
        {
            size = employee.Length;
            int left = 1;
            int right = size - 1;
            int k = size - 1;
            while (right >= left)
            {
                for (int i = right; i >= left; i--)
                {
                    if (employee[i - 1].finalNotes > employee[i].finalNotes)
                    {
                        aux[0] = employee[i - 1];
                        employee[i - 1] = employee[i];
                        employee[i] = aux[0];
                        k = i;
                    }

                }
                left = k + 1;
                for (int i = left; i <= right; i++)
                {
                    if (employee[i - 1].finalNotes > employee[i].finalNotes)
                    {
                        aux[0] = employee[i - 1];
                        employee[i - 1] = employee[i];
                        employee[i] = aux[0];
                        k = i;
                    }
                }
                right = k - 1;
            }
        }
        public void directInsertSort(student[] employee)
        {
            size = employee.Length;
            for (int i = 1; i < size; i++)
            {
                aux[0] = employee[i];
                int k = i - 1; 
                while ((k >= 0) && (aux[0].finalNotes< employee[k].finalNotes))
                {
                    employee[k + 1] = employee[k];
                    k = k - 1;
                }
                employee[k + 1] = aux[0];
            }
        }
        public void decreaseInsertSort(student[] employee)
        {
            int i = 0;
            size = employee.Length;
            bool flat;
            int insta = size;
            while (insta > 0)
            {
                insta = insta / 2;
                flat = true;
                while (flat)
                {
                    flat = false;
                     i = 0;
                    while ((i + insta) <= size - 1)
                    {
                        if (employee[i].finalNotes > employee[i + insta].finalNotes)
                        {
                            aux[0] = employee[i];
                            employee[i] = employee[i + insta];
                            employee[i + insta] = aux[0];
                            flat = true;
                        }
                        i = i + 1;
                    }
                }
            }

        }
    }
}
