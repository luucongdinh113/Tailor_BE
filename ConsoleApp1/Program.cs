namespace ConsoleApp1
{
    internal class Program
    {
        public static void Merge(int[] K, int l, int m, int r)
        {
            int[] result = new int[25];
            int n1 = m - l + 1, n2 = r - m;
            int[] L = new int[n1], R = new int[n2];
            for (var ii = l; ii <= m; ii++)
            {
                L[ii] = K[ii];
            }
            for (var ii = m + 1; ii < r; ii++)
            {
                R[ii] = K[ii];
            }
            int i = 0, j = 0, k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    result[k] = L[i];
                    i++;
                }
                else
                {
                    result[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                result[k] = L[i];
                k++; i++;
            }
            while (j < n2)
            {
                result[k] = R[j];
                k++; j++;
            }
            Console.WriteLine(result);
        }
        public static void MergeSort(int[] k, int l, int r)
        {
            if (r > l)
            {
                int m = (l + r) / 2;
                MergeSort(k, l, m);
                MergeSort(k, m + 1, r);
                Merge(k, l, m, r);
            }
        }
        public static void Main(string[] args)
        {
            //khai báo biến count để đếm số lần lặp khi sắp xếp
            int n;
            //nhập vào số lượng phần tử của mảng, nếu <= 0 thì nhập lại
            do
            {
                Console.Write("\nNhap vao so luong phan tu cua mang: ");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0);
            //khai báo mảng intArray
            int[] intArray = new int[n];
            Console.WriteLine("Nhap vao cac phan tu cua mang: ");
            //sử dụng vòng lặp for để nhập các phần tử cho mảng
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = int.Parse(Console.ReadLine());
            }
            //gọi hàm sắp xếp SortMethod và truyền vào các tham số tương ứng
            MergeSort(intArray, 0, n - 1);
            Console.Write("Cac phan tu sau khi sap xep: ");
            //in mảng sau khi sắp xếp
            foreach (int item in intArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("\n----Chuong trinh nay duoc dang tai Freetuts.net----\n");
            Console.ReadLine();
        }
    }
}