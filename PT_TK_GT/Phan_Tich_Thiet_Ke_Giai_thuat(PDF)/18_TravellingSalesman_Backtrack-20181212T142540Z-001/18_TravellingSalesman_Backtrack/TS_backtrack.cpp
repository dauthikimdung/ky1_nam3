#include <iostream>
#include <fstream>
using namespace std;

#define MAX 100
#define maxE 1000
#define INF 99999

int C[MAX + 1][MAX + 1]; // ma tran trong so
int X[MAX + 2];     // mang chua cac dinh da duyet    
    //(1...max+1)
int BestWay[MAX + 2]; // mang chua cac dinh nam trong duong di ngan nhat
int T[MAX + 1];       

bool Free[MAX + 1]; // dinh chua dc xet
int minSpending;    // chi phi ngan nhat
int m, n;

void Input()// nhap so dinh va trong so canh
{

    ifstream infile;
    infile.open("NguoiDuLich1.txt");
    infile >> n;
    for (int i = 1; i <= n; i++)
        for (int j = 1; j <= n; j++)
            infile >> C[i][j];
    infile.close();
}

void Init()// 
{
    for (int i = 1; i <= n; i++)
        Free[i] = true; // khoi tao dinh chua xet
    Free[1] = false; // dinh 1 da xet
    X[1] = 1;        
    T[1] = 0;        
    minSpending = INF;// khoi tao minspending
}

void PrintResult()
{
    if (minSpending == INF)
        cout << "NO SOLUTION ";
    else // neu co duong di
    {
        for (int i = 1; i <= n; i++)
            cout << BestWay[i] << "->";
        cout << "1" << endl;
        cout << "Cost : " << minSpending;// chi phi ngan nhat
    }
}

void Try(int i) // duyet lan thu i
{
    for (int j = 2; j <= n; j++)
    {
        if (Free[j]) // neu dinh j chua dc duyet
        {
            X[i] = j;      // them dinh j vao mang , j la dinh duyet thu i                   
            T[i] = T[i - 1] + C[X[i - 1]][j]; // chi phi den dinh j
            
            if (C[X[i - 1]][j] > 0) // neu ton tai duong di tu dinh truóc do den dinh j         
            {
                if (i < n) // chua duyet het n lan
                {
                    Free[j] = false; // dinh j da duyet
                    Try(i + 1);      // duyet lan thu i+1
                    Free[j] = true;  //tra lai trang thai
                }
                else
                {
                    if ((T[n] + C[X[n]][1]) < minSpending) // tong chi phi<min
                    {
                       
                        for (int i = 0; i <= n; i++)
                            BestWay[i] = X[i];// duong di ngan nhat
                        minSpending = T[n] + C[X[n]][1];// chi phi ngan nhat
                    }
                }
            }
        }
    }
}

int main()
{
    Input();
    Init();
    Try(2);
    PrintResult();
}
