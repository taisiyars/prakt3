namespace Lib_3
{
    public class Podschet
    {
        /// <summary>
        /// Подсчет суммы элементов в каждой строке матрицы
        /// </summary>
        /// <param name="mas">массив</param>
        /// <returns>сумма эл-тов каждой строки</returns>
        public static string CalcSum(int [,] mas)
        {
            string sum = "";
            int sum1 = 0;
            for (int i = 0;i < mas.GetLength(0);i++)
            {
                for (int j = 0;j < mas.GetLength(1);j++)
                {
                    sum1 += mas[i, j];
                }
                sum += Convert.ToString(sum1);
                sum += ", ";
                sum1 = 0;
            }
            return sum;
        }
    }

}
