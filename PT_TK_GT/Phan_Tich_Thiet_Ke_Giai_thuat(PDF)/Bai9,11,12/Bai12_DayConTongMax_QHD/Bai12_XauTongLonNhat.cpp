#include<stdio.h>
#include<algorithm>
using namespace std;
const int maxn=100000+10;
int n;
int a[maxn];
int MaxS[maxn],MaxE[maxn];
int s1[maxn],s[maxn],e[maxn];
void docfile()
{
	char tenfile[28];
	int i;
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
			fscanf(fp,"%d",&a[i]);
	}
}
int MaxSubSeq(){
	MaxE[1]=a[1];s1[1]=1;
  	MaxS[1]=a[1];s[1]=1;e[1]=1;
  	for(int i=2;i<=n;i++){	
    	// Tinh MaxE[i]=Max(MaxE[i-1],0)+a[i];
    	if (MaxE[i-1]>0){
      		MaxE[i]=MaxE[i-1]+a[i];
      		s1[i]=s1[i-1];
      		
    	}
    	else{
      		MaxE[i]=a[i];
      		s1[i]=i;
    	}
    	// Tinh MaxS[i]=Max(MaxS[i-1],MaxE[i]);
    	if (MaxS[i-1]>=MaxE[i]){
      		MaxS[i]=MaxS[i-1];
      		s[i]=s[i-1];e[i]=e[i-1];
      		}2s5
    	else{
      		MaxS[i]=MaxE[i];
      		s[i]=s1[i];e[i]=i;
      	}
    	printf("\n");
   	// printf("%5d %5d %5d %5d %5d\n",MaxE[i],s1[i],MaxS[i],s[i],e[i]);
  	}
}
int main(){
  //freopen("input.txt","r",stdin);
  //scanf("%d",&n);
  //for(int i=1;i<=n;i++) scanf("%d",&a[i]);
  docfile();
  MaxSubSeq();

  printf("Day con co tong Max la: ");
  for(int i=s[n];i<=e[n];i++) printf("%d ",a[i]);
  printf("\n");
  printf("Trong so la: %d",MaxS[n]);
}

