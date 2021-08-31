using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio1
{
    class OrderMethodStudent
    {
        int size = 0;
        student[] aux = new student[1];
        //A cada uno de los algoritmos le pasaremos el arreglo a ordenar
        public void minorBubleSort(student[] theStudent)
        {
            size = theStudent.Length;
            for (int i = 1; i < size; i++)
            {
                for (int j = size - 1; j > 0; j--)
                {
                    if (theStudent[j - 1].finalNotes > theStudent[j].finalNotes)
                    {
                        aux[0] = theStudent[j - 1];
                        theStudent[j - 1] = theStudent[j];
                        theStudent[j] = aux[0];
                    }
                }
            }
        }
        public void majorBubleSort(student[] theStudent)
        {
            size = theStudent.Length;
            for (int i = size - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (theStudent[j].finalNotes > theStudent[j + 1].finalNotes)
                    {
                        aux[0] = theStudent[j];
                        theStudent[j] = theStudent[j + 1];
                        theStudent[j + 1] = aux[0];
                    }
                }
            }
        }
        public void signalBubleSort(student[] theStudent)
        {
            size = theStudent.Length;
            int i = 0;
            bool flat = false;
            while (i < size - 1 && flat == false)
            {
                flat = true;
                for (int j = 0; j < size - 1; j++)
                {
                    if (theStudent[j].finalNotes > theStudent[j + 1].finalNotes)
                    {
                        aux[0] = theStudent[j];
                        theStudent[j] = theStudent[j + 1];
                        theStudent[j + 1] = aux[0];
                        flat = false;
                    }
                }
                i = i + 1;
            }
        }
        public void shakeSort(student[] theStudent)
        {
            size = theStudent.Length;
            int left = 1;
            int right = size - 1;
            int k = size - 1;
            while (right >= left)
            {
                for (int i = right; i >= left; i--)
                {
                    if (theStudent[i - 1].finalNotes > theStudent[i].finalNotes)
                    {
                        aux[0] = theStudent[i - 1];
                        theStudent[i - 1] = theStudent[i];
                        theStudent[i] = aux[0];
                        k = i;
                    }

                }
                left = k + 1;
                for (int i = left; i <= right; i++)
                {
                    if (theStudent[i - 1].finalNotes > theStudent[i].finalNotes)
                    {
                        aux[0] = theStudent[i - 1];
                        theStudent[i - 1] = theStudent[i];
                        theStudent[i] = aux[0];
                        k = i;
                    }
                }
                right = k - 1;
            }
        }
        public void directInsertSort(student[] theStudent)
        {
            size = theStudent.Length;
            for (int i = 1; i < size; i++)
            {
                aux[0] = theStudent[i];
                int k = i - 1;
                while ((k >= 0) && (aux[0].finalNotes < theStudent[k].finalNotes))
                {
                    theStudent[k + 1] = theStudent[k];
                    k = k - 1;
                }
                theStudent[k + 1] = aux[0];
            }
        }
        public void decreaseInsertSort(student[] theStudent)
        {
            int i = 0;
            size = theStudent.Length;
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
                        if (theStudent[i].finalNotes > theStudent[i + insta].finalNotes)
                        {
                            aux[0] = theStudent[i];
                            theStudent[i] = theStudent[i + insta];
                            theStudent[i + insta] = aux[0];
                            flat = true;
                        }
                        i = i + 1;
                    }
                }
            }

        }
    }
}
