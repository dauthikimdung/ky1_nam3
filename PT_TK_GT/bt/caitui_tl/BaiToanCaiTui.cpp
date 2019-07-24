/*
Mo ta thuat toan:
Sap xep cac do vat theo ti le (gia tri / khoi luong)
Xet tu phan tu co ti le cao nhat
Neu con cho trong thi nhet vao
Cho den het do vat
*/
#include<iostream>
#include<conio.h>
#include<fstream>
using namespace std;
int a[50]; // mang khoi luong
int b[50];// mang gia tri
int n;// so do vat
int m;// tong khoi luong
float t[50];// mang ti le
int id[50];// mang id
void Nhap() {
	freopen("in2.txt", "r", stdin);
	cin >> n; // Doc so do vat
	cin >> m; // Doc khoi luong do vat
	for(int i=1;i<=n;i++)
	{
		// a[i] la trong luong cua do vat thu i 
		cin >> a[i];
	}
	for(int i=1;i<=n;i++)
	{
		
		//b[i] la gai tri cu do vat thu i
		cin >> b[i];
	}
		for(int i=1;i<=n;i++)// Khoi tao mang ti le
	{
		id[i]=i; // Khoi tao mang Id de luu vet thu tu phan tu
		t[i]=(float)b[i]/a[i];// Ti le gia tri / khoi luong
	}
	
}
//sap xep giam dan theo ti le gia tri / khoi luong
void sx(int n,int a[],int b[],int id[])
{
	int i,j;
	for(i=1;i<=n;i++)
		for(j=i+1;j<=n;j++)
			if(t[i]<t[j])
			{
				swap(a[i],a[j]);
				swap(id[i],id[j]);
				swap(b[i],b[j]);
				swap(t[i],t[j]);
			}
	
}

void balo(int n,int a[],int b[],int m,int id[])
{
	int i;
	// khoi tao : tong kich thuoc=0 ; tong gia tri=0;
	int tkt=0,tgt=0;
	// goi den ham sap xep
	sx(n,a,b,id);
	for(i=1;i<=n;i++){
		if(tkt == m)
			break;
			
		cout << "+ Cac do vat con lai la: ";
		for(int j=i;j<=n;j++){
			cout << id[j] << " ";
		}
		cout << endl;
		cout << "- Xet vat " << id[i] << ": Kich thuoc "<< a[i]<< ", Gia tri "<<b[i];
		cout <<endl << "- Khoi luong tui hien tai: " << tkt;
		cout <<endl << "- Khoi luong tui con lai: " << m - tkt;
		cout <<endl << "- Gia tri tui hien tai: " << tgt;
		cout <<endl;	
		if(tkt+a[i] <= m)// neu tkt+ khoi luong vat thu i "a[i] " nho hon khoi luong M toi da cua tui thi chon vat thu i
		{
			cout << "=> Chon vat "<< id[i] ;
			tgt+=b[i];
			tkt+=a[i];
			cout <<endl << "- Khoi luong tui sau khi chon: " << tkt;
			cout <<endl << "- Khoi luong tui con lai sau khi chon: " << m - tkt;
			cout <<endl << "- Gia tri tui sau khi chon: " << tgt;
			cout <<endl;
		}
		else {
			cout << "=> Khong chon vat "<< id[i]<< " kich thuoc "<< a[i] <<endl;
			cout << "+ Cac do vat con lai la: ";
			for(int j=i;j<=n;j++){
				cout << id[j] << " ";
			}
		}
		cout <<endl;		
	}		
	printf("\nTong kich thuoc la %d",tkt);
	printf("\nTong gia tri lon nhat la %d",tgt);	
}

int main()
{
	Nhap();
	// m la kich thuoc cua balo
	balo(n,a,b,m,id);
	return 0;
	getch();
}
