
#include<stdio.h>
#include<iostream>
#include<conio.h>
 using namespace std;
#define max 100
int a[max];
int n;
int t1, t2;

void Nhap();
int  MaxLeftVector(int i, int j,int &dau);
int  MaxRightVector(int i, int j,int &cuoi);
int MaxSubVector(int i, int j, int &dau, int &cuoi);
int main()
{
	int dau, cuoi;
	Nhap();
	MaxSubVector(0, n - 1,dau,cuoi);
	cout << "Day con lon nhat:";
	for (int i = dau; i <= cuoi; i++)
	{
		cout << " " << a[i];
	}
	return 0;
}
 // ham nhap

void Nhap(void){
	 freopen("input1.txt", "r", stdin);
	 cin>>n;
	 cout<<"So phan tu: "<< n <<endl;
// khoi tao mang a
	for (int i = 0; i < n; i++){
		    cin>>a[i];	
	}
}
int Max(int a, int b)
{
	if (a>b) return a;
	else return b;
}
int MaxLeftVector(int i, int j,int &dau) // tim tong max tu j giam dan qua trái den  i
{
	int MaxSum = -INT_MAX;
	int Sum = 0;
	for (int k = j; k >= i; k--)
	{
		Sum += a[k];
		if (MaxSum < Sum) { MaxSum = Sum; dau = k; }
	}
	return MaxSum;
}
int  MaxRightVector(int i, int j,int &cuoi) // tim tong max tu i sang phai den j
{
	int MaxSum = -INT_MAX;
	int Sum = 0;
	for (int k = i; k <= j; k++)
	{
		Sum += a[k];	
		if (MaxSum < Sum) { MaxSum = Sum; cuoi= k; }
	}
	return MaxSum;
}
int MaxSubVector(int i, int j,int &dau,int &cuoi)
{
	int dau1, dau2,dau3,cuoi3, cuoi1, cuoi2;
	if (i == j) {
		dau = i; cuoi = i; return a[i];
	}
	else
	{
		int m = (i + j) / 2;
		int wl, wr, wm;
		wl = MaxSubVector(i, m, dau1, cuoi1); // max cua day ben trai
		wr = MaxSubVector(m + 1, j, dau2, cuoi2); // max cua day ben phai
		wm = MaxLeftVector(i, m,dau3) + MaxRightVector(m + 1, j,cuoi3); // max cua day gop lai
		int maxTam = Max(Max(wl, wr), wm); // max cua 3 loai
		// Luu vet
		if (maxTam == wl){ dau = dau1; cuoi = cuoi1; }
		else if (maxTam == wr){ dau = dau2; cuoi = cuoi2; }
		else if (maxTam == wm){ dau = dau3; cuoi = cuoi3; }
		return maxTam; // => dc max cua day ben trai hoac phai tuong ung
	}
}
