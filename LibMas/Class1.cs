using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace LibMas
{
    public class MasFunction
    {
        /// <summary>
        /// ���������� �������
        /// </summary>
        /// <param name="mas">������</param>
        /// <param name="column">����������� ��������, ��������</param>
        public static void InitMas(out int[,] mas, int row, int column)
        {
            Random Rnd = new Random();
            mas = new Int32[row,column];


            for (int i = 0; i < mas.GetLength(0); i++)
                for (int j = 0; j < mas.GetLength(1); j++) mas[i, j] = Rnd.Next(1,5);
        }

        /// <summary>
        /// ������� �������
        /// </summary>
        /// <param name="mas">������</param>
        public static void ClearMas(ref int[,] mas)
        {
            mas = null;
        }

        /// <summary>
        /// ���������� �������
        /// </summary>
        /// <param name="mas">������</param>
        public static void SaveMas(int[,] mas)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "��� ����� (*.*) |*.*| ��������� ����� | *.txt*";
            save.FilterIndex = 1;
            save.Title = "���������� �������";
            if (save.ShowDialog() == true)
            {
                StreamWriter outfile = new StreamWriter(save.FileName, false);
                outfile.WriteLine(mas.GetLength(0));
                outfile.WriteLine(mas.GetLength(1));
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        outfile.WriteLine(mas[i, j]);
                    }
                }
                outfile.Close();
            }
            else MessageBox.Show("�� ������� ������� ����");
        }

        /// <summary>
        /// �������� ��������� ��������� � ��������
        /// </summary>
        /// <param name="mas">�������</param>
        public static void OpenMas(ref int[,] mas)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "��� ����� (*.*) |*.*| ��������� ����� | *.txt*";
            open.FilterIndex = 2;
            open.Title = "�������� �������";
            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);
                int row = Convert.ToInt32(file.ReadLine());
                int col = Convert.ToInt32(file.ReadLine());
                mas = new int[row, col];
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        string a = file.ReadLine();
                        bool f1;
                        int value;
                        f1 = int.TryParse(a, out value);
                        if (f1)
                        {
                            mas[i, j] = value;

                        }

                        else MessageBox.Show("����������� ��������");
                    }
                }
                file.Close();
            }
        }
    }

}