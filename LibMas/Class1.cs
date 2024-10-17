using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace LibMas
{
    public class MasFunction
    {
        /// <summary>
        /// Заполнение массива
        /// </summary>
        /// <param name="mas">Массив</param>
        /// <param name="column">Колличество столбцов, значений</param>
        public static void InitMas(out int[,] mas, int row, int column)
        {
            Random Rnd = new Random();
            mas = new Int32[row,column];


            for (int i = 0; i < mas.GetLength(0); i++)
                for (int j = 0; j < mas.GetLength(1); j++) mas[i, j] = Rnd.Next(1,5);
        }

        /// <summary>
        /// Очистка массива
        /// </summary>
        /// <param name="mas">Массив</param>
        public static void ClearMas(ref int[,] mas)
        {
            mas = null;
        }

        /// <summary>
        /// Сохранение массива
        /// </summary>
        /// <param name="mas">маасив</param>
        public static void SaveMas(int[,] mas)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) |*.*| Текстовые файлы | *.txt*";
            save.FilterIndex = 1;
            save.Title = "Сохранение таблицы";
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
            else MessageBox.Show("Не удалось открыть окно");
        }

        /// <summary>
        /// Открытие текстовго документа с массивом
        /// </summary>
        /// <param name="mas">Матрица</param>
        public static void OpenMas(ref int[,] mas)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) |*.*| Текстовые файлы | *.txt*";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
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

                        else MessageBox.Show("Некоректные значения");
                    }
                }
                file.Close();
            }
        }
    }

}