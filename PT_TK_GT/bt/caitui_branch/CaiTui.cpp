//thuat toan nhanh can, tim phuong an toi uu
#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <conio.h>
const int max = 100;
int w[max];//khai bao mang chua khoi luong
int v[max];//gia tri cua cac do vat
int n;// so do vat
float wv[max];
int soluong;//so luong 
int m;//khoi luong túi
int khoiluongdovat;//khoi luong do vat chiem trong túi sau khi xep toi uu
int TL=0;//trong luong tong các vat da xep(hien tai)
int dem = 0;
int gt[100];		//cac buoc cua thuat toan
int sl[100]; // so luong cua moi do vat
int slmax[100];		//so luong cua moi do vat cua cach chon toi uu
int s=0;//tong giá tri tai thoi diem hien tai
int fmax=0;//giá tri lon nhat sau moi lan duyet het, khoi tao fmax=0
float g;// can tren cua gia tri

void input()
{
	FILE *f;
	int i, x, y;
	f = fopen("input2.txt", "r");
	fscanf(f, "%d", &m); // khoi luong tui
	fscanf(f, "%d", &n);// so do vat
	for (i = 0; i < n; i++)
	{
			fscanf(f, "%d", &x);
			w[i] = x;// trong luong vat
			fscanf(f, "%d", &y);
			v[i] = y;// gia tri
			wv[i] = (float)v[i] / w[i]; // ty so
	}
	
	fclose(f);
}
void hoandoi(float &a, float &b) {
	float temp = a;
	a = b;
	b = temp;
}
//sap xep theo thu tu giam dan cua v[i]/w[i] tuc la wv[i]
void sort() {
	for (int i = 0; i<n; i++) {
		for (int j = i + 1; j<n; j++) {
			if (wv[j]>wv[i]) {
				hoandoi((float&)w[j], (float&)w[i]);
				hoandoi((float&)v[j], (float&)v[i]);
				hoandoi(wv[j], wv[i]);
			}
			else if (wv[j] == wv[i]) 
			{
				if (w[j]<w[i])//sx tang dan cua khoi luong
				{
					hoandoi((float&)w[j], (float&)w[i]);
					hoandoi((float&)v[j], (float&)v[i]);
					hoandoi(wv[j], wv[i]);
				}
			}
		}
	}
}
//hien thi 
void display() {
	printf("\nDo vat   khoiluong    Giatri      Tyso\n");
	for (int i = 0; i<n; i++) {
		printf("%d  \t  %3d  \t       %3d  \t%5.2f", i+1, w[i], v[i], wv[i]);
		printf("\n");
	}
}
//thuat toan nhanh can
void Try(int i) // do vat thu i
{
	int j;
	// khi tiep tuc xay dung thanh phan thu i, các ga tri co the cho sl[i] se la : 0, 1,... soluong 
	soluong = (m - TL) / w[i];// so do vat i co the them vao
	for (j = soluong; j >= 0; j--)
	{
		sl[i] = j;// so luong cu do vat thu i
		TL += w[i] * sl[i];// trong luong tui khi them do vat thu i
		s += v[i] * sl[i]; // gia tri tui khi them do vat thu i
		if (i == n-1)// neu dã xet den do vat thu n, vi i chay tu 0
		{
			if (s > fmax)// neu gia tri hien tai lon hon gia tri toi uu
			{
				for (int k = 0; k < n; k++)
				{
					slmax[k] = sl[k];// mang luu cac do vat voi so luong tuong ung dc them vao tui la toi uu
				}
				khoiluongdovat = TL;// khoi luong do vat sau khi xep tôi uu=TL
				fmax = s;//gia tri toi uu = gia tri hien tai
			}
		}
		else
		{// g=g(sl1,sl2,...,sli)  can tren cho phuong an bo phan(sl1,sl2,...sli)
		
			g = s + (float)v[i + 1] * (m - TL) / w[i + 1];
			if (g > fmax)
				Try(i + 1);//xet tiep do vat thu i+1
		}
		TL = TL - w[i] * sl[i];// tra lai trang thai cu cho bai toan
		s = s - v[i] * sl[i];
	}
}
int main()
{
	input();
	//display();
	printf("\nSau khi sap xep:\n");
	sort();
	display();
	printf("\nThuat toan nhanh can: \n");
	Try(0);
	printf("\nDo vat   soluong   m    giatri\n");
	for (int i = 0; i<n; i++) 
	{
		printf("%d         %d        %d         %d   \n", i+1,slmax[i],w[i],v[i]);
		printf("\n");
	}
	printf("\nKhoi luong tui da dung: %d", khoiluongdovat);
	printf("\nTong gia tri: %d", fmax);
	getchar();
	getchar();
	return 1;
}
