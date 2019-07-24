#include <stdio.h>
#include <stdlib.h>

int a[28][28]; // Ma tran ke
int n;
void docfile()
{
	char tenfile[28];
	int i,j;
	FILE *fp;
	printf(" Nhap ten file input: ");
	gets(tenfile);
	fp=fopen(tenfile,"rt");
	if(fp==NULL)
	{
		printf("file khong ton tai!\n");
		exit(0);
	}
	else
	{
		fscanf(fp,"%d",&n);
		for(i=1;i<=n;i++)
			for(j=1;j<=n;j++)
				fscanf(fp,"%d",&a[i][j]);
	}
}

void xuat()
{
	int i,j;
	printf("so dinh:  %d\n",n);
	for(i=1;i <= n;i++) // Hien thi ma tran ke vua nhap
	{
		for(j=1;j<=n;j++)
			printf("%d ",a[i][j]);
		printf("\n");
	}
}
void ketqua(int n,int maudinh[])
{
	printf("to mau o buoc thu %d",n);
	printf("\n");
	for(int i=1;i<=n;i++)
	 	printf("mau dinh%3d: %5d\n",i,maudinh[i]); 	 	
}
// kiem tra mau trung
int kiemtramau(int z[],int w,int mau)// w la so mau gan dinh can xet, mau : mau can kt
{
	int i;
	for(i=1 ;i <= w ;i++) // Duyet trong bang mau da su dung
		if(mau == z[i]) // Mau bi trung
			return 1;
	return 0; // Mau moi
}
// chon mau thich hop de to
int chonmau(int g[],int l)
{
	int mau = 1;
	int i;
	do{
		if(!kiemtramau(g,l,mau)) // Neu la mau moi
		{		
			return mau; // Tra ve gia tri mau moi
			break;
		}
		else // Neu la mau cu
			mau++; // Chon mau tiep theo
	} while(1);
}
// to mau cho cac dinh do thi
void tomau()
{
	int i;
	int j;// dinh dc chon de xet tiep theo
	int l;// so dinh da to mau
	int mau;// chi so mau to
	int t=0;// so mau da dc to
	int maudinh[28]; // Mau cua dinh 
	int dinhtruoc[28]; // Dinh da duoc to mau
	int mauphu[28]; // Cac mau da dc to cho dinh ke voi dinh dang xet
	l=1;/// da to mau cho dinh 1
	mau=1;// gan mau dau tien la mau 1
	j = 2;// to mau cho dinh thu 2
	maudinh[1] = mau;// gan dinh 1 da dc to mau 1
	dinhtruoc[1] = 1; // dinh da to dua vao mang dinhtruoc
	ketqua(l,maudinh);
	do {
 		for(int kb=1; kb<=l; kb++) // Duyet trong cac dinh da to mau
 			if(a[j][dinhtruoc[kb]] == 1) // Neu dinh do ke voi dinh j
 			{
 				t++;// tang bien dem so mau cua dinh ke voi dinh J
 				mauphu[t] = maudinh[dinhtruoc[kb]];  // Dua mau cua dinh do vao mauphu
			 }
 				
		maudinh[j] = chonmau(mauphu,t);	// Chon mau cho dinh j
		l = j; // So dinh da to mau
		ketqua(l,maudinh);
		dinhtruoc[l]=j;// Dinh da to dua vao mang dinhtruoc 
	 	j++; // Xet dinh tiep theo
	 	t=0;		
	} while(j<=n); // Ket thuc khi duyet toan bo cac dinh	
		
 }
int main() {
	docfile();
	xuat();
	tomau();
}


