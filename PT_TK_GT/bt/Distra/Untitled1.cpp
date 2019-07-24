 #include<iostream>
#include<fstream>
#include<sstream>
#include <stack>

using namespace std;
#define max 50
#define VC 3200
int a[max][max];
int sodinh, socanh;

void Init()
{
	ifstream ifs("input1.in");
	ifs >> sodinh; // nhap so dinh

	for (int i = 1; i <= sodinh; i++)
	{
		for (int j = 1; j <= sodinh; j++)
		{
			ifs >> a[i][j]; // trong so cua canh
			if (a[i][j] != 0) socanh++;
			else
				a[i][j] = VC;// ko ton tai duong di

		}
	}
}
 void xuatdd(int s,int k, int Ddnn[max])
 {
 	int i;
 	cout<<"\n Duong di ngan nhat tu "<<s<< " den "<<k<<" la:";
 	i=k;// gan i la dinh cuoi cung
 	while(i!=s) // neu i khac dinh dau tien
 	{
 		cout<<i<<"<--"; // in cac dinh tu cuoi len dau
 		i=Ddnn[i]; //gan i cho dinh truoc dinh i tren duong di
	 }
	 cout<<s;// in ra dinh dau tien
 }

 void Dijkstra(int s)
 {
 	int Ddnn[max];//chua duong di ngan nhat tu s den dinh t tai moi buoc
 	int i,k,dht,Min;
 	int Daxet[max];//danh dau cac dinh da dua vao S
 	int L[max];
 	for(int i=1;i<=sodinh;i++)// khoi tao cac dinh chua xet
 	{
 		Daxet[i]=0;
 		L[i]=VC;
	 }
	 //Dua dinh s vao tap dinh S da xet
	 Daxet[s]=1;
	 L[s]=0;// tong duong di tu dinh dau den dinh dang xet
	 dht=s;// dinh duoc gan nhan hien tai
	 int h=1; //dem moi buoc: cho du n-1 buoc, tuc la duyet dc tat ca cac dinh thi dung lai
	 while(h<=sodinh-1)
	 {
	 	Min=VC;
	 	// duyet tat ca cac dinh de tim dinh co ddnn tu dinh dht
	 	for(int i=1;i<=sodinh;i++)
	 	if(!Daxet[i])
	 	{
	 		if(L[dht]+a[dht][i]<L[i])//tinh lai nhan; L[i] la khoang cach tu dinh dau den dinh i, L[dht] la khoang cach tu dinh dau den dinh gan nhan
	 		{
	 			L[i]=L[dht]+a[dht][i];
	 			Ddnn[i]=dht;
	 			//gan dinh hien tai la dinh truoc dinh i tren lo trinh
			 }
			 if(L[i]<Min)// chon dinh i co duong di ngan nhat
			 {
			 	Min=L[i];
			 	k=i;// k la dinh dc chon gan nhan tieo theo
			 }
		 }
		 //Tai buoc h: Tim duoc duong di ngan nhat tu s den k Ddnn[]
		 xuatdd(s,k,Ddnn); // mang ddnn[] luu cac dinh dc di qua truoc khi di den dinh can tim
		 cout<<"\n Trong so:"<<L[k];
		 dht=k;// Khoi dong lai Dht
		 Daxet[dht]=1; //Dua nut k vao tap nut da xet
		 h++;// tang so dinh da xet
	 }
 }

 int main()
{
	Init();
	Dijkstra(1);
	return 0;
}
