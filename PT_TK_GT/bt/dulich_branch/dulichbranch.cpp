#define _CRT_SECURE_NO_WARNINGS
#include<stdio.h>
#include<conio.h>
using namespace std;
int c[10][10];// do dai canh ij
int  x[10];// mang luu dinh da chon o buoc thu i
int  xmin[10];// mang luu cac dinh da chon o duong di toi uu hien tai
int  chuaxet[10];
int k;// chi so thu tu
int n;// so dinh
int s = 0;  // tong duong di
int cmin; //canh nho nhat
int  fmin = 10000;
//cmin là chi phi nho nhat giua 2 thanh pho
//s: chi phi
//xmin[] là chuoi xuat ra
//fmin la gia tri toi uu
void Nhap()
{
	FILE *f;
	f = fopen("NguoiDuLich1.txt", "r");
	fscanf(f, "%d", &n);
	for (int i = 1; i <= n; i++)
		for (int j = 1; j <= n; j++)
			fscanf(f, "%d", &c[i][j]);
	fclose(f);
}
void KhoiTao()// tim canh nho nhat la chon dinh bat dau duyet
{
	cmin = c[1][2];// khoi tao canh c[1][2] la canh cos trong so nho nhat
	// tim ra canh co trong so nho nhat
	for (int i = 1; i <= n; i++)
	{
		chuaxet[i] = 1;
		for (int j = 1; j <= n; j++)
		{
			if (i != j&&c[i][j] != 0 && cmin > c[i][j])
				cmin = c[i][j];

		}
	}
	x[1] = 1;// dinh duyet thu nhat bang 1
	chuaxet[1] = 0;// danh dau dinh 1 da xet
}

void Try(int k) // duyet dinh lan thu k
{
	int g;// chi phi du tinh nho nhat se di
	int tong; // tong duong di tu diem dau den diem cuoi va vong lai diem dau
	int i,j;
	for (j = 2; j <= n; j++)// duyet tu dinh thu 2
	{
		if (chuaxet[j] == 1)
		{
			x[k] = j;// dinh j la dinh dc chon o buoc thu k
			chuaxet[j] = 0;
			s = s + c[x[k - 1]][x[k]];// tong duong di den dinh j 
			//printf("%d\n", j);
			if (k < n)// so lan duyet nho hon so dinh
			{//de phat trien hanh trinh bo phan nay thanh mot hanh trinh day du, an phai di qua n-k+1 doan nua, gom n-k thanh pho con lai va quay lai T1
				g = s + cmin*(n - k + 1);// gia tri can( vi chi phi moi mot trong(n-k+1) doan con lai khon nho hon cmin, nen ham danh gia can co the xac dinh nhu vay
				if (g < fmin)// neu g nhohon chi phi toi uu hien tai
				{
					Try(k + 1);// di tiep buoc k+1
				}

			}
			if(k==n)// neu k=n , tinh chi phi hanh trinh vua tim duoc , Tong=s+ Cxn,1
			{
				tong = s + c[x[n]][x[1]];// tu diem cuoi quay lai diem dau
				if (tong < fmin)// neu tong < fmin
				{
					fmin = tong;
					for (i = 1; i <= n; i++)
						xmin[i] = x[i];//xmin[] là chuoi ket qua in ra
				}
			}
			s = s - c[x[k - 1]][x[k]];// tra lai chi phi cu
			chuaxet[j] = 1;//thao tac huy bo trang thai da xet
	
		}
	}
}
void Xuat()
{
	printf("Chi phi nho nhat la: %d", fmin);
	printf("\nHanh trinh nho nhat la: ");
	for (int i = 1; i <= n; i++)
	{
		printf("%d", xmin[i]);
		printf("->");
	}
	printf("1");
}
int main()
{
	Nhap();
	KhoiTao();
	Try(2);// bat dau tu buoc thu 2
	Xuat();
	getchar();
	return 0;
}
