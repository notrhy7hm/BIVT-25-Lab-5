using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here
            double summa = 0;
            int count = 0;
            answer = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        summa += matrix[i, j];
                        count++;
                    }
                }
                if (count != 0)
                {
                    double sr = summa / count;
                    answer[i] = sr;
                    summa = 0;
                    count = 0;
                }
                else if (count == 0)
                {
                    answer[i] = 0;
                    summa = 0;
                }
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            double max_elem = -1e9;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max_elem)
                    {
                        max_elem = matrix[i, j];
                    }
                }
            }
            int row = 0, col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == max_elem)
                    {
                        row = i;
                        col = j;
                        break;
                    }
                }
            }
            answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int ii = 0, jj = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == row) continue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == col) continue;
                    answer[ii, jj] = matrix[i, j];
                    jj++;
                }
                jj = 0;
                ii++;
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int[] maximal = new int[matrix.GetLength(0)];

            int currentMax = -1000000000;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > currentMax) {
                        maximal[i] = j;
                        currentMax = matrix[i, j];
                    }
                }
                currentMax = -1000000000;
            }
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (maximal[i] < 0 || maximal[i] >= matrix.GetLength(1))
                    continue;
                if (maximal[i] == matrix.GetLength(1) - 1)
                    continue;

                int[] temp = new int[matrix.GetLength(1) - maximal[i] - 1];
                int c = 0;
                for (int j = maximal[i] + 1; j < matrix.GetLength(1); j++)
                {
                    temp[c] = matrix[i, j];
                    c++;
                }
                c = 0;
                matrix[i, matrix.GetLength(1) - 1] = matrix[i, maximal[i]];
                for (int j = maximal[i]; j < matrix.GetLength(1) - 1; j++)
                {
                    matrix[i, j] = temp[c];
                    c++;
                }
            }


            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int[] maximal = new int[matrix.GetLength(0)];
            for (int i = 0; i < maximal.Length; i++) maximal[i] = -1000000000;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maximal[i])
                        maximal[i] = matrix[i, j];
                }
            }

            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
            }
            for (int i = 0; i < maximal.Length; i++)
            {
                answer[i, answer.GetLength(1) - 2] = maximal[i];
                answer[i, answer.GetLength(1) - 1] = matrix[i, matrix.GetLength(1) - 1];
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int c = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 1)
                        c++;
                }
            }

            answer = new int[c];
            c = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        answer[c] = matrix[i, j];
                        c++;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            if(k >= matrix.GetLength(1) || matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }

            int maxx = matrix[0, 0];
            int maxx_index = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > maxx)
                {
                    maxx = matrix[i, i];
                    maxx_index = i;
                }
            }

            int negative = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] < 0)
                {
                    negative = i;
                    break;
                }
            }

            if(negative != -1 && negative != maxx_index)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    (matrix[negative, j], matrix[maxx_index, j]) = (matrix[maxx_index, j], matrix[negative, j]);
                }
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            if (matrix.GetLength(1) < 2 || matrix.GetLength(1) != array.Length)
            {
                return;
            }

            int k = matrix.GetLength(1) - 2;
            int maxx = matrix[0, k];
            int row = 0;

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] > maxx)
                {
                    row = i;
                    maxx = matrix[i, k];
                }
            }

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[row, j] = array[j];
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int maxx = matrix[0, j];
                int maxx_ind = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > maxx)
                    {
                        maxx = matrix[i, j];
                        maxx_ind = i;
                    }
                }

                if (maxx_ind < matrix.GetLength(0) / 2)
                {
                    int summ = 0;
                    for (int i = maxx_ind + 1; i < matrix.GetLength(0); i++)
                    {
                        summ += matrix[i, j];
                    }
                    matrix[0, j] = summ;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            if (n % 2 != 0)
            {
                n--;
            }
            int[] indexes = new int[n];

            for (int i = 0; i < n; i++)
            {
                double maxx = -1e9;
                int ind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxx)
                    {
                        ind = j;
                        maxx = matrix[i, j];
                    }
                }
                indexes[i] = ind;
            }
            int c = 0;
            for (int i = 0; i < n - 1; i += 2)
            {
                (matrix[i, indexes[c]], matrix[i + 1, indexes[c + 1]]) = (matrix[i + 1, indexes[c + 1]], matrix[i, indexes[c]]);
                c += 2;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;

            int ind = 0;
            double maxx = -1e9;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > maxx)
                {
                    ind = i;
                    maxx = matrix[i, i];
                }
            }

            for (int i = 0; i < ind; i++)
            {
                for (int j = i+1; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int[] count = new int[matrix.GetLength(0)];
            int[] ind = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int c = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                        c++;
                }
                count[i] = c;
                ind[i] = i;
            }

            for (int i = 0; i < count.Length - 1; i++)
            {
                for (int j = 0; j < count.Length - i - 1; j++)
                {
                    if (count[j] < count[j+1])
                    {
                        (count[j], count[j + 1]) = (count[j + 1], count[j]);
                        (ind[j], ind[j + 1]) = (ind[j + 1], ind[j]);
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (ind[i] != i)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        (matrix[i, j], matrix[ind[i], j]) = (matrix[ind[i], j], matrix[i, j]);
                    }

                    for (int k = i + 1; k < matrix.GetLength(0); k++)
                    {
                        if (ind[k] == i)
                        {
                            ind[k] = ind[i];
                            break;
                        }
                    }
                    ind[i] = i;
                }
            }
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            int sum = 0;
            int c = 0;

            foreach (int[] row in array)
            {
                foreach(int num in row)
                {
                    c++;
                    sum += num;
                }
            }

            double global_sr = (double)sum / c;
            int ans_size = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int count = 0;
                int summa = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    count++;
                    summa += array[i][j];
                }
                double local_sr = (double)summa / count;

                if (local_sr >= global_sr)
                {
                    ans_size++;
                }
            }

            answer = new int[ans_size][];
            int ind = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int count = 0;
                int summa = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    count++;
                    summa += array[i][j];
                }
                double local_sr = (double) summa / count;

                if (local_sr >= global_sr)
                {
                    answer[ind] = new int[array[i].Length];
                    for (int j = 0; j < answer[ind].Length; j++)
                    {
                        answer[ind][j] = array[i][j];
                    }
                    ind++;
                }
            }
            // end

            return answer;
        }
    }
}