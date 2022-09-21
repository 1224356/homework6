double[] findDot(double[,] coeffArr)
{
    double[] dot = new double[2];
    dot[0] = Math.Round((coeffArr[1,1]-coeffArr[0,1])/(coeffArr[0,0]-coeffArr[1,0]), 2);
    dot[1] = Math.Round(coeffArr[0,0] * dot[0] + coeffArr[0,1], 2);
    return dot;
}

double[,] inputCoeffs()
{
    double[,] coeffs = new double[2,2];
    string symCoeff = "";
    //[[k1,b1], [k2,b2]]
    for (int i = 0; i < coeffs.GetLength(0); i++)
    {
        for (int j = 0; j < coeffs.GetLength(1); j++)
        {
            if (j == 0) symCoeff = "k";
            if (j == 1) symCoeff = "b";
            Console.Write($"Введите коэффициент {symCoeff}{i+1}: ");
            coeffs[i,j] = Convert.ToDouble(Console.ReadLine());
        }
    }
    return coeffs;
}

void printRightConds(string LineState)
{
    Console.WriteLine($"{LineState}Введите коэффициенты удовлетворяющие условиям:\n 1) Прямые не совпадают (Условие совпадения прямых: k1 = k2 и b1 = b2) \n 2) Прямые не параллельны (Условие паралельности прямых: k1 = k2 и b1 != b2)");
}

void checkLines(double[,] coeffLines)
{
    if ((coeffLines[0,0] == coeffLines[1,0]) && (coeffLines[0,1] == coeffLines[1,1])) 
    {
        printRightConds("Прямые совпадают! ");
        checkLines(inputCoeffs());
    }
    else if ((coeffLines[0,0] == coeffLines[1,0]) && (coeffLines[0,1] != coeffLines[1,1])) 
    {
        printRightConds("Прямые параллельны! ");
        checkLines(inputCoeffs());
    }
    else
    Console.WriteLine("Координаты точки пересечения: ({0})",String.Join("; ",findDot(coeffLines)));
} 

checkLines(inputCoeffs());