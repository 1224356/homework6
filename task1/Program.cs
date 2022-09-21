bool identifyNums(string[] arrNums)
{
    bool flag = true; 
    for (int i = 0; i < arrNums.Length; i++)
    {
        if ((int.TryParse(arrNums[i], out int NumInt) | double.TryParse(arrNums[i], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double NumDouble)) == false)
            {
                Console.WriteLine("Введите через запятую ТОЛЬКО числа:");
                flag = false;                
                break;
            }
    }
    return flag;
}

int countPosNums(string[] arrC)
{
    int count = 0;
    for (int iArrC =0; iArrC < arrC.Length; iArrC++)
    {
        if ((int.TryParse(arrC[iArrC], out int NumInt) == true) && (NumInt > 0))
        {
            count++;
        }
        if ((double.TryParse(arrC[iArrC], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double NumDouble) == true) && (NumDouble > 0))
        {
            count++;
        }
    }
    return count;
}

string[] arr;
Console.WriteLine("Введите через запятую несколько чисел:");
do
{
    string strIn = Convert.ToString(Console.ReadLine());
    arr = strIn.Replace(" ", "").Split(new char[] {','});
}
while(identifyNums(arr) == false);
Console.Write(countPosNums(arr));
