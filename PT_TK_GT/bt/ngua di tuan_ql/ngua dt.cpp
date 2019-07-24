#include <iostream>
#include <stdio.h>
#include <conio.h>
#include <windows.h>
using namespace std;
int a[8] = { -2,-1,1,2,-2,-1,1,2 };// cac sai biet ve toa do so voi x,y
int b[8] = { -1,-2,-2,-1,1,2,2,1};
int d = 0, x, y, n;// x,y la toa do diem xuat phat;
int  h[50][50];// h[u][v] duyet qua toa do u,v o buoc thu i.
void inkq()
{
	cout << endl << "Cach di thu " << ++d << ":" << endl;
	for (int i = 0; i<n; i++)
	{
		for (int j = 0; j<n; j++)
			printf("%3d", h[i][j]); // buoc di thu h[i][j]
		cout << endl;
	}
	
}
// buoc di thu k
void Try(int x, int y, int k) // dinh duyet la (x, y) và k la buoc di ke
{
	
		if (k>n*n) inkq();// neu di het cac o thi in ra kq
		else // xet buoc di k ke tiep
		for (int i = 0; i<8; i++) // so kha nang di toi da
		{
			int u = x + a[i], v = y + b[i]; // vi tri tiep theo
			if (u >= 0 && u<n && v >= 0 && v<n)
				if (h[u][v] == 0)// chua di qua (u,v)
				{
					h[u][v] = k; // (u,v) da duyet o buoc k
					Try(u, v, k + 1);// goi tiep buoc k+1
					h[u][v] = 0;
				}
		}
	
}
int main()
{
	cout << "Kich thuoc  : ";
	cin >> n;
	cout << "Nhap vi tri xuat phat (x,y) :";
	cin >> x >> y; 
	// khoi tao cac dinh chua duyet
	for (int i = 0; i<n; i++)
		for (int j = 0; j<n; j++)
			h[i][j] = 0;
	// danh dau di qua vi tri (x,y) da duyet o buoc 1
	h[x][y] = 1;
	
	Try(x, y, 2);// duyet buoc tiep theo
	if (d == 0)
		cout << "Khong ton tai cach di thoa man";
	else
		cout << "Co tat ca " << d << " cach di thoa man";
	getch();
	return 0;


}
